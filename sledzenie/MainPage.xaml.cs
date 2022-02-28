using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace sledzenie
{

    public partial class MainPage : ContentPage
    {
        private readonly Geocoder _geocoder = new Geocoder();


        public MainPage()
        {
            InitializeComponent();

        }

        async void Localize_Me(System.Object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            await DisplayAlert("Coordinates", $"szerokosc: {e.Position.Latitude}, dlugosc: {e.Position.Longitude}", "OK");

            var addressees = await _geocoder.GetAddressesForPositionAsync(e.Position);

            await DisplayAlert("Address", addressees.FirstOrDefault()?.ToString(), "OK");


        }

        async private void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            var nameValue = Miasto.Text;
           
            var positions = await _geocoder.GetPositionsForAddressAsync(nameValue);

            taMapa.MoveToRegion(MapSpan.FromCenterAndRadius(positions.First(), Distance.FromKilometers(10)));
        }
    }
}
