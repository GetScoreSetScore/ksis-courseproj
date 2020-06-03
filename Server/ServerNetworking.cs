using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Common;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Server
{
    public class ServerNetworking:Network
    {
        ServerForm owner;
        public List<TcpClient> clients = new List<TcpClient>();
        public bool listening = true;
        public void SendAll(byte[] message)
        {
            foreach(TcpClient client in clients)
            {
                client.GetStream().Write(message,0,message.Length);
            }
        }
        void listenclient(TcpClient client)
        {
            StringBuilder builder;
            NetworkStream stream = client.GetStream();
            int i = 0;
            try
            {
                while (true)
                {
                    builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[1000000];
                    i = 1;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (client.Available > 0);
                    string NewPlayer = ExtractLastMessage(data, bytes);
                    Player player = JsonConvert.DeserializeObject<Player>(NewPlayer);
                    owner.Invoke(new DelPlayer((s) => owner.UpdatePlayer(s)), player);
                }
            }
            catch (Exception ex)
            {
                clients.Remove(client);
                client.Close();
            }
        }
        public void Initialize(string ip,int port,int playercount,ServerForm formOwner)
        {
            owner = formOwner;
            InitializePlayers(ip, port, playercount);
        }
        public void InitializePlayers(string ip, int port, int playercount)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            TcpListener listener = new TcpListener(ipAddress, port);
            listener.Start();
            while (clients.Count < playercount)
            {
                TcpClient curclient = listener.AcceptTcpClient();
                clients.Add(curclient);
                curclient.NoDelay = true;
                Task listeningTask = new Task(() => listenclient(curclient));
                listeningTask.Start();
            }
        }
    }
}
