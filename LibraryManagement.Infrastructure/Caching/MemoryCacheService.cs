using Newtonsoft.Json;
using System.Runtime.Caching;

namespace LibraryManagement.Infrastructure.Caching
{
    public class MemoryCacheService : ICache
    {
        private readonly int _cacheTime = 60;

        /// <param name="cacheTime">The life time in minutes.</param>
        public MemoryCacheService(int cacheTime = 60)
        {
            _cacheTime = cacheTime;
        }

        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
                // o colectie de KeyValuePair<string,object>
            }
        }
        /// Gets the value associated with the specified key.
        public T Get<T>(string key)
        {
            var cachedData = Cache[key].ToString();

            if (cachedData == null)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(cachedData, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        /// Adds the specified key and object to the cache.
        public void Set(string key, object objectData, int? cacheTime = null)
        {
            if (objectData == null)
            {
                return;
            }

            var policy = new CacheItemPolicy();
            if (!cacheTime.HasValue)
            {
                cacheTime = _cacheTime;
            }

            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime.Value);

            string jsonData = JsonConvert.SerializeObject(objectData, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            Cache.Add(new CacheItem(key, jsonData), policy);

        }

        /// Gets a value indicating whether the value associated
        /// with the specified key is cached
        public bool IsSet(string key)
        {
            return Cache.Contains(key);
        }

        public bool IsEmpty()
        {
            return Cache.Count() == 0;
        }

        /// Removes the value with the specified key from the cache
        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            foreach (var item in Cache)
            {
                if (item.Key.StartsWith(pattern))
                {
                    Remove(item.Key);
                }
            }
        }

        /// Clear all cache data
        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }

        public List<T> GetAll<T>()
        {
            List<T> items = new List<T>();

            foreach(var item in Cache)
            {
                items.Add(Get<T>(item.Key));
            }

            return items;
        }
    }
}
