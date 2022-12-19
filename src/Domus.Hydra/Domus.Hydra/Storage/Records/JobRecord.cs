using Domus.Hydra.Keys;

namespace Domus.Hydra.Storage.Records
{
    public sealed class JobRecord
    {
        public JobRecord(JobKey jobKey)
        {
            Key = jobKey;
        }

        public readonly JobKey Key;
        public bool InProgeress
        {
            get
            {
                return inProgress;
            }
            private set
            {
                lock (lockObj)
                {
                    inProgress = value;
                }
            }
        }
        public readonly JobWrapper Wrapper;
        public readonly JobConfig Configuration;
        
        private readonly object lockObj = new object();
        private bool inProgress;

        public void Waite()
        {
            InProgeress = true;
        }

        public void Release()
        {
            InProgeress = false;
        }
    }
}
