using Domus.Hydra.Keys;

namespace Domus.Hydra.Trigger
{
    internal class RequestedTrigger : BaseTrigger
    {
        public RequestedTrigger(JobKey jobKey) : base(jobKey)
        {
        }

        public override string Name => nameof(RequestedTrigger);
    }
}
