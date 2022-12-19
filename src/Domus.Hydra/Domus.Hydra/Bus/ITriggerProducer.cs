using Domus.Hydra.Keys;

namespace Domus.Hydra.Bus
{
    public interface ITriggerProducer
    {
        event EventHandler<ProducerMessageArgs> OnNotice;

        public void Send(IEnumerable<TriggerKeyContextPair> triggerKeyContextPairs);
    }

    public class ProducerMessageArgs : EventArgs
    {
        public ProducerMessageArgs(InstanceKey instanceKey, IEnumerable<TriggerKeyContextPair> triggers)
        {
            Source = instanceKey;
            Triggers = triggers;
        }

        public InstanceKey Source { get; }

        public IEnumerable<TriggerKeyContextPair> Triggers { get; }
    }
}
