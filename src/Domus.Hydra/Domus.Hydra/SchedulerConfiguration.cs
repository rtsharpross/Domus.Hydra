using Domus.Hydra.Utils;

namespace Domus.Hydra
{
    public class SchedulerConfiguration
    {
        public SchedulerConfiguration()
        {
            this.TaskScheduler = TaskScheduler.Current;
            this.ConccurencyLevel = 0;
            this.Name = Constants.DEFAULT_scheduler_name;
        }

        public readonly TaskScheduler TaskScheduler;

        public readonly int ConccurencyLevel;

        public readonly string Name;
    }
}
