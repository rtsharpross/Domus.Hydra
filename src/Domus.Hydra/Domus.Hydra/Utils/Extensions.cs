using System.Linq;

namespace Domus.Hydra.Utils
{
    internal static class Extensions
    {
        public static bool HasForbiddenSymbols(this string value)
        {
            for (var i = 0; i < Constants.KEY_forbidden_symbols.Length; i++) 
            {
                if (value.Contains(Constants.KEY_forbidden_symbols[i]))
                {
                    ThrowHelper.InvalidKeyName(value);
                }
            }

            return true;
        }
    }
}
