using Domus.Hydra.Storage;
using Microsoft.Extensions.Logging;

namespace Domus.Hydra.Services
{
    internal sealed class SchedulerContainer
    {
        public SchedulerContainer(TaskScheduler taskScheduler, IStorageConfiguration storageConfiguration)
        {
            this.taskScheduler = taskScheduler;
        }

        public IJobStorage JobStorage => jobStorage;
        public ITriggerStorage TriggerStorage => triggerStorage;
        public int TaskDelay = 5;
        public TaskScheduler TaskScheduler => taskScheduler;

        private readonly IJobStorage jobStorage;
        private readonly ITriggerStorage triggerStorage;
        private readonly TaskScheduler taskScheduler;

        private ILoggerFactory loggerFactory;

        public void Initialize()
        {
            JobStorage.Initialize();
            TriggerStorage.Initialize();
        }
    }
}
