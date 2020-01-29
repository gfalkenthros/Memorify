using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyGame.Model;
using Windows.Storage;

namespace SpotifyGame.VM
{
    public class MainViewModel : ViewModel
    {
        private Playlist _playlist;

        private RelayCommand _getRandomSongBtn;
        private RelayCommand _getRandomFieldsBtn;
        private RelayCommand _loadPlaylistBtn;
        private List<string> _fields;

        private Song _song;
        private int _difficulty;

        public MainViewModel()
        {
            CurSong = new Song();
            Playlist = new Playlist();
            Fields = new List<string>() { "one", "two", "three" };
            Difficulty = 1;
            GetRandomSongBtn = new RelayCommand(LoadRandomSong);
            GetRandomFieldsBtn = new RelayCommand(GetRandomFields);
            LoadPlaylistBtn = new RelayCommand(LoadPlaylist);
        }

        private async void LoadPlaylist()
        {
            var playlistPicker = new Windows.Storage.Pickers.FileOpenPicker();
            playlistPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            playlistPicker.FileTypeFilter.Add(".csv");
            StorageFile playlistFile = await playlistPicker.PickSingleFileAsync();

            Playlist = new Playlist(playlistFile);
            PlaylistTitle = Playlist.Title;

        }


        public async void GetRandomFields()
        {
            Fields.Clear();

            List<string> temp = new List<string>() { };

            Random r = new Random();
            int length = CurSong.Fields.Values.Count;
            for(int i = Difficulty; i <= 4; i++)
            {
                int index = r.Next(0, length);
                temp.Add(CurSong.Fields.Values.ElementAt(index));
            }

            Fields = temp;
            OnPropertyChanged("Fields");
        }

        private void LoadRandomSong()
        {
            if (Playlist != null)
            {
                CurSong = new Song(Playlist.GetRandomSong());
                GetRandomFields();
            }
        }

        public RelayCommand GetRandomSongBtn { get => _getRandomSongBtn; set => _getRandomSongBtn = value; }
        public RelayCommand GetRandomFieldsBtn { get; }

        internal Playlist Playlist
        {
            get => _playlist;
            set { SetProperty(ref _playlist, value, "Playlist"); }
        }
        public Song CurSong
        {
            get => _song;
            set { SetProperty(ref _song, value, "Song"); }
        }
        public RelayCommand LoadPlaylistBtn { get => _loadPlaylistBtn; set => _loadPlaylistBtn = value; }
        public string PlaylistTitle
        {
            get => Playlist.Title;
            set { Playlist.Title = value; OnPropertyChanged("PlaylistTitle"); }
        }

        public List<string> Fields
        {
            get => _fields;
            set
            {
                SetProperty(ref _fields, value, "Fields");
            }
        }

        public int Difficulty { get => _difficulty; set => _difficulty = value; }
    }
}
