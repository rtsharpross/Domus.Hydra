namespace Domus.Hydra.Keys
{
    public record TriggerKey : BaseKey<JobKey>, IEquatable<InstanceKey>, IEquatable<JobKey>
    {
        public TriggerKey(JobKey parent, string name) : base(parent, name)
        {
        }

        public bool Equals(JobKey? other)
        {
            return this.Parent == other;
        }

        public bool Equals(InstanceKey? other)
        {
            return Parent.Equals(other);
        }
    }
}
