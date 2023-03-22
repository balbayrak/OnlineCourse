using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Application.Caching
{
    public interface IResponseCachingService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan expireTimeSeconds);
        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}
