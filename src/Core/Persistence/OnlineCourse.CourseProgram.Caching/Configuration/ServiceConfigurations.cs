using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourse.Application.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.CourseProgram.Caching.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddResponseCacheConfigurations(this IServiceCollection services, Action<CachingOption> option)
        {
            CachingOption cacheOption = new CachingOption();
            option?.Invoke(cacheOption);

            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = cacheOption.Uri.ToString();
            });

            services.AddSingleton<IResponseCachingService, RedisResponceCaching>();
        }
    }
}
