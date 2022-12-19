using Domus.Hydra.Keys;
using Domus.Hydra.Storage.Memory;
using Domus.Hydra.Storage.Records;
using Domus.Hydra.Trigger;

namespace Domus.Hydra.Storage
{
    public interface ITriggerStorage : IStore<TriggerKey, TriggerRecord, MemoryStorageConfiguration>
    {
        TriggerKey Add<T>(T instance) where T : class, ITrigger;
    }
}
