using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Newtonsoft.Json;
using SpotifyGame.Model;

namespace SpotifyGame.Converters
{
    class StringToSong : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
