namespace Domus.Hydra.Keys
{
    public record class JobKey : BaseKey<InstanceKey>, IEquatable<InstanceKey>
    {
        public JobKey(InstanceKey parent, string name) : base(parent, name)
        {
        }

        public bool Equals(InstanceKey? other)
        {
            return Parent == other;
        }
    }
}
