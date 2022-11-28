using Domus.Hydra.Job;
using Domus.Hydra.Keys;

namespace Domus.Hydra.Services
{
    public sealed class JobFacade
    {
        public JobKey Add<T>(string name) where T : class, IJob, new()
        {
            return default;
        }

        public void Remove(JobKey jobKey)
        {

        }

        public void Configure(JobKey jobKey, Action<JobConfig> configureAction)
        {

        }
    }
}
