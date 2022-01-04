using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCaching.Core;

namespace Caravan.Interfaces
{
    public interface IRedisService
    {
        Task Add(string key, object value);
        Task Update(string key, object value);
        Task<CacheValue<T>> Get<T>(string key);
        Task Remove(string key);
    }
}