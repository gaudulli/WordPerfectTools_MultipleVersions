using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;






namespace WP_PS_Tools
{
    public static class FileUtilities
    {


        public static int getWPVersion()
        {
            List<string> installedPrograms = InstalledPrograms.GetInstalledPrograms();
            List<string> WPPrograms = new List<string>();
            foreach (string program in installedPrograms)
            {
                if (program.Contains("WordPerfect Office X")
                    && !program.Contains("SDK"))
                {
                    WPPrograms.Add(program);
                }
            }
            
            int version = 0;
            foreach(string s in WPPrograms)
            {
                int currentVersion = Convert.ToInt32( Regex.Match(s, @"\d+").Value) + 10;
                if (currentVersion > version)
                {
                    version = currentVersion;
                }
            }
            return version;
        }



        public static class InstalledPrograms
        {
            const string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";



            public static List<string> GetInstalledPrograms()
            {
                var result = new List<string>();
                result.AddRange(GetInstalledProgramsFromRegistry(RegistryView.Registry32));
                result.AddRange(GetInstalledProgramsFromRegistry(RegistryView.Registry64));
                return result;
            }

            private static IEnumerable<string> GetInstalledProgramsFromRegistry(RegistryView registryView)
            {
                var result = new List<string>();

                using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView).OpenSubKey(registry_key))
                {
                    foreach (string subkey_name in key.GetSubKeyNames())
                    {
                        using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                        {
                            if (IsProgramVisible(subkey))
                            {
                                result.Add((string)subkey.GetValue("DisplayName"));
                            }
                        }
                    }
                }

                return result;
            }

            private static bool IsProgramVisible(RegistryKey subkey)
            {
                var name = (string)subkey.GetValue("DisplayName");
                var releaseType = (string)subkey.GetValue("ReleaseType");
                //var unistallString = (string)subkey.GetValue("UninstallString");
                var systemComponent = subkey.GetValue("SystemComponent");
                var parentName = (string)subkey.GetValue("ParentDisplayName");

                return
                    !string.IsNullOrEmpty(name)
                    && string.IsNullOrEmpty(releaseType)
                    && string.IsNullOrEmpty(parentName)
                    && (systemComponent == null);
            }
        }

        public static int getNumWPInstances(int WPversion)
        {
            Process[] p = Process.GetProcessesByName("wpwin" + WPversion.ToString());
            return p.Length;
        }



    }
}
