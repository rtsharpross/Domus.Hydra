using Domus.Hydra.Bus;
using Domus.Hydra.Storage;

namespace Domus.Hydra.Services
{
    internal static class Global
    {
        private static readonly Dictionary<string, IScheduler> _schedulers;
        private static readonly SchedulerServiceBus schedulerBus = new SchedulerServiceBus();
        private static readonly StorageFactory storageFactory = new StorageFactory();

        public static IScheduler Create(SchedulerConfiguration configuration)
        {
            if(_schedulers.ContainsKey(configuration.Name))
            {
                throw new Exception("Allready exists");
            }

            var container = new SchedulerContainer(configuration.TaskScheduler, configuration.StorageConfiguration);
            container.Initialize();

            var scheduler = new HydraScheduler(container, configuration);
            scheduler.Bind(schedulerBus);

            return scheduler;
        }

        public static IScheduler Get(string name)
        {
            if(!_schedulers.ContainsKey(name))
            {
                throw new Exception("Scheduler not found");
            }

            return _schedulers[name];
        }
    }
}
