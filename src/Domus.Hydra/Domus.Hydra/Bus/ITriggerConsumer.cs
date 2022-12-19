using Domus.Hydra.Keys;

namespace Domus.Hydra.Bus
{
    /// <summary>
    /// 
    /// </summary>
    internal interface ITriggerConsumer
    {
        InstanceKey Key { get; }

        void Notice(IEnumerable<TriggerKeyContextPair> triggerKeys);
    }
}
