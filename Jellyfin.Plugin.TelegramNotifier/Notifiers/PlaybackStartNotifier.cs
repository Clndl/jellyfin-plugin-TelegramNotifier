using System;
using System.Threading.Tasks;
using MediaBrowser.Controller.Events;
using MediaBrowser.Controller.Library;

namespace Jellyfin.Plugin.TelegramNotifier.Notifiers;

public class PlaybackStartNotifier : IEventConsumer<PlaybackStartEventArgs>
{
    private readonly Sender _sender;

    public PlaybackStartNotifier(Sender sender)
    {
        _sender = sender;
    }

    public async Task OnEvent(PlaybackStartEventArgs eventArgs)
    {
        if (eventArgs == null)
        {
            throw new ArgumentNullException(nameof(eventArgs));
        }

        if (eventArgs.Item is null || eventArgs.Users.Count == 0 || eventArgs.Item.IsThemeMedia)
        {
            return;
        }

        string message = $"👤 {eventArgs.Users[0].Username} is watching on {eventArgs.DeviceName}:\n" +
                         $"🎬 {eventArgs.Item.Name} ({eventArgs.Item.ProductionYear})\n" +
                         $"📺 {eventArgs.Item.MediaType}\n" +
                         $"🕒 {eventArgs.Item.RunTimeTicks / 600000000} minutes\n" +
                         $"📽 {eventArgs.Item.Overview}";

        await _sender.SendMessage(message, logEvent: "Playback started").ConfigureAwait(false);
    }
}