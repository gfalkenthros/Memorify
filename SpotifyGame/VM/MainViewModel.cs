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
        private RelayCommand _loadPlaylistBtn;

        private string _song;

        public MainViewModel()
        {
            Song = "Please Select Playlist";
            Playlist = new Playlist();
            GetRandomSongBtn = new RelayCommand(LoadRandomSong);
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

        private void LoadRandomSong()
        {
            if (Playlist != null)
            {
                Song = Playlist.GetRandomSong();
            }
        }

        public string Test { get => _test; set => _test = value; }
        public RelayCommand GetRandomSongBtn { get => _getRandomSongBtn; set => _getRandomSongBtn = value; }
        internal Playlist Playlist
        {
            get => _playlist;
            set { SetProperty(ref _playlist, value, "Playlist"); }
        }
        public string Song
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
    }
}
