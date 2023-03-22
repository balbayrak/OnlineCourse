using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourse.Application.Caching;

namespace OnlineCourse.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _expireTimeSeconds;
        public CachedAttribute(int expireTimeSeconds)
        {
            _expireTimeSeconds = expireTimeSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheFactory = context.HttpContext.RequestServices.GetRequiredService<IResponseCachingService>();
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cachedResponse = await cacheFactory.GetCachedResponseAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }
            var executedContext = await next();

            if (executedContext.Result is OkObjectResult okObjectResult)
            {
                await cacheFactory.CacheResponseAsync(cacheKey, okObjectResult.Value,
                   TimeSpan.FromSeconds(_expireTimeSeconds));
            }
        }

        private static string GenerateCacheKeyFromRequest(HttpRequest httpContextRequest)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{httpContextRequest.Path}");

            foreach (var (key, value) in httpContextRequest.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }

            return keyBuilder.ToString();
        }
    }
}
