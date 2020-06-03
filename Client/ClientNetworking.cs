using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Common;
namespace Client
{

    class ClientNetworking:Network
    {
        ClientForm owner;
        public TcpClient client = new TcpClient();


        public void Send(byte[] message)
        {
            client.GetStream().Write(message, 0, message.Length);
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
                    string newstate = ExtractLastMessage(data, bytes);
                    GameState state = JsonConvert.DeserializeObject<GameState>(newstate);
                    owner.Invoke(new Del((s) => owner.LoadFromState(s)), state);
                }
            }
            
            catch (Exception ex)
            {

                owner.Invoke(new DelNull(() => owner.ResetGame()));
                client.Close();
            }
        }
        public void Connect(string ip, int port,ClientForm formOwner)
        {
            owner = formOwner;
            client.NoDelay = true;
            client.Connect(ip,port);
            string tmp = client.Client.LocalEndPoint.ToString();
            NetworkStream stream = client.GetStream();
            Task listeningTask = new Task(() => listenclient(client));
            listeningTask.Start();
        }
    }
}
