using Domus.Hydra.Job;
using Domus.Hydra.Keys;
using Domus.Hydra.Storage.Memory;
using Domus.Hydra.Storage.Records;

namespace Domus.Hydra.Storage
{
    public interface IJobStorage : IStore<JobKey, JobRecord, MemoryStorageConfiguration>
    {
        JobKey Add<T>(string name) where T : class, IJob, new();
    }
}
