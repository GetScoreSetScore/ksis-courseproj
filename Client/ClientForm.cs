using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Newtonsoft.Json;
namespace Client
{
    public partial class ClientForm : Form
    {
        public int PlayerCount = 2;
        ClientNetworking client = new ClientNetworking();
        Queue<PictureBox> platforms = new Queue<PictureBox>();
        List<PictureBox> players = new List<PictureBox>();
        Player[] playerstates;
        int SelfIndex = -1;
        int Speed;
        public ClientForm()
        {
            InitializeComponent();
        }
        public void LoadFromState(GameState state)
        {
            Speed = state.Speed;
            int i = 0;
            foreach (PictureBox platform in platforms)
            {
                platform.Location=state.platfcoords[i];
                i++;
            }
            if (playerstates != null && SelfIndex!=-1)
            {
                if (playerstates[SelfIndex].IsActive && !state.players[SelfIndex].IsActive)
                {
                    MessageBox.Show("You take the " + GetActivePlayers(playerstates) + " place and survived for " + state.players[SelfIndex].TimeSurvived);
                }
            }
            playerstates = state.players;
            i = 0;
            foreach(Player player in playerstates)
            {
                if (player.ippoint == client.client.Client.LocalEndPoint.ToString())
                {
                    SelfIndex = i;
                    break;
                }
                i++;
            }
            i = 0;

            foreach (PictureBox player in players)
            {
                player.Location = state.players[i].coords;
                i++;
            }
        }
        public int GetActivePlayers(Player[] players)
        {
            int i = 0;
            foreach(Player player in players.ToArray())
            {
                if (player.IsActive){
                    i++;
                }
            }
            return i;
        }
        public void ResetGame()
        {
            platforms.Clear();
            players.Clear();
            SelfIndex = -1;
            client = new ClientNetworking();
            MainTabControl.SelectedTab = MainPage;
            StartButton.Enabled = true;
        }
        private void SButton_Click(object sender, EventArgs e)
        {
            PlayerCount = Int32.Parse(PlayerCountTextBox.Text);
            InitializeField();
            client.Connect(AddressTextBox.Text, Int32.Parse(PortTextBox.Text), this);
            MainTabControl.SelectedTab = GamePage;
            StartButton.Enabled = false;
        }
        public void InitializeField()
        {
            platforms.Enqueue(platform1);
            platforms.Enqueue(platform2);
            platforms.Enqueue(platform3);
            platforms.Enqueue(platform4);
            players.Add(player1);
            if (PlayerCount > 1)
            {
                players.Add(player2);
            }
            if (PlayerCount > 2)
            {
                players.Add(player3);
            }
            if (PlayerCount > 3)
            {
                players.Add(player4);
            }
        }
        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar == (char)Keys.Space)&&(playerstates[SelfIndex].IsActive))
            {
                
                playerstates[SelfIndex].jumping = true;
                playerstates[SelfIndex].force = 15;
                playerstates[SelfIndex].jumpsleft--;

                string jsonstring = JsonConvert.SerializeObject(playerstates[SelfIndex]);
                byte[] message = client.PrepareMessage(jsonstring);
                client.Send(message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
