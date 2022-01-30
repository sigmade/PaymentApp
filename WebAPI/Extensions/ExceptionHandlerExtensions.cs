using Microsoft.AspNetCore.Diagnostics;
using Shared.Translations.Exceptions;
using Shared.Translations.Models;
using Shared.Translations.Services;
using System.Net;

namespace WebAPI.Extensions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseConfiguredExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var requestContext = context.RequestServices.GetRequiredService<RequestContext>();
                        var translateService = context.RequestServices.GetRequiredService<JsonFileTranslateService>();

                        int statusCode = (int)HttpStatusCode.InternalServerError;
                        string message = string.Empty;

                        var exception = contextFeature.Error;
                        while (exception != null)
                        {
                            switch (exception)
                            {
                                case TranslatableException:
                                    var translatableException = exception as TranslatableException;
                                    message = translateService.Translate(translatableException.LocalizationKey, requestContext.Language, translatableException.FormatArgs);
                                    break;
                                default:
                                    if (string.IsNullOrEmpty(message))
                                    {
                                        message = exception.Message;
                                    }
                                    break;
                            }

                            exception = exception.InnerException;
                        }

                        if (!string.IsNullOrEmpty(message))
                        {
                            context.Response.StatusCode = statusCode;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(message);
                        }
                    }
                });
            });
        }
    }
}
