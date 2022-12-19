using Domus.Hydra.Services;
using Domus.Hydra.Storage;
using Domus.Hydra.Storage.Memory;

using Microsoft.Extensions.Logging;

namespace Domus.Hydra
{
    public sealed class SchedulerBuilder
    {
        private IStorageConfiguration storageConfiguration;
        private TaskScheduler taskScheduler;
        private string name;
        private int concurencyLevel;
        private ILoggerFactory loggerFactory;

        public void New(string name)
        {
            this.name = name;

            this.taskScheduler = SchedulerConfiguration.Default.TaskScheduler;
            this.storageConfiguration = SchedulerConfiguration.Default.StorageConfiguration;
            this.concurencyLevel = SchedulerConfiguration.Default.ConccurencyLevel;
        }

        public void UseTaskScheduler(TaskScheduler taskScheduler)
        {
            this.taskScheduler = taskScheduler;
        }

        public void SetConcurencyLevel(int level)
        {
            concurencyLevel = level;
        }

        #region storage
        public void UseMemmoryStorage()
        {
            storageConfiguration = new MemoryStorageConfiguration();
        }
        #endregion

        public void SetLoggerFactory(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public IScheduler Build()
        {
            var scheduler = Global.Create(new SchedulerConfiguration()
            {
                Name = name,
                ConccurencyLevel = this.concurencyLevel,
                StorageConfiguration = this.storageConfiguration,
                TaskScheduler = this.taskScheduler
            });

            return scheduler;
        }
    }
}
