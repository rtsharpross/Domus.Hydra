using Domus.Hydra.Keys;
using System.Diagnostics.CodeAnalysis;

namespace Domus.Hydra.Utils
{
    internal static class ThrowHelper
    {
        [DoesNotReturn]
        public static void Throw(string message) => new Exception(message);

        [DoesNotReturn]
        public static void ArgumentNull(string argumentName) => new ArgumentNullException(argumentName);

        #region Key
        [DoesNotReturn]
        public static void InvalidKeyName(string value) => Throw(value);

        [DoesNotReturn]
        public static void InvalidKeyNameLength(string value) => Throw(value);

        [DoesNotReturn]
        public static void HasForbiddenSymbols(string value) => Throw(value);

        public static void JobNotFound(JobKey jobKey) => Throw($"Job by key '{jobKey.ToString()}' not found.");
        #endregion
    }
}
