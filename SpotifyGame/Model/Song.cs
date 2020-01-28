using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyGame.Model
{
    class Song
    {
        private string _title;
        private string _artist;
        private string v1;
        private string v2;

        public Song(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public string Title { get => _title; set => _title = value; }
        public string Artist { get => _artist; set => _artist = value; }
    }
}
