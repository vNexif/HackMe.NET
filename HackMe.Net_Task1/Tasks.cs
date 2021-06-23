using System;
using System.Collections.Generic;
using System.Threading;



namespace HackMe.Net_Task1
{
    class Tasks : Caesar_Cipher
    {

        List<int> processList = new();
        public int KillListPID;
        public int KillRealPID;

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

        public void killTask(string PID)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void help()
        {

        }
    }
}
