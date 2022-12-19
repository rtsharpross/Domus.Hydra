using Domus.Hydra.Context;
using Domus.Hydra.Keys;

namespace Domus.Hydra
{
    public sealed class TriggerKeyContextPair
    {
        protected TriggerKeyContextPair(TriggerKey triggerKey, IContext? context = null)
        {
            Trigger = triggerKey;
            Context = context;
        }

        public readonly TriggerKey Trigger;

        public readonly IContext? Context;

        public static IEnumerable<TriggerKeyContextPair> Build(JobKey jobKey, IContext? context = null)
        {
            return new [] { new TriggerKeyContextPair(jobKey, context) };
        }

        public static IEnumerable<TriggerKeyContextPair> Build(IEnumerable<TriggerKey> triggers)
        {
            var result = new TriggerKeyContextPair[triggers.Count()];
            int index = -1;

            foreach ( var trigger in triggers) 
            {
                result[index++] = new TriggerKeyContextPair(trigger);
            }

            return result;
        }
    }
}
