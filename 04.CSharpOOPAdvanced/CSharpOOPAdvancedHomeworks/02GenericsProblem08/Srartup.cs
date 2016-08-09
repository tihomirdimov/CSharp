using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02GenericsProblem08
{
    class Srartup
    {
        public class CustomList<T>
            where T : IComparable<T>
        {
        }
        static void Main()
        {
        }
    }
}
