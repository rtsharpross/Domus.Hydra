namespace Domus.Hydra.Utils
{
    internal static class Constants
    {
        #region KEY
        public const string KEY_sepatator = ".";
        public const string KEY_open = "[";
        public const string KEY_close = "]";
        //allow '.', '/'
        public readonly static char[] KEY_forbidden_symbols = new char[]
        {
            '<', '>', '(', ')', '{', '}', '[', ']',
            '~', '!', '@', '#', '$', '%', '^', '&',
            '*', '+', '?', '"', '№', ';', '?', '|',
            ':', ';', '_', '=', '\'', '\\'
        };

        public const int KEY_max_length = 150;
        #endregion

        #region Scheduler
        public const string DEFAULT_scheduler_name = "default";
        #endregion
    }
}
