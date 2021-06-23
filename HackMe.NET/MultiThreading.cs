using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HackMe.NET
{
    class MultiThreading
    {
        public static void CallToChildThread()
        {
            try
            {
                Console.WriteLine("Child thread starts");

                // do some work, like counting to 10
                for (int counter = 0; counter <= 10; counter++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(counter);
                }

                Console.WriteLine("Child Thread Completed");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }
        }

        public static void method1()
        {

            // It prints numbers from 0 to 10
            for (int I = 0; I <= 10; I++)
            {
                Console.WriteLine("Method1 is : {0}", I);

                // When the value of I is equal to 5 then
                // this method sleeps for 6 seconds
                Thread.Sleep(600);
 
            }
        }

        // static method two

        public static void method2()
        {
            // It prints numbers from 0 to 10
            for (int J = 0; J <= 10; J++)
            {
                Console.WriteLine("Method2 is : {0}", J);
                Thread.Sleep(200);
            }
        }

        public int maxIterations;

        public MultiThreading()
        {

        }

        public MultiThreading(int maxIterations)
        {
            this.maxIterations = maxIterations;
        }

        public void RunLoop()
        {
            for (int i = 0; i < maxIterations; i++)
            {
                Console.WriteLine("{0} count: {1}",
                    Thread.CurrentThread.IsBackground ?
                        "Background Thread" : "Foreground Thread", i);
                Thread.Sleep(250);
            }
            Console.WriteLine("{0} finished counting.",
                Thread.CurrentThread.IsBackground ?
                    "Background Thread" : "Foreground Thread");
        }




        public Thread thr1 = new Thread(method1);
        public Thread thr2 = new Thread(method2);
        public Thread thr3 = new Thread(method1);
    }
}
