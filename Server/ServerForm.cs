using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Newtonsoft.Json;
using System.Threading;
using Common;
using System.Diagnostics;
using System.Net.Sockets;

namespace Server
{
    public partial class ServerForm : Form
    {
        System.Timers.Timer PhysicsTimer,MovementTimer,SpawnPlatformTimer,DifficultyTimer,NetworkTimer,ResetTimer;
        ServerNetworking server = new ServerNetworking();
        Stopwatch timer = new Stopwatch();
        Queue<PictureBox> platforms = new Queue<PictureBox>();
        List<PictureBox> platflist = new List<PictureBox>();
        List<PictureBox> players = new List<PictureBox>();
        Random rnd = new Random();
        int lasttop = 436;
        Player[] playerstates;
        int Speed = 10;
        int PlayerCount = 1;
        public ServerForm()
        {
            InitializeComponent();
        }
        void Settimers()
        {
            PhysicsTimer = new System.Timers.Timer(20);
            PhysicsTimer.Elapsed += Collisions;
            PhysicsTimer.AutoReset = true;
            PhysicsTimer.Enabled = true;
            MovementTimer = new System.Timers.Timer(20);
            MovementTimer.Elapsed += Movement;
            MovementTimer.AutoReset = true;
            MovementTimer.Enabled = true;
            NetworkTimer = new System.Timers.Timer(20);
            NetworkTimer.Elapsed += UpdatePlayers;
            NetworkTimer.AutoReset = true;
            NetworkTimer.Enabled = true;
            DifficultyTimer = new System.Timers.Timer(30000);
            DifficultyTimer.Elapsed += Difficulty;
            DifficultyTimer.AutoReset = true;
            DifficultyTimer.Enabled = true;
            SpawnPlatformTimer = new System.Timers.Timer(1500);
            SpawnPlatformTimer.Elapsed += SpawnPlatform;
            SpawnPlatformTimer.AutoReset = true;
            SpawnPlatformTimer.Enabled = true;                                         //
            timer.Start();
        }
        public void SpawnPlatform(Object source, ElapsedEventArgs e)
        {
            PictureBox boxbuf = platforms.Dequeue();
            boxbuf.Left = background.Right;
            int top = lasttop + rnd.Next(-100, 100);
            if (top < 200) top = 200;
            if (top > 570) top = 570;
            boxbuf.Top = top;
            platforms.Enqueue(boxbuf);
            lasttop = boxbuf.Top;
        }
        public void Difficulty(Object source, ElapsedEventArgs e)
        {
            Speed++;
        }
        public void UpdatePlayer(Player player)
        {
            for(int i=0;i<playerstates.Length;i++)
            {
                if (playerstates[i].ippoint == player.ippoint)
                {
                    playerstates[i] = player;
                }
            }
        }
        GameState SaveGameState()
        {
            GameState state = new GameState();
            state.players = playerstates;
            state.Speed = Speed;
            state.platfcoords = new Point[4];
            int i = 0;
            foreach (PictureBox platform in platflist)
            {
                state.platfcoords[i] = platform.Location;
                i++;
            }
            return state;
        }
        void UpdatePlayers(Object source, ElapsedEventArgs e)
        {
            GameState state = SaveGameState();
            string jsonstring = JsonConvert.SerializeObject(state);
            byte[] message = server.PrepareMessage(jsonstring);
            server.SendAll(message);
        }
        void Collisions(Object source, ElapsedEventArgs e)
        {
            foreach (PictureBox platform in platflist)
            {
                foreach(PictureBox player in players)
                {
                    if (player.Bounds.IntersectsWith(platform.Bounds))
                    {
                        playerstates[players.IndexOf(player)].jumpsleft = 3;
                        playerstates[players.IndexOf(player)].force = 15;
                        playerstates[players.IndexOf(player)].defaultjumpspeed = 18;
                    }
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            PlayerCount = Int32.Parse(PlayerCountTextBox.Text);
            server.Initialize(AddressTextBox.Text, Int32.Parse(PortTextBox.Text), Int32.Parse(PlayerCountTextBox.Text), this);

            InitializeField();
            MainTabControl.SelectedTab = GamePage;
            StartButton.Enabled = false;
            Settimers();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        public int GetActivePlayers(Player[] players)
        {
            int i = 0;
            foreach (Player player in players.ToArray())
            {
                if (player.IsActive)
                {
                    i++;
                }
            }
            return i;
        }
        void Movement(Object source, ElapsedEventArgs e)
        {
            bool GameFinished = false;
            int i = 0;
            foreach(PictureBox platform in platflist)
            {
                platform.Left -= Speed;                                               //
            }
            foreach (PictureBox player in players)
            {
                if (playerstates[players.IndexOf(player)].IsActive) {
                    if (player.Bottom > GamePage.Bottom)
                    {
                        playerstates[players.IndexOf(player)].IsActive = false;
                        player.Location = new Point(-100, -100);
                        playerstates[players.IndexOf(player)].TimeSurvived = timer.Elapsed.ToString(@"m\:ss\.fff");
                        if (GetActivePlayers(playerstates) == 0)
                        {
                            PhysicsTimer.Enabled = false;
                            MovementTimer.Enabled = false;
                            NetworkTimer.Enabled = false;
                            SpawnPlatformTimer.Enabled = false;
                            DifficultyTimer.Enabled = false;
                            GameFinished = true;
                        }
                    }
                    player.Top += playerstates[players.IndexOf(player)].jumpspeed;
                    if ((playerstates[players.IndexOf(player)].jumping && playerstates[players.IndexOf(player)].force < 0)
                        || (playerstates[players.IndexOf(player)].jumping && playerstates[players.IndexOf(player)].jumpsleft < 0))
                    {
                        playerstates[players.IndexOf(player)].jumping = false;
                    }
                    if (playerstates[players.IndexOf(player)].jumping)
                    {
                        playerstates[players.IndexOf(player)].jumpspeed = -12;
                        playerstates[players.IndexOf(player)].force--;
                    }
                    else
                    {
                        playerstates[players.IndexOf(player)].jumpspeed = 12;
                    }
                    if (playerstates[players.IndexOf(player)].defaultjumpspeed > 12)
                    {
                        player.Top -= playerstates[players.IndexOf(player)].defaultjumpspeed;

                        playerstates[players.IndexOf(player)].defaultjumpspeed--;
                    }
                }
                playerstates[i].coords = player.Location;
                i++;
            }
            if (GameFinished)
            {
                UpdatePlayers(null, null);
                ResetTimer = new System.Timers.Timer(5000);
                ResetTimer.Elapsed += RestartGame;
                ResetTimer.AutoReset = false;
                ResetTimer.Enabled = true;
            }
        }

        void RestartGame(Object source, ElapsedEventArgs e){

            platflist.Clear();
            platforms.Clear();
            players.Clear();
            timer.Reset();
            MainTabControl.SelectedTab = MainPage;
            StartButton.Enabled = true;
            foreach(TcpClient client in server.clients)
            {
                client.Close();
            }
            server.clients.Clear();
            server = new ServerNetworking();
        }

        void InitializeField()
        {
            platforms.Enqueue(platform1);
            platforms.Enqueue(platform2);
            platforms.Enqueue(platform3);
            platforms.Enqueue(platform4);
            platflist.Add(platform1);
            platflist.Add(platform2);
            platflist.Add(platform3);
            platflist.Add(platform4);
            players.Add(player1);
            player1.Location = new Point(251, 124);
            if (PlayerCount > 1)
            {
                players.Add(player2);
                player2.Location = new Point(251, 124);
            }
            if (PlayerCount > 2)
            {
                players.Add(player3);
                player3.Location = new Point(251, 124);
            }
            if (PlayerCount > 3)
            {
                players.Add(player4);
                player4.Location = new Point(251, 124);
            }
            Speed = 10;
            playerstates = new Player[PlayerCount];
            int i = 0;
            foreach(PictureBox player in players)
            {
                playerstates[i].coords = player.Location;
                playerstates[i].jumpspeed = 10;
                playerstates[i].defaultjumpspeed = 12;
                playerstates[i].force = 15;
                playerstates[i].jumpsleft = 3;
                playerstates[i].jumping = false;
                playerstates[i].ippoint = server.clients[i].Client.RemoteEndPoint.ToString();
                playerstates[i].IsActive = true;
                playerstates[i].TimeSurvived = "";
                i++;
            }
        }


    }
}
