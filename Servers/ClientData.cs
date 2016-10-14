using DataAccess;
using Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servers
{

    public class ClientData
    {
        #region Fields
        /// <summary>
        /// The client socket.
        /// </summary>
        public Socket clientSocket;
        /// <summary>
        /// The client thread.
        /// </summary>
        public Thread clientThread;
        /// <summary>
        /// The client id.
        /// </summary>
        public string id;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor of the class ClientData.
        /// </summary>
        /// <param name="clientSocket">The client Socket.</param>
        public ClientData(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(Server.Data_IN);
            clientThread.Start(clientSocket);
            SendRegistrationPacket();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Used to send a registration packet for the server.
        /// </summary>
        public void SendRegistrationPacket()
        {
            Packet p = new Packet(PacketType.Registration, "server");
            p.GroupedData.Add(id);
            clientSocket.Send(p.ToBytes());
        } 
        #endregion
    }
}