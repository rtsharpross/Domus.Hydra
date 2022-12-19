using Domus.Hydra.Keys;

namespace Domus.Hydra.Services
{
    public interface ISchedulerEngine
    {
        int CurrentConcurrency { get; }

        bool IsRun { get; }

        event EventHandler<EventArgs> OnJob;

        void ToQueue(TriggerKey triggerKey);

        void Interrupt(bool waite = true);

        void Start();
    }
}
