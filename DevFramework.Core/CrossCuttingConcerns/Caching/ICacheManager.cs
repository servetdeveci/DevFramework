using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Caching
{
    /// <summary>
    /// biz output cache yapacağız her cache datasına bir isim vermemiz gerekiyor
    /// </summary>
   public  interface ICacheManager
    {
        T Get<T>(string key);
        void Add(string key, object data, int cacheTime);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string key);
        void Clear();
    }
}
