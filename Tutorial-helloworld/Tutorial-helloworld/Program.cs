using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Debug information on Console, System.IO
            Console.WriteLine("Hollo World, by Console");
            // Debug information on Output(Debug), System.Diagnostics
            Trace.WriteLine("Hollo World, by Trace");
        }
    }
}
