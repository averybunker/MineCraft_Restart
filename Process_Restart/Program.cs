using System;
using System.Diagnostics;

namespace Process_Restart
{
    class Program
    {
        static Boolean amIrunning = false;

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ListProcesses();
			if (amIrunning == false)
			{
                Console.WriteLine(RunCommand());
			}
        }

		static void ListProcesses()
		{
            
			Process[] processCollection = Process.GetProcesses();
			foreach (Process p in processCollection)
			{
				Console.WriteLine(p.ProcessName);

                if(p.ProcessName == "java")
                {
                    amIrunning = true;
                }
			}
            Console.WriteLine(amIrunning.ToString());

		}

		public static bool RunCommand()
		{
			try
			{
				var procStartInfo = new ProcessStartInfo("c:\\Users\\Administrator\\Desktop\\Modded Minecraft Server\\Server_Modded.bat")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
					CreateNoWindow = false,
				};

				var proc = new Process { StartInfo = procStartInfo };
				proc.Start();

				// Get the output into a string
				var output = proc.StandardOutput.ReadToEnd();

                try
                {
                    return proc.ExitCode == decimal.Zero ? true : false;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }

			}
			finally
			{
				// do something
			}
		}
    }
}
