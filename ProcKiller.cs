using System.Diagnostics;

namespace Protections
{
    internal class ProcKiller
    {
        public static void ProcessKiller()
        {
            Console.Title = "test"; // Delete this

            new Thread(() =>
            {
                while (true)
                {
                    string[] processName = { "Hacker", "Spy", "Engine", "Dumper", "OllyDbg",
                        "HxD", "dotPeek", "Reflector", "HttpDebug",
                        "debug", "WireShark", "HTTP Toolkit", "IDA",
                        "scylla", "dbg", "fiddler", "Detect It Easy", "die" };

                    Process[] processlist = Process.GetProcesses();
                    foreach (Process theprocess in processlist)
                    {
                        foreach (string s in processName)
                        {
                            if (theprocess.ProcessName.ToLower().Contains(s.ToLower()))
                            {
                                try
                                {
                                    Console.WriteLine($"Killed \"{theprocess.ProcessName}\" by Process Name"); // Delete this
                                    theprocess.Kill();
                                }
                                catch
                                {
                                    Environment.Exit(0);
                                    Environment.FailFast("Debugger Detected");
                                }
                            }
                        }
                    }

                    foreach (Process eachProcessInList in processlist)
                    {
                        foreach (string i in processName)
                        {
                            if (eachProcessInList.MainWindowTitle.ToLower().Contains(i.ToLower()))
                            {
                                try
                                {
                                    Console.WriteLine($"Killed \"{eachProcessInList.MainWindowTitle}\" by window title"); // Delete this
                                    eachProcessInList.Kill();
                                }
                                catch
                                {
                                    Environment.Exit(0);
                                    Environment.FailFast("Debugger Detected");
                                }
                            }
                        }
                    }

                    Thread.Sleep(2000);
                }
            }).Start();
        }
    }
}
