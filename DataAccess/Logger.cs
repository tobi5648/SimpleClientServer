namespace DataAccess
{

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Logger
    {
        private static readonly string Path;

        public static void Log (string message)
        {
            StreamWriter log;

            if (!File.Exists("logfile.txt"))
            {
                log = new StreamWriter("logfile.txt");
            }
            else
            {
                log = File.AppendText("logfile.txt");
            }

            log.WriteLine("Data Time: " + DateTime.Now);

            if (message.Contains("logged"))
            {
                log.WriteLine("CLient: " + message + " has logged on");
            }
            if (message.Contains("Exception"))
            {
                log.WriteLine("Exception Name: " + message);
            }

            log.Close();
        }
    }
}
