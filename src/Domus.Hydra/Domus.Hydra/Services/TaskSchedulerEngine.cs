using Domus.Hydra.Context;
using Domus.Hydra.Keys;
using Domus.Hydra.Storage.Records;
using Domus.Hydra.Utils;
using System.Collections.Concurrent;

namespace Domus.Hydra.Services
{
    internal class TaskSchedulerEngine : BaseSchedulerEngine
    {
        public TaskSchedulerEngine(TaskSchedulerConfiguration configuration) : base(configuration)
        {
            semaphoreSlim = new SemaphoreSlim(configuration.ConcurrencyLevel);
        }

        public override int CurrentConcurrency => jobsInProgres.Count;

        private ConcurrentDictionary<JobKey, JobRecord> jobsInProgres = new ConcurrentDictionary<JobKey, JobRecord>();
        private readonly SemaphoreSlim semaphoreSlim;

        protected override void InnerStarting()
        {
            var task = new Task(InnerExecution);
            task.ConfigureAwait(false);

            task.Start(TaskScheduler.Current);
        }

        protected override void InnerInterrupt(bool waite)
        {
            if(!waite)
            {
                foreach (var record in jobsInProgres.Values)
                {
                    if(!record.Wrapper.TryInterrupt())
                    {
                        //log
                    }
                }
            }
        }

        private void InnerExecution()
        {
            while(!CurrentCTS.IsCancellationRequested)
            {
                for (var i = 0; i < JobQueue.Count; i++)
                {
                    if (JobQueue.TryDequeue(out var triggerKey))
                    {
                        var record = Container.JobStorage[triggerKey.Parent];

                        if (record.Configuration.Enabled)
                        {
                            var jobTask = BuildTask(record, triggerKey);
                            jobTask.Start(Container.TaskScheduler);
                        }
                    }
                }
                
                CurrentCTS.Token.ThrowIfCancellationRequested();

                Task.Delay(TimeSpan.FromMilliseconds(Container.TaskDelay));
            }
        }

        private Task BuildTask(JobRecord jobRecord, TriggerKey triggerKey)
        {
            var context = MergeJobConextWithTriggerContext(jobRecord.Configuration.Context, triggerKey);
            MarkJobAsWork(jobRecord);

            var task = new Task(async () => 
            {
                try
                {
                    await jobRecord.Wrapper.Execute(context).ConfigureAwait(false);
                }
                finally
                {
                    MarkJobAsFinish(jobRecord);
                }
            }, CancellationToken.None);

            task.ConfigureAwait(false);

            return task;
        }

        private IContext MergeJobConextWithTriggerContext(IContext jobContext, TriggerKey triggerKey)
        {
            return null;
        }

        private void MarkJobAsWork(JobRecord record)
        {
            record.Waite();
            semaphoreSlim.Wait();

            if(!jobsInProgres.TryAdd(record.Key, record))
            {
                ThrowHelper.Throw("Hmmmm");
            }
        }

        private void MarkJobAsFinish(JobRecord record)
        {
            record.Release();

            if (!jobsInProgres.TryRemove(record.Key, out var a))
            {
                ThrowHelper.Throw("Hmmmm");
            }
        }
    }

    internal class TaskSchedulerConfiguration
    {
        public int ConcurrencyLevel { get; set; }
    }
}
