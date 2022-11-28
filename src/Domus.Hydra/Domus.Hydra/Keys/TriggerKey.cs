namespace Domus.Hydra.Keys
{
    public record TriggerKey : BaseKey<JobKey>
    {
        protected TriggerKey(JobKey parent, string name) : base(parent, name)
        {
        }
    }
}
