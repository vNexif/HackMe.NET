using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace HackMe.NET
{
    class Program
    {
        class ThreadCreationProgram
        {
            static void Main(string[] args)
            {
                
             
                MultiThreading thrm = new MultiThreading();
             
                thrm.thr1.Start();
                thrm.thr2.Start();


                Process P = new Process();
                
                ProcessStartInfo Task1_StartInfo = new ProcessStartInfo();
                Task1_StartInfo.FileName = "./HackMe.Net_Task1";
                Task1_StartInfo.Arguments = "Hack";
                P.StartInfo = Task1_StartInfo;
                P.Start();
                //P.Threads.AsParallel();
                P.WaitForExit();
                var result = P.ExitCode;
                Console.WriteLine(result);
                

               /* Process pipeClient = new Process();

                pipeClient.StartInfo.FileName = "./HackMe.Net_Task1.exe";

                using (AnonymousPipeServerStream pipeServer =
                    new AnonymousPipeServerStream(PipeDirection.Out,
                        HandleInheritability.Inheritable))
                {
                    Console.WriteLine("[SERVER] Current TransmissionMode: {0}.",
                        pipeServer.TransmissionMode);

                    // Pass the client process a handle to the server.
                    pipeClient.StartInfo.Arguments =
                        pipeServer.GetClientHandleAsString();
                    pipeClient.StartInfo.UseShellExecute = false;
                    pipeClient.WaitForExitAsync();
                    pipeClient.Start();

                    pipeServer.DisposeLocalCopyOfClientHandle();

                    try
                    {
                        // Read user input and send that to the client process.
                        using (StreamWriter sw = new StreamWriter(pipeServer))
                        {
                            sw.AutoFlush = true;
                            // Send a 'sync message' and wait for client to receive it.
                            sw.WriteLine("SYNC");
                            pipeServer.WaitForPipeDrain();
                            // Send the console input to the client process.
                            Console.Write("[SERVER] Enter text: ");
                            sw.WriteLine(Console.ReadLine());
                        }
                    }
                    // Catch the IOException that is raised if the pipe is broken
                    // or disconnected.
                    catch (IOException e)
                    {
                        Console.WriteLine("[SERVER] Error: {0}", e.Message);
                    }
                }

                pipeClient.WaitForExit();
                pipeClient.Close();
                Console.WriteLine("[SERVER] Client quit. Server terminating.");


                Console.ReadKey();
               */
            }
        }
    }
}
