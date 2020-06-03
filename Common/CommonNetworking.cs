using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Common
{
    public struct Player
    {
        public string ippoint;
        public Point coords;
        public int jumpspeed;
        public int force;
        public bool jumping;
        public int defaultjumpspeed;
        public int jumpsleft;
        public string TimeSurvived;
        public bool IsActive;
    }
    public struct GameState
    {
        public Point[] platfcoords;
        public Player[] players;
        public int Speed;
    }

    public class Network
    {
        public string ExtractLastMessage(byte[] data, int reallength)
        {
            int start = 0;
            int len = 0;
            byte[] bytelen = new byte[4];
            do
            {
                start = start + len;
                Array.Copy(data, start, bytelen, 0, 4);
                len = BitConverter.ToInt32(bytelen, 0);
            } while ((start + len) < reallength);
            byte[] lastmes = new byte[len];
            Array.Copy(data, start, lastmes, 0, len);
            StringBuilder builder = new StringBuilder();
            builder.Append(Encoding.Unicode.GetString(lastmes, 4, len - 4));
            return builder.ToString();
        }
        public byte[] ConcatArr(byte[] x, byte[] y)
        {
            var z = new byte[x.Length + y.Length];
            x.CopyTo(z, 0);
            y.CopyTo(z, x.Length);
            return z;
        }
        public byte[] PrepareMessage(string message)
        {
            byte[] mess = Encoding.Unicode.GetBytes(message);
            byte[] len = BitConverter.GetBytes(mess.Length + 4);
            return ConcatArr(ConcatArr(len, mess), ConcatArr(len, mess));
        }
        public delegate void Del(GameState state);
        public delegate void DelPlayer(Player player);
        public delegate void DelNull();
    }
}
