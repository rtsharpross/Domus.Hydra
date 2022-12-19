using Domus.Hydra.Bus;
using Domus.Hydra.Context;
using Domus.Hydra.Keys;
using Domus.Hydra.Services;
using Domus.Hydra.Trigger;

namespace Domus.Hydra
{
    internal sealed class HydraScheduler : IScheduler
    {
        public HydraScheduler(SchedulerContainer container, SchedulerConfiguration configuration)
        {
            instanceKey = new InstanceKey(configuration.Name);
            engine = new TaskSchedulerEngine(configuration);
            producer = new LocalTriggerProducer(instanceKey);
        }

        public string Name => instanceKey.ToString();
        public int ConcurrencyLevel => engine.CurrentConcurrency;
        public bool IsRunning => engine.IsRun;

        private readonly InstanceKey instanceKey;
        private readonly LocalTriggerProducer producer;
        private readonly ISchedulerEngine engine;

        /*public void AddConsumer<T>(T consumer) where T : ITriggerConsumer
        {
            throw new NotImplementedException();
        }*/

        public void Run(JobKey jobKey, IContext? context = null) => producer.Send(TriggerKeyContextPair.Build());

        public void Run(IEnumerable<JobKey> jobKeys)
        {
            var triggers = new List<TriggerKey>();

            foreach(var jobKey in jobKeys)
            {
                triggers.Add(new RequestedTrigger(jobKey));
            }
        }

        public void Start() => engine.Start();

        public void Stop() => engine.Interrupt();

        public void Bind(SchedulerServiceBus serviceBus)
        {
            serviceBus.AddProducer(producer);
        }

        public void Unbind(SchedulerServiceBus serviceBus)
        {
            serviceBus.AddProducer(producer);
            //serviceBus.AddConsumer(engine.Consumer);
        }
    }
}
