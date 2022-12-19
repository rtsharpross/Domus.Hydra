using Domus.Hydra.Bus;
using Domus.Hydra.Keys;
using Domus.Hydra.Utils;
using System.Collections.Concurrent;

namespace Domus.Hydra.Services
{
    internal abstract class BaseSchedulerEngine : ISchedulerEngine
    {
        public BaseSchedulerEngine(TaskSchedulerConfiguration configuration)
        {
            JobQueue = new ConcurrentQueue<TriggerKey>();
            consumer = new LocalTriggerConsumer(instanceKey, JobQueue);
        }

        public abstract int CurrentConcurrency { get; }
        public bool IsRun
        {
            get
            {
                return cancellationTokenSource != null;
            }
            private set
            {
                if (value)
                {
                    if (cancellationTokenSource == null)
                    {
                        cancellationTokenSource = new CancellationTokenSource();
                    }
                }
                else
                {
                    if(cancellationTokenSource != null)
                    {
                        cancellationTokenSource.Cancel();

                        cancellationTokenSource.Dispose();
                        cancellationTokenSource = null;

                        //GC?
                    }
                }
            }
        }

        public CancellationTokenSource CurrentCTS
        {
            get
            {
                if(cancellationTokenSource == null)
                {
                    ThrowHelper.Throw("Scheduler is stoped.");
                }

                return cancellationTokenSource;
            }
        }

        protected readonly ConcurrentQueue<TriggerKey> JobQueue;
        protected readonly SchedulerContainer Container;

        private CancellationTokenSource? cancellationTokenSource;

        public event EventHandler<EventArgs> OnJob;

        public virtual void Interrupt(bool waite = true)
        {
            if(IsRun)
            {
                IsRun = false;
                InnerInterrupt(waite);
            }
        }

        protected abstract void InnerInterrupt(bool waite);

        public virtual void Start()
        {
            if(!IsRun)
            {
                IsRun = true;

                InnerStarting();
            }
        }

        protected abstract void InnerStarting();

        public void ToQueue(TriggerKey triggerKey)
        {
            if(IsRun)
            {
                JobQueue.Enqueue(triggerKey);
            }
            else
            {
                throw new Exception("Scheduler is stoped.");
            }
        }
    }
}
