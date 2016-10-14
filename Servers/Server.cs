namespace Servers
{
    #region Usings
    using DataAccess;
    using Networking;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    #endregion

    class Server
    {

        #region Constants
        /// <summary>
        /// The chosen port.
        /// </summary>
        private const int port = 4242;
        private const int portLogIn = 1000;
        #endregion

        #region Fields
        #region Chat
        /// <summary>
        /// A socket to listen.
        /// </summary>
        static Socket listenerSocket;
        /// <summary>
        /// A list of clients.
        /// </summary>
        public static List<ClientData> clients;
        /// <summary>
        /// The IP address.
        /// </summary>
        static IPAddress iPAddress = IPAddress.Parse(Packet.GetIP4Address());
        /// <summary>
        /// The amount of socket exceptions there has been.
        /// </summary>
        static int socketExceptions;
        #endregion
        /// <summary>
        /// A socket to listen.
        /// </summary>
        static Socket logInSocket;
        #endregion

        #region Threads
        /// <summary>
        /// Listener - listens for clients trying to connect.
        /// </summary>
        static void ListenThread()
        {
            for (;;)
            {
                listenerSocket.Listen(0);
                clients.Add(new ClientData(listenerSocket.Accept()));
            }
        }
        
        private static void LogInThread()
        {
            for (;;)
            {
                logInSocket.Listen(0);

            }
        }
        #endregion

        #region Main
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server on " + Packet.GetIP4Address());
            Logger.LogServer("Started");

            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clients = new List<ClientData>();

            IPEndPoint ip = new IPEndPoint(iPAddress, port);
            listenerSocket.Bind(ip);

            logInSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipLogin = new IPEndPoint(iPAddress, portLogIn);
            logInSocket.Bind(ipLogin);

            Thread listenThread = new Thread(ListenThread);
            listenThread.Start();

            Thread logInThread = new Thread(LogInThread);
            logInThread.Start();
        }
        #endregion

        #region Methods
        /// <summary>
        /// clientdata thread - receives data from each client indiviually.
        /// </summary>
        /// <param name="cSocket">clientSocket</param>
        public static void Data_IN(object cSocket)
        {
            Socket clientSocket = (Socket)cSocket;
            byte[] Buffer;
            int readBytes = 0;

            for (;;)
            {
                try
                {
                    Buffer = new byte[clientSocket.SendBufferSize];

                    readBytes = clientSocket.Receive(Buffer);

                    if (readBytes > 0)
                    {
                        //handle data
                        Packet packet = new Packet(Buffer);
                        DataManager(packet);
                    }
                }
                catch (SocketException)
                {
                    socketExceptions += 1;
                    Console.WriteLine("A client disconnected!");
                    if (socketExceptions == clients.Count)
                        Environment.Exit(0);
                    Console.ReadLine();

                    //throw;
                }
            }
        }

        /// <summary>
        /// data manager
        /// </summary>
        /// <param name="p">The packet</param>
        public static void DataManager(Packet p)
        {
            switch (p.packetType)
            {
                case PacketType.Chat:
                    foreach (ClientData c in clients)
                        c.clientSocket.Send(p.ToBytes());
                    break;
            }
        }
    } 
    #endregion
}
