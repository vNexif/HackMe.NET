using System;
using System.Threading;
using Microsoft.Win32;

namespace HackMe.Net_Task2DB
{
    class LcDb_win
    {
        public static string full_path = "";
        public static string localhost = "";

        public void LcDb_winT()
        {
            {
                try
                {
                    
                    Thread get_path = new Thread(() =>
                    {
                        RegistryView registryView =
                            Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
                        using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                        {
                            RegistryKey instanceKey =
                                hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                            if (instanceKey != null)
                            {
                                foreach (var instanceName in instanceKey.GetValueNames())
                                {
                                    full_path = Environment.MachineName + @"\" + instanceName;
                                }
                            }
                        }
                    });

                    Thread get_splitted = new Thread(() =>
                    {
                        Thread.Sleep(100);
                        string[] subs = full_path.Split("\\");
                        localhost = subs[0];

                    });
                    
                    get_path.Start();
                    get_splitted.Start();

                    get_path.Join();
                    get_splitted.Join();
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
