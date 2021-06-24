using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HackMe.NET
{
    class dbTHandler
    {
        public dbTHandler()
        {
            try
            {
                List<Thread> dbThreads = new()
                {
                    new Thread(() =>
                    {
                        var slotData = Base64Encode("No i koniec ;)");
                        var threadId = Thread.CurrentThread.ManagedThreadId;

                        Thread.SetData(Thread.GetNamedDataSlot("Enc"), slotData);

                        Thread.CurrentThread.Name = "dbStart";
                        using Process dbProcess = new();

                        dbProcess.StartInfo.UseShellExecute = false;
                        dbProcess.StartInfo.FileName = "./HackMe.Net_Task2DB";
                        dbProcess.StartInfo.CreateNoWindow = false;

                        Thread.Sleep(100);

                        dbProcess.Start();
                        dbProcess.WaitForExit();

                        Console.WriteLine(dbProcess.ExitCode);


                        if (dbProcess.ExitCode == 20)
                        {
                            Console.WriteLine((string) Thread.GetData(Thread.GetNamedDataSlot("Enc")));
                        }
                        else if (dbProcess.ExitCode == 1)
                        {
                            Console.WriteLine(Base64Decode((string) Thread.GetData(Thread.GetNamedDataSlot("Enc"))));
                        }
                    })
                };


                dbThreads[0].Start();
                
                dbThreads[0].Join();
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
