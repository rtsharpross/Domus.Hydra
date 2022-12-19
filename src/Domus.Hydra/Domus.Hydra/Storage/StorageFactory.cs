using Domus.Hydra.Keys;
using Domus.Hydra.Storage.Memory;

namespace Domus.Hydra.Storage
{
    internal class StorageFactory
    {
        public IJobStorage GetJobStorage(InstanceKey instanceKey, IStorageConfiguration storageConfiguration)
        {
            if (instanceKey == null)
            {
                throw new ArgumentNullException(nameof(instanceKey));
            }

            if (storageConfiguration == null)
            {
                throw new ArgumentNullException(nameof(storageConfiguration));
            }

            return new JobMemoryStorage(instanceKey);
        }

        public ITriggerStorage GetTriggerStorage(IStorageConfiguration storageConfiguration)
        {
            return null;
        }
    }
}
