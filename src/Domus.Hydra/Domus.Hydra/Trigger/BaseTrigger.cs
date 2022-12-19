using Domus.Hydra.Keys;

namespace Domus.Hydra.Trigger
{
    public abstract class BaseTrigger : ITrigger
    {
        public BaseTrigger(JobKey jobKey)
        {
            key = new TriggerKey(jobKey, Name);
        }

        public abstract string Name { get; }
        public TriggerKey Key => key;
        public bool IsEnabled => isEnabled;

        public bool Applicable => throw new NotImplementedException();

        private readonly TriggerKey key;
        private bool isEnabled = true;

        public void SetEnabled(bool value) => isEnabled = value;
    }

    public abstract class BaseTrigger<TConfig> : BaseTrigger
        where TConfig: class, new()
    {
        public BaseTrigger(JobKey jobKey) : base(jobKey)
        {
            config = new TConfig();
        }

        protected TConfig Configuration => config;

        private TConfig config;
    }
}
