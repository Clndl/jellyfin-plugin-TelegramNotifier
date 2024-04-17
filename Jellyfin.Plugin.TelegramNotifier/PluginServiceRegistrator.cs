using Jellyfin.Data.Events;
using Jellyfin.Data.Events.System;
using Jellyfin.Data.Events.Users;
using Jellyfin.Plugin.TelegramNotifier.Notifiers;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Common.Updates;
using MediaBrowser.Controller.Authentication;
using MediaBrowser.Controller.Events;
using MediaBrowser.Controller.Events.Session;
using MediaBrowser.Controller.Events.Updates;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Session;
using MediaBrowser.Controller.Subtitles;
using MediaBrowser.Model.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Jellyfin.Plugin.TelegramNotifier;

public class PluginServiceRegistrator : IPluginServiceRegistrator
{
    public void RegisterServices(IServiceCollection serviceCollection)
    {
        // Register sender.
        serviceCollection.AddScoped<Sender>();

        // Library consumers.
        // serviceCollection.AddScoped<IEventConsumer<SubtitleDownloadFailureEventArgs>, SubtitleDownloadFailureNotifier>();
        // serviceCollection.AddSingleton<IItemAddedManager, ItemAddedManager>();

        // Security consumers.
        // serviceCollection.AddScoped<IEventConsumer<GenericEventArgs<AuthenticationRequest>>, AuthenticationFailureNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<GenericEventArgs<AuthenticationResult>>, AuthenticationSuccessNotifier>();

        // Session consumers.
        serviceCollection.AddScoped<IEventConsumer<PlaybackStartEventArgs>, PlaybackStartNotifier>();
        serviceCollection.AddScoped<IEventConsumer<PlaybackStopEventArgs>, PlaybackStopNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<PlaybackProgressEventArgs>, PlaybackProgressNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<SessionStartedEventArgs>, SessionStartNotifier>();

        // System consumers.
        // serviceCollection.AddScoped<IEventConsumer<PendingRestartEventArgs>, PendingRestartNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<TaskCompletionEventArgs>, TaskCompletedNotifier>();

        // Update consumers.
        // serviceCollection.AddScoped<IEventConsumer<PluginInstallationCancelledEventArgs>, PluginInstallationCancelledNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<InstallationFailedEventArgs>, PluginInstallationFailedNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<PluginInstalledEventArgs>, PluginInstalledNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<PluginInstallingEventArgs>, PluginInstallingNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<PluginUninstalledEventArgs>, PluginUninstalledNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<PluginUpdatedEventArgs>, PluginUpdatedNotifier>();

        // User consumers.
        serviceCollection.AddScoped<IEventConsumer<UserCreatedEventArgs>, UserCreatedNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<UserDeletedEventArgs>, UserDeletedNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<UserLockedOutEventArgs>, UserLockedOutNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<UserPasswordChangedEventArgs>, UserPasswordChangedNotifier>();
        // serviceCollection.AddScoped<IEventConsumer<UserUpdatedEventArgs>, UserUpdatedNotifier>();
    }
}