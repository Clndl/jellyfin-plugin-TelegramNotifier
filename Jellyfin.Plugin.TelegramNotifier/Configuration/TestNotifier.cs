using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Jellyfin.Plugin.TelegramNotifier.Telegram;

[Route("TelegramNotifierApi/TestNotifier")]
[ApiController]
public class TestNotifier : ControllerBase
{
    private readonly Sender _sender;

    public TestNotifier(Sender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
        string message = "[Jellyfin] Test message: \n 🎉 Your configuration is correct ! 🥳";

        string botToken = Plugin.Config.BotToken;

        string chatId = Plugin.Config.ChatId;

        bool result = await _sender.SendMessage("Test", message, botToken, chatId).ConfigureAwait(false);

        if (result)
        {
            return Ok("Message sent successfully");
        }
        else
        {
            return BadRequest("Message could not be sent, please check your configuration");
        }
    }
}
