using Domus.Hydra.Keys;

namespace Domus.Hydra.Trigger
{
    public sealed class SimpleTrigger: BaseTrigger<SimpleTriggerConfiguration>
    {
        public SimpleTrigger(JobKey jobKey, string name) : base(jobKey)
        {

        }

        public override string Name => name;

        private string name;
    }

    public class SimpleTriggerConfiguration
    {
        public SimpleTriggerConfiguration()
        {
            this.Repeatable = false;
            this.Repeat = 0;
        }

        public bool Repeatable;

        public int Repeat;

        public FireingData Fireing;
    }

    public class FireingData
    {
        public DateTime Next { get; set; }

        public DateTime Previus { get; set; }

        public void SetNext(DateTime next)
        {
            Previus = Next;
            Next = next;
        }
    }
}
