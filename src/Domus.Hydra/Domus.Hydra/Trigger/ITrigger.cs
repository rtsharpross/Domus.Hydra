using Domus.Hydra.Keys;

namespace Domus.Hydra.Trigger
{
    public interface ITrigger
    {
        TriggerKey Key { get; }

        bool Enabled { get; }

        bool Applicable { get; }
    }
}
