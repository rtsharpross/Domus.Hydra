using Domus.Hydra.Keys;

namespace Domus.Hydra.Bus
{
    internal class LocalTriggerProducer : ITriggerProducer
    {
        public LocalTriggerProducer(InstanceKey instanceKey)
        {
            this.instanceKey = instanceKey;
        }

        public event EventHandler<ProducerMessageArgs> OnNotice;

        private readonly InstanceKey instanceKey;

        public void Send(IEnumerable<TriggerKeyContextPair> triggerKeyContextPairs) 
            => OnNotice?.Invoke(this, new ProducerMessageArgs(instanceKey, triggerKeyContextPairs));
    }
}
