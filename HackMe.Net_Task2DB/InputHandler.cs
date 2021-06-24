using System;
using System.Text.RegularExpressions;
using HackMe.

namespace HackMe.Net_Task1
{
    class InputHandler : Tasks
    {

        public static int returncode = 0;

        public InputHandler()
        {

            Tasks tasks = new();
            tasks.TaskInit();

            string compstring = $"kill";
            string command = Console.ReadLine();


            while (command != "qqq")
            {
                command = Console.ReadLine();


                if (command == "exit")
                {
                    returncode = 20;
                    break;
                }

                if (command == "help")
                {
                    tasks.help();
                }

                if (command == "?")
                {
                    tasks.help();
                }

                if (command == "ps")
                {
                    Console.WriteLine("StartPs");
                    tasks.psTask();
                }

                else if (!useKillRegex(command))
                {
                    Console.WriteLine("No chyba nie :v");
                }

                else if (useKillRegex(command))
                {
                    string[] subs = command.Split(" ");
                    
                    var res = Int32.Parse(subs[1]);

                    if (tasks.killTask(res))
                    {
                        returncode = 1;
                        break;
                    }
                    
                    Console.WriteLine("Bledny PID :<");
                }



            }
        }


        public static bool useKillRegex(String input)
        {
            Regex kregex = new Regex("^(Kill) +[\\d]{4}$", RegexOptions.IgnoreCase);

            if (kregex.IsMatch(input))
            {
                Regex pidregex = new Regex(@"[\d]");

                string[] sub = input.Split(' ');

                if (pidregex.IsMatch(sub[1]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
