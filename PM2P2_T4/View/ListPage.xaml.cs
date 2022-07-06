using PM2P2_T4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P2_T4.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            list.ItemsSource = await App.DBase.getListVideo();
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            try
            {
                var item = sender as SwipeItem;

                var video = item.BindingContext as Video;

                var vista = new VideoPage();

                vista.BindingContext = video.Path;

                await Navigation.PushModalAsync(vista);

            }
            catch (Exception)
            {

                await DisplayAlert("Aviso", "No se pudo eliminar el audio", "OK");
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            OnBackButtonPressed();
        }
    }
}