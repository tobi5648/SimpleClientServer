using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void LogClientLogIn()
        {
            //  Arrange
            string message = "Mads has logged on";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string readLogMessage = string.Empty;

            //  Act
            DateTime test = DateTime.Now;
            Logger.LogUserLogin(message);

            StreamReader reader = new StreamReader(path + "\\" + "logfile.txt");

            List<string> readLog = new List<string>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                readLog.Add(line);
            }


            //readLogMessage = Convert.ToString(reader.Read());
            //if (readLogMessage.Contains(message))
            //{
            //    Assert.AreEqual(message, reader.ReadLine());
            //}
            //else
            //{
            //    throw new Exception();
            //}

            Assert.AreEqual("Date Time: " + test + ", Client: " + message, readLog.Last());
        }

        [TestMethod]
        public void LogException()
        {
            //  Arrange
            string message = "ArgumentException";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string readLogMessage = string.Empty;

            //  Act
            DateTime test = DateTime.Now;
            Logger.LogException(message);

            StreamReader reader = new StreamReader(path + "\\" + "logfile.txt");

            List<string> readLog = new List<string>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                readLog.Add(line);
            }


            //readLogMessage = Convert.ToString(reader.Read());
            //if (readLogMessage.Contains(message))
            //{
            //    Assert.AreEqual(message, reader.ReadLine());
            //}
            //else
            //{
            //    throw new Exception();
            //}

            Assert.AreEqual("Date Time: " + test + ", Exception Name: " + message, readLog.Last());
        }
    }
}
