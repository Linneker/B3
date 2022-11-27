using B3.API;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
logger.Debug("Inicio");

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
builder.Logging.AddJsonConsole();
var app = builder.Build();

startup.Configure(app, app.Environment, Startup.loggerFactory);

app.Run();

logger.Debug("Fim");
