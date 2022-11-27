namespace Domus.Hydra.Keys
{
    public record class JobKey : BaseKey<InstanceKey>
    {
        public JobKey(InstanceKey parent, string name) : base(parent, name)
        {
        }
    }
}
