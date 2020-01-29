using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyGame.Model
{
    //﻿Spotify URI,Track Name,Artist Name,Album Name,Disc Number,Track Number,Track Duration (ms),Added By,Added At
    public class Song
    {
        private Dictionary<string, string> _fields = new Dictionary<string, string>();


        public Song()
        {
            Fields["spotifyUri"] = "";
            Fields["trackName"] = "";
            Fields["artist"] = "";
            Fields["album"] = "";
            Fields["discNumber"] = "";
            Fields["trackNumber"] = "";
            Fields["trackDuration"] = "";
            Fields["addedBy"] = "";
            Fields["addedAt"] = "";
        }

        public Song(string songString)
        {
            string[] values = songString.Split(',');

            Fields["spotifyUri"] = values[0];
            Fields["trackName"] = values[1];
            Fields["artist"] = values[2];
            Fields["album"] = values[3];
            Fields["discNumber"] = values[4];
            Fields["trackNumber"] = values[5];
            Fields["trackDuration"] = values[6];
            Fields["addedBy"] = values[7];
            Fields["addedAt"] = values[8];
           
        }

        public Dictionary<string, string> Fields { get => _fields; set => _fields = value; }
    }
}
