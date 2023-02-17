using Telegram.Bot;
using Telegram.Bot.Polling;

namespace bot.Services;

public class BotBeckgroundServise : BackgroundService
{
    private readonly ITelegramBotClient _client;
    private readonly ILogger<BotBeckgroundServise> _logger;
    private readonly IUpdateHandler _handler;

    public BotBeckgroundServise(
        ILogger<BotBeckgroundServise> logger,
        ITelegramBotClient client,
        IUpdateHandler handler)
    {
        _client = client;
        _logger = logger;
        _handler = handler;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var bot = await _client.GetMeAsync(stoppingToken);

        _logger.LogInformation("Bot satrted succusfull: {bot.Username}", bot.Username);

        _client.StartReceiving(
            _handler.HandleUpdateAsync,
            _handler.HandlePollingErrorAsync,
            new ReceiverOptions()
            {
                ThrowPendingUpdates = true
            }, stoppingToken);
    }
}