using System;
using Microsoft.Win32;

namespace HackMe.Net_Task2DB
{
    class LcDb_win
    {
        public static string full_path = "";

        static void list_local_db()
        {
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
            }
        }
    }
}
