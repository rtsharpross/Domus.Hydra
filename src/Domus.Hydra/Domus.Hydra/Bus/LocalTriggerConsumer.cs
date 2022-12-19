using Domus.Hydra.Keys;
using System.Collections.Concurrent;

namespace Domus.Hydra.Bus
{
    internal class LocalTriggerConsumer : ITriggerConsumer
    {
        public LocalTriggerConsumer(InstanceKey instanceKey)
        {
            _instanceKey = instanceKey;
        }

        private readonly InstanceKey _instanceKey;

        public InstanceKey Key => _instanceKey;

        public void Notice(IEnumerable<TriggerKeyContextPair> triggerKeys)
        {
            throw new NotImplementedException();
        }
    }
}
