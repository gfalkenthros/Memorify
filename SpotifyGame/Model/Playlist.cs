using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SpotifyGame.Model
{
    class Playlist : INotifyPropertyChanged
    {
        private List<string> _songs;
        private string _title;
        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged("Title"); }
        }

        private StorageFolder localFolder = ApplicationData.Current.LocalFolder;

        public Playlist()
        {
            Title = "No Playlist Selected";
        }

        public Playlist(StorageFile f)
        {
            string filename = Path.GetFileNameWithoutExtension(f.Path);
            Title = filename;
            LoadPlaylist(f);
        }


        private async void LoadPlaylist(StorageFile f)
        {
            if (f != null)
            {
                List<string> lines = (await FileIO.ReadLinesAsync(f)).ToList();
                lines.RemoveAt(0); // Headeer Line, not actual song data
                _songs = lines;
            }
            else
            {
                _songs = new List<string>() { };
            }
        }

        public string GetRandomSong()
        {
            if (_songs == null || _songs.Count < 1)
            {
                return "EMPTY";
            }
            else
            {
                Random rand = new Random();
                int i = rand.Next(0, _songs.Count);
                return _songs[i];
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
