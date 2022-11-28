using Domus.Hydra.Keys;
using Domus.Hydra.Trigger;

namespace Domus.Hydra.Services
{
    public sealed class TriggerFacade
    {
        public TriggerKey Add<T>(T instance, string name) where T : class, ITrigger, new() => default;

        public void Remove(TriggerKey triggerKey) { }
    }
}
