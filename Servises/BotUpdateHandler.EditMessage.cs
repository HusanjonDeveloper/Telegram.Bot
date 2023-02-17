using Telegram.Bot.Types;

namespace bot.Services;
public partial class BotUpdateHandler
{
    private async Task HandleEditMessageAscnc(ITelegramBotClinet clinet, Message? message, CancellationToken token1)
    {
        ArgumentNullException.ThrowIfNull(message);

        var from = message.From;
        _logger.LogInformation("Received message  from {from.Fristname}: {message.text}", from?.FirstName, message.Text);


    }
}