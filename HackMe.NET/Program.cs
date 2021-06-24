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
using System.Runtime.CompilerServices;
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
                string command = Console.ReadLine();


                while (command != "qqq")
                {
                    command = Console.ReadLine();


                    if (command == "exit")
                    {
                        Console.WriteLine("Bye :)");
                        break;
                    }

                    if (command == "help")
                    {
                        Help();
                    }

                    if (command == "?")
                    {
                        Help();
                    }

                    if (command == "Oh My ZSH")
                    {
                        dbTHandler dth = new();
                    }
                }

            }

            private static void Help()
            {
                try
                {
                    Console.WriteLine("List of available commands:" +
                                      "\nhelp - Show this text." +
                                      "\n[magic string] - Start the secret second task" +
                                      "\nexit - Kill Me :<");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
