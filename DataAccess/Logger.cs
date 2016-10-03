namespace DataAccess
{
    using System;
    using System.IO;
    using System.Reflection;

    public static class Logger
    {
        /// <summary>
        /// Gets the path to the logfile.txt
        /// </summary>
        private static readonly string exePath;

        /// <summary>
        /// Generates the log
        /// </summary>
        /// <param name="message"></param>
        public static void LogUserLogin (string message)
        {
            StreamWriter log;

            if (!File.Exists(exePath + "\\" + "logfile.txt"))
            {
                log = new StreamWriter(exePath + "\\" + "logfile.txt");
            }
            else
            {
                log = File.AppendText(exePath + "\\" + "logfile.txt");
            }

            log.Write("Date Time: " + DateTime.Now);
            log.WriteLine(", Client: " + message);
            log.Close();
        }

        public static void LogException(string message)
        {
            StreamWriter log;

            if (!File.Exists(exePath + "\\" + "logfile.txt"))
            {
                log = new StreamWriter(exePath + "\\" + "logfile.txt");
            }
            else
            {
                log = File.AppendText(exePath + "\\" + "logfile.txt");
            }
            log.Write("Date Time: " + DateTime.Now);

            if (message.Contains("logged"))
            {
                log.WriteLine(", Client: " + message);
            }
            if (message.Contains("Exception"))
            {
                log.WriteLine(", Exception Name: " + message);
            }

            log.Close();
        }

        static Logger()
        {
            exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}
