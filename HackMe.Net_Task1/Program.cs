using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace HackMe.Net_Task1
{
    class Program
    {
        static int Main(string[] args)
        {

            
            Console.WriteLine("Hello World!");

            for (var i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"[{i}] = {args[i]}");
            }
            


            /*
            if (args.Length > 0)
            {
                using (PipeStream pipeClient =
                    new AnonymousPipeClientStream(PipeDirection.In, args[0]))
                {
                    Console.WriteLine("[CLIENT] Current TransmissionMode: {0}.",
                        pipeClient.TransmissionMode);

                    using (StreamReader sr = new StreamReader(pipeClient))
                    {
                        // Display the read text to the console
                        string temp;

                        // Wait for 'sync message' from the server.
                        do
                        {
                            Console.WriteLine("[CLIENT] Wait for sync...");
                            temp = sr.ReadLine();
                        }
                        while (!temp.StartsWith("SYNC"));

                        // Read the server data and echo to the console.
                        while ((temp = sr.ReadLine()) != null)
                        {
                            Console.WriteLine("[CLIENT] Echo: " + temp);
                        }
                    }
                }
            }
            Console.Write("[CLIENT] Press Enter to continue...");
            Console.ReadLine();

            
            */



            return 323;
        }
    }
}
