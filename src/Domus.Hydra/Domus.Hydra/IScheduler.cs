using Domus.Hydra.Context;
using Domus.Hydra.Job;
using Domus.Hydra.Keys;
using Domus.Hydra.Services;

namespace Domus.Hydra
{
    public interface IScheduler
    {
        int ConcurrencyLevel { get; }

        JobFacade Jobs { get; }

        TriggerFacade Triggers { get; }

        void Run(JobKey jobKey, IContext? context = null);

        void Run(IEnumerable<JobKey> jobKeys);
    }
}