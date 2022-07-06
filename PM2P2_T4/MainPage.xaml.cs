using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Core;
using Xamarin.Forms;

namespace PM2P2_T4
{
    public partial class MainPage : ContentPage
    {

        MediaFile FileVideo;

        public MainPage()
        {
            InitializeComponent();

            if (App.DBase != null) { }
        }

        private async void btnTomarVideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                FileVideo = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    SaveToAlbum = true,
                    Name = DateTime.Now.ToString("yyyy'-'MM'-'dd'_'HHmmss") + ".mp4",
                    Directory = "MisVideos"
                    
                });

                if (FileVideo == null)
                    return;

                //await DisplayAlert("Direcctorio", FileVideo.Path, "OK");

                mediaElement.Source = FileVideo.Path;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }



            
        }

        private void btnGuardarVideo_Clicked(object sender, EventArgs e)
        {

        }
    }
}
