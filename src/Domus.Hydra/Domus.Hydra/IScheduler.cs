using Domus.Hydra.Bus;
using Domus.Hydra.Context;
using Domus.Hydra.Keys;
using Domus.Hydra.Services;

namespace Domus.Hydra
{
    public interface IScheduler
    {
        string Name { get; }

        int ConcurrencyLevel { get; }

        bool IsRunning { get; }

        void Stop();
        void Start();

        void Run(JobKey jobKey, IContext? context = null);
        void Run(IEnumerable<JobKey> jobKeys);

        //void AddConsumer<T>(T consumer) where T : ITriggerConsumer;
    }
}