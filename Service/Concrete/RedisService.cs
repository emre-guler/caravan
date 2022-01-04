using System;
using System.Threading.Tasks;
using Caravan.Interfaces;
using EasyCaching.Core;
using StackExchange.Redis;

namespace Caravan.Service
{
    public class RedisService : IRedisService
    {
        private readonly IEasyCachingProvider _redisProvider;
        private readonly IEasyCachingProviderFactory _redisFactory;
        public RedisService(
            IEasyCachingProviderFactory redisFactory
        )
        {
            this._redisFactory = redisFactory;
            this._redisProvider = this._redisFactory.GetCachingProvider("redis");
        }
        public async Task Add(string key, object value)
        {
            await this._redisProvider.SetAsync(key, value, TimeSpan.MaxValue);
        }

        public async Task<CacheValue<T>> Get<T>(string key)
        {
            return await this._redisProvider.GetAsync<T>(key);
        }

        public async Task Remove(string key)
        {
            await this._redisProvider.RemoveAsync(key);
        }

        public async Task Update(string key, object value)
        {
            await this._redisProvider.RemoveAsync(key);
            await this._redisProvider.SetAsync(key, value, TimeSpan.MaxValue);
        }
    }
}