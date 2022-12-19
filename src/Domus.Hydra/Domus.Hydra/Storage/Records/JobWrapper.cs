using Domus.Hydra.Context;
using Domus.Hydra.Job;
using Domus.Hydra.Keys;
using Domus.Hydra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domus.Hydra.Storage.Records
{
    public sealed class JobWrapper
    {
        protected JobWrapper(Lazy<IJob> job, bool isInterruptable)
        {
            job = job;
            this.isInterruptable = isInterruptable;
        }

        public Func<IContext, Task> Execute
        {
            get
            {
                if (job == null)
                {
                    ThrowHelper.Throw("");
                }

                return job.Value.Execute;
            }
        }

        private Lazy<IJob> job;
        private bool isInterruptable;

        public static JobWrapper Build<T>()
            where T : class, IJob, new()
        {
            var isi = typeof(ICanceledJob).IsAssignableFrom(typeof(T));

            var activator = new Lazy<IJob>(() =>
            {
                var instance = new T();

                return instance;
            });

            var wrapper = new JobWrapper(activator, isi);

            return wrapper;
        }

        public bool TryInterrupt()
        {
            throw new NotImplementedException();
        }
    }
}
