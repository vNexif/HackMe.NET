using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;
using System.ComponentModel;
using ThreadState = System.Threading.ThreadState;

namespace HackMe.NET
{
    class Program
    {
        class ThreadCreationProgram
        {
            static void Main(string[] args)
            {

                killMeHandler kmh = new();
                Console.ReadKey();

            }
        }
    }
}
