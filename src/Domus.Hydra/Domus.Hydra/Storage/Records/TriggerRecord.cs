using Domus.Hydra.Keys;
using Domus.Hydra.Trigger;

namespace Domus.Hydra.Storage.Records
{
    public sealed class TriggerRecord
    {
        public TriggerRecord(ITrigger trigger)
        {
            Key = trigger.Key;
        }

        public readonly TriggerKey Key;
    }
}
