using Application;
using Domain.Services;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using Shared.Translations.Models;
using Shared.Translations.Services;
using WebAPI.Extensions;
using WebAPI.Middleware;


var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Start PaymentApp");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
    builder.Host.UseNLog();

    builder.Services.AddScoped<RequestContext>();

    var i18nConfig = builder.Configuration.GetSection("I18n");
    builder.Services.Configure<JsonFileTranslateServiceOptions>(i18nConfig);
    builder.Services.AddSingleton<JsonFileTranslateService>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "WebApi",
            Version = "v1",
            Contact = new OpenApiContact
            {
                Name = "Egor Sychev",
                Email = "sychyov1991@mail.ru",
                Url = new Uri("https://www.github.com/sigmade/")
            }
        });
    });
    builder.Services.AddScoped<IPaymentService, PaymentService>();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    IWebHostEnvironment env = app.Environment;

    app.UseConfiguredExceptionHandler(env);
    app.UseHttpsRedirection();

    app.UseMiddleware<RequestContextMiddleware>();
    
    app.UseStaticFiles();

    app.UseDirectoryBrowser(new DirectoryBrowserOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs")),
        RequestPath = "/logs"
    });

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}
