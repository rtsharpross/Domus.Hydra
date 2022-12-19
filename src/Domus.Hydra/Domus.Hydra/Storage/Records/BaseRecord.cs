using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domus.Hydra.Storage.Records
{
    public class BaseRecord<T>
    {
        public BaseRecord(T key)
        {

        }

        public readonly T Key;
    }
}
