using Domus.Hydra.Keys;
using Domus.Hydra.Storage.Records;
using Domus.Hydra.Trigger;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domus.Hydra.Storage.Memory
{
    public class TriggerMemoryStorage : ITriggerStorage
    {
        public TriggerMemoryStorage(IJobStorage jobStorage)
        {
            this.jobStorage = jobStorage;
        }

        public string Name => throw new NotImplementedException();

        private ConcurrentDictionary<TriggerKey, TriggerRecord> items;
        private IJobStorage jobStorage;

        public TriggerRecord this[TriggerKey key] => throw new NotImplementedException();

        public bool Has(TriggerKey key)
        {
            throw new NotImplementedException();
        }

        public void Initialize(MemoryStorageConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public void Remove(TriggerKey key)
        {
            throw new NotImplementedException();
        }

        public TriggerKey Add<T>(T instance) 
            where T : class, ITrigger
        {
            if(instance == null)
            {
                //throw instance is null
            }

            if(jobStorage.Has(instance.Key.Parent))
            {
                //throw job not found
            }

            if(items.ContainsKey(instance.Key))
            {
                //throw trigger already exists
            }
            var record = new TriggerRecord(instance);

            if(!items.TryAdd(instance.Key, record))
            {
                //throw something wrong
            }

            return instance.Key;
        }
    }
}
