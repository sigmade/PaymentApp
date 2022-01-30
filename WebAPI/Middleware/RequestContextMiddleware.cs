using Shared.Translations.Models;

namespace WebAPI.Middleware
{
    public class RequestContextMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, RequestContext requestContext)
        {
            requestContext.Language = ParseLanguage(httpContext.Request.Cookies["language"]);

            return _next.Invoke(httpContext);
        }

        private Language ParseLanguage(string langCode)
        {
            return langCode switch
            {
                "kz" => Language.Kazakh,
                "ru" => Language.Russian,
                _ => Language.Russian,
            };
        }
    }
}
