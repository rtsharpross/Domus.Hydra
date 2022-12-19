using Domus.Hydra.Context;

namespace Domus.Hydra.Storage.Records
{
    [Serializable]
    public sealed class JobConfig
    {
        public JobConfig()
        {
        }

        /// <summary>
        /// Allow execute task
        /// Default: TRUE
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Allow write in logger
        /// Default: false
        /// </summary>
        public bool Logging { get; set; } = false;

        /// <summary>
        /// Allow multiple runs
        /// Default: false
        /// </summary>
        public bool MultipleExecution { get; set; } = false;

        public IContext Context { get; }
    }
}
