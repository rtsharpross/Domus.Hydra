using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domus.Hydra.Utils
{
    internal static class Constants
    {
        public const string KEY_sepatator = ".";

        public const string KEY_open = "[";
        public const string KEY_close = "]";

        public readonly static char[] KEY_symbols = new char[] 
        {
            '<', '>', '(', ')', '{', '}', '[', ']',
            '~', '!', '@', '#', '$', '%', '^', '&', 
            '*', '+', '?', '"', '№', ';', '?', '|', 
            ':', ';', '_', '=', '\'', '\\' 
        }; //allow '.', '/'
    }
}
