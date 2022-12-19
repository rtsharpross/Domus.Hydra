using Domus.Hydra.Job;
using Domus.Hydra.Keys;
using Domus.Hydra.Storage.Records;
using Domus.Hydra.Utils;
using System.Collections.Concurrent;

namespace Domus.Hydra.Storage.Memory
{
    internal class JobMemoryStorage : IJobStorage
    {
        public JobMemoryStorage(InstanceKey instanceKey)
        {
            _instanceKey = instanceKey;
            _items = new ConcurrentDictionary<JobKey, JobRecord>(4, 1);
        }

        private readonly ConcurrentDictionary<JobKey, JobRecord> _items;
        private readonly InstanceKey _instanceKey;

        public string Name => throw new NotImplementedException();

        public JobRecord this[JobKey key]
        {
            get
            {
                if (_items.TryGetValue(key, out var record))
                {
                    return record;
                }

                throw ThrowHelper.JobNotFoundException(key);
            }
        }

        public void Remove(JobKey jobKey)
        {
            if (!_items.TryRemove(jobKey, out var record))
            {
                ThrowHelper.JobNotFound(jobKey);
            }
        }

        public JobKey Add<T>(string name)
            where T : class, IJob, new()
        {
            var key = new JobKey(_instanceKey, name);
            var record = new JobRecord(key);

            if (!_items.TryAdd(key, record))
            {
                ThrowHelper.Throw(string.Empty);
            }

            return key;
        }

        public bool Has(JobKey jobKey) => _items.ContainsKey(jobKey);

        protected void OnRecordChange(object? sender)
        {

        }

        public void Initialize(MemoryStorageConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
