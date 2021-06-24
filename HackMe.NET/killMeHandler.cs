using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HackMe.NET
{
    class killMeHandler
    {
        public killMeHandler()
        {
            try
            {
                
                List<Thread> killMeThreads = new();

                killMeThreads.Add(new Thread(() =>
                {
                    var slotData = Base64Encode("Aby uruchomic drugie zadanie wpisz 'Oh My ZSH'");
                    //var threadId = Thread.CurrentThread.ManagedThreadId;

                    Thread.SetData(Thread.GetNamedDataSlot("Enc"),slotData);

                    Thread.CurrentThread.Name = "killMeTask";
                    using Process killMe = new();
                    killMe.StartInfo.UseShellExecute = false;
                    killMe.StartInfo.FileName = "./HackMe.Net_Task1";
                    killMe.StartInfo.CreateNoWindow = false;
                    
                    Thread.Sleep(69);

                    killMe.Start();


                    killMe.WaitForExit();

                    if (killMe.ExitCode == 20)
                    {
                        Console.WriteLine((string)Thread.GetData(Thread.GetNamedDataSlot("Enc")));
                    }
                    else if (killMe.ExitCode == 1)
                    {
                        Console.WriteLine(Base64Decode((string) Thread.GetData(Thread.GetNamedDataSlot("Enc"))));
                    }
                }));

                
                killMeThreads[0].Start();
                killMeThreads[0].Join();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}
