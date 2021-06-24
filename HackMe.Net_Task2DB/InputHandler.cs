using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HackMe.Net_Task2DB;

namespace HackMe.Net_Task1
{
    class InputHandler : DB_task
    {

        public static int returncode = 0;
        public static bool verify_con = false;

        public InputHandler()
        {
            string command = Console.ReadLine();

            while (command != "qqq")
            {
                command = Console.ReadLine();

                if (command == "show_servers")
                {
                    LcDb_win serv_names = new();
                    Task getPath = Task.Factory.StartNew((() => serv_names.LcDb_winT()));
                    Task.WaitAll(getPath);
                    Console.WriteLine(LcDb_win.localhost);
                }

                if (command == "help")
                {
                    help();
                }

                if (command == "connect")
                {
                    Console.WriteLine("\nInput your localhost SQL server:");
                    string check = Console.ReadLine();
                    if (useConnectRegex(check))
                    {
                        if (check == LcDb_win.localhost)
                        {
                            verify_con = true;
                            Console.WriteLine("\nConnected to database\n");
                        }
                        else
                        {
                            Console.WriteLine("Bledna nazwa localhosta.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bledna nazwa localhosta.");
                    }
                }

                if (command == "show_records" && verify_con)
                {
                    Task sh_rec = Task.Factory.StartNew(() => connect_to_db(LcDb_win.full_path));
                    Task.WaitAll(sh_rec);
                    Console.WriteLine(DB_task.data_db);
                    Console.WriteLine("Name the method of encryption that has been used at line above:");
                    string answer = Console.ReadLine();

                    if (answer == "MD5" || answer == "md5" || answer == "mdfive")
                    {
                        Console.WriteLine("\n\n*** Ukonczyles gierke, gratki! ***\n\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately not :/");
                    }

                }

            }
        }


        public static bool useConnectRegex(String input)
        {
            Regex con_regex = new Regex("^[A-Z,a-z,0-9]*$", RegexOptions.IgnoreCase);

            if (con_regex.IsMatch(input))
            {
                return true;
            }

            return false;

        }
    }
}
