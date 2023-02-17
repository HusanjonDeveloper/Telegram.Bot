using bot.Services;
using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue("BotToken", string.Empty);

//builder.Services.AddSingleton<ITelegramBotClient, TelegramBotClient>();
builder.Services.AddSingleton(new TelegramBotClient(token));
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();
builder.Services.AddHostedService<BotBeckgroundServise>();

var app = builder.Build();

app.Run();

