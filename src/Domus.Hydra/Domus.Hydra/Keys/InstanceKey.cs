using Domus.Hydra.Utils;

namespace Domus.Hydra.Keys
{
    public record InstanceKey : BaseKey
    {
        public InstanceKey(string name) : base(name)
        {
        }

        private static InstanceKey all = new InstanceKey(Constants.All);

        public static InstanceKey All => all;
    }
}
