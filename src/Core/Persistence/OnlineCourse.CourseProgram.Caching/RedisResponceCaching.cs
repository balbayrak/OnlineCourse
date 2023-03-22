using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using OnlineCourse.Application.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.CourseProgram.Caching
{
    public class RedisResponceCaching : IResponseCachingService
    {
        private readonly IDistributedCache _distributedCache;

        public RedisResponceCaching(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan expireTimeSeconds)
        {
            if (response == null)
                return;
         
            var serializedResponse = JsonConvert.SerializeObject(response);

            await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expireTimeSeconds
            });
        }

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);

            return string.IsNullOrEmpty(cachedResponse) ? string.Empty : cachedResponse;
        }
    }
}
