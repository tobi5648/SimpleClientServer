﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servers
{
    class TCPServer
    {
        private TcpListener _server;
        private Boolean _isRunning;

        public TCPServer (int port)
        {
            try
            {
                _server = new TcpListener(IPAddress.Any, port);
                _server.Start();
                Logger.LogServer("Started");
                _isRunning = true;

                LoopClients();
            }
            catch (SocketException) { throw; }
            catch (UnauthorizedAccessException) { throw; }
            catch (ArgumentNullException) { throw; }
            catch (ArgumentOutOfRangeException) { throw; }
            catch (ArgumentException) { throw; }
            catch (DirectoryNotFoundException) { throw; }
            catch (PathTooLongException) { throw; }
            catch (IOException) { throw; }
            catch (SecurityException) { throw; }
            catch (NotSupportedException) { throw; }
            catch (ObjectDisposedException) { throw; }
            catch (Exception) { throw; }
        }

        public void LoopClients()
        {
            while (_isRunning)
            {
                //  wait for client connection
                TcpClient newClient = _server.AcceptTcpClient();

                //  client found
                //  Create a thread to handle communication
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public void HandleClient(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;

            // sets two streams
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested

            Boolean bClientConnected = true;
            String sData = null;

            while (bClientConnected)
            {
                // reads from stream
                sData = sReader.ReadLine();

                // shows content on the console.
                Console.WriteLine("Client &gt; " + sData);

                // to write something back.
                // sWriter.WriteLine("Meaningfull things here");
                // sWriter.Flush();
            }
        }
    }
}
