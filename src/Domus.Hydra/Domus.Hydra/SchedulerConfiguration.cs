using Domus.Hydra.Storage;
using Domus.Hydra.Utils;

namespace Domus.Hydra
{
    public class SchedulerConfiguration
    {
        public SchedulerConfiguration()
        {
            
        }

        public TaskScheduler TaskScheduler;

        public int ConccurencyLevel;

        public string Name;

        public IStorageConfiguration StorageConfiguration;

        private static readonly SchedulerConfiguration defaultConfiguration = new SchedulerConfiguration()
        {
            ConccurencyLevel = 4,
            Name = Constants.DEFAULT_scheduler_name,
            TaskScheduler = TaskScheduler.Current,
            StorageConfiguration = new MemmoryStorageConfiguration()
        };

        public static SchedulerConfiguration Default => defaultConfiguration;
    }
}
