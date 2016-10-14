namespace Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;
    using System.Net.Sockets;
    using Networking;
    using System.Net;
    using System.Threading;

    public class LogOnController
    {
        const int loginPort = 1000;

        private string username;
        private string password;
        public static string id;
        public static Socket masterLogin;
        string messahe;

        public LogOnController (out string message, string username, string password)
        {
            try
            {
                this.username = username;
                this.password = password;
            A: string ip = Packet.GetIP4Address();
                masterLogin = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ip), loginPort);
                try { masterLogin.Connect(ipe); message = messahe = "Login successful"; }
                catch
                {
                    message = messahe = "Could not log in";
                    Thread.Sleep(1000);
                    goto A;
                }
            }
            catch (Exception)
            {

                throw;
            }

            Thread t = new Thread(Data_IN);
            t.Start();
            LogIn();
        }

        private void LogIn()
        {
            Packet p = new Packet(PacketType.Login, id);
            p.LogInData.Add(username);
            p.LogInData.Add(password);
            masterLogin.Send(p.ToBytes());         }

        private void Data_IN()
        {
            byte[] Buffer;
            int readBytes;
            for (;;)
            {
                try
                {
                    Buffer = new byte[masterLogin.SendBufferSize];
                    readBytes = masterLogin.Receive(Buffer);
                    if (readBytes > 0)
                    {
                        DataManager(new Packet(Buffer));
                    }
                }
                catch (SocketException)
                {
                    messahe = "Ther server disconnected";
                    Environment.Exit(0);
                }
            }
        }

        private void DataManager (Packet p)
        {
            switch (p.packetType)
            {
                case PacketType.Login:
                    id = p.LogInData[0];
                    break;
            }
        }
    }
}
