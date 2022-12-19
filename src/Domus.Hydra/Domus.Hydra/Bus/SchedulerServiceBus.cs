using Domus.Hydra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domus.Hydra.Bus
{
    internal class SchedulerServiceBus
    {
        public IEnumerable<ITriggerConsumer> Consumers => _consumers;
        public IEnumerable<ITriggerProducer> Produsers => _produsers;

        private List<ITriggerConsumer> _consumers;
        private List<ITriggerProducer> _produsers;

        public void AddConsumer<T>(T consumer)
            where T : class, ITriggerConsumer
        {
            if(consumer == null)
            {
                ThrowHelper.ArgumentNullException(nameof(consumer));
            }

            _consumers.Add(consumer);
        }

        public void AddProducer<T>(T producer)
            where T : class, ITriggerProducer
        {
            producer.OnNotice += GetNotice;
        }

        private void GetNotice(object? sender, ProducerMessageArgs args)
        {
            foreach(var consumer in _consumers) 
            {
                var toSend = args.Triggers.Where(x => x.Trigger == consumer.Key);

                consumer.Notice(toSend);
            }
        }
    }
}
