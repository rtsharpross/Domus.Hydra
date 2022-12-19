using Domus.Hydra.Keys;

namespace Domus.Hydra.Trigger
{
    public interface ITrigger
    {
        TriggerKey Key { get; }

        /// <summary>
        /// Вкл/Выкл
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// 
        /// </summary>
        /*bool Applicable { get; }*/
    }
}
