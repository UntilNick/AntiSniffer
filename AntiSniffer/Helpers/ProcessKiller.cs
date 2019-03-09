namespace AntiSniffer.Helpers
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    public class ProcessKiller
    {
        public static bool ProcessCompareProductName(Process p, string match)
        {
            try
            {
                return p.MainModule.FileVersionInfo.ProductName.ToLower().Equals(match.ToLower()) ? true : false;
            }
            catch (Win32Exception) { return false; }
            catch (InvalidOperationException) { return false; }
            catch (NullReferenceException) { return false; }
        }

        public static void ClosingCycle(string names, string dnames)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (ProcessCompareProductName(process, names.ToLower()) != process.ProcessName.Contains(dnames))
                {
                    try
                    {
                        process.CloseMainWindow();
                    }
                    catch (InvalidOperationException) { continue; }
                    catch (PlatformNotSupportedException) { break; }
                }
            }
        }
    }
}