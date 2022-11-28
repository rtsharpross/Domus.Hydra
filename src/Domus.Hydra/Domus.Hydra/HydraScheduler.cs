using Domus.Hydra.Context;
using Domus.Hydra.Keys;
using Domus.Hydra.Services;

namespace Domus.Hydra
{
    public sealed class HydraScheduler : IScheduler
    {
        public HydraScheduler(SchedulerConfiguration configuration)
        {
            Jobs = new JobFacade();
            Triggers = new TriggerFacade();
        }

        private readonly int _concurrencyLevel;
        public int ConcurrencyLevel => _concurrencyLevel;

        public JobFacade Jobs { get; }

        public TriggerFacade Triggers { get; }

        public void Run(JobKey jobKey, IContext? context = null)
        {
            
        }

        public void Run(IEnumerable<JobKey> jobKeys)
        {
            
        }
    }
}
