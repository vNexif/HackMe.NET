using System;
using System.Collections.Generic;
using System.Threading;



namespace HackMe.Net_Task1
{
    class Tasks : Caesar_Cipher
    {

        List<int> processList = new();
        public int KillListPID;
        //public int KillRealPID;

        public void TaskInit()
        {
            try
            {
                List<Thread> KillMeT = new();
                Random rnd = new();

                KillListPID = rnd.Next(0, 5);


                KillMeT.Add(new Thread(() =>
                {
                    for (var i = 0; i < 5; i++)
                    {
                        var RndPID = rnd.Next(2200, 2400);
                        processList.Add(RndPID);
                    }
                }));

                KillMeT.Add(new Thread(() =>
                {
                    Console.WriteLine("Task Info:");
                    Console.WriteLine("Find the {0} ", Encipher(LetterNumbersMap(processList[KillListPID]), 3));
                }));

                KillMeT[0].Start();
                KillMeT[1].Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public void psTask()
        {
            try
            {
                processList.ForEach(psl => Console.WriteLine("PID: " + psl));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool killTask(Int32 PID)
        {
            try
            {
                if (PID == processList[KillListPID])
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void help()
        {
            try
            {
                Console.WriteLine("List of available commands:" +
                                  "\n\nps - report a snapshot of the current processes\n" +
                                  "kill - terminate a process\n" +
                                  "exit - kill process that runs the game that you're actually playing");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
