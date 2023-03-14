using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace EXAMENPROGRAMACION.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLocalizacion : ContentPage
    {
        Location location = null;
        public PageLocalizacion()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
           

            try
            {
                

                if (location != null &&
                    !String.IsNullOrEmpty(Descripcion_Corta.Text) &&
                    !String.IsNullOrEmpty(Descripcion_Larga.Text))
                {
                    Latitud.Text = Convert.ToString(location.Latitude);
                    Longitud.Text = Convert.ToString(location.Longitude);

                    var local = new Models.Localizacion
                    {
                        latitud = location.Latitude,
                        longitud = location.Longitude,
                        descripcion_corta = Descripcion_Corta.Text,
                        descripcion_larga = Descripcion_Larga.Text,

                    };
                    if ( await App.Database.saveubi(local) >0)
                    {
                        await DisplayAlert("Aviso", "Localizacion Guardada", "OK");

                    }    

                }
                else
                {
                    if (location == null)
                    {
                        await DisplayAlert("Error", "Error no esta activo el GPS", "OK");
                    }
                    else if (String.IsNullOrEmpty(Descripcion_Corta.Text))
                    {
                        await DisplayAlert("Error", "Error sin descripcion corta", "OK");
                    }
                    else if (String.IsNullOrEmpty(Descripcion_Larga.Text))
                    {
                        await DisplayAlert("Error", "Error sin descripcion larga", "OK");
                    }

                }
            }
            catch (Exception ex)
            {
                if (location != null)
                {
                    await DisplayAlert("Error", "Error no esta activo el GPS", "OK");
                }


            }

        }

        private async void btnver_Clicked(object sender, EventArgs e)
        {
            var pag = new Views.PagelistGeo();
            await Navigation.PushAsync(pag);

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                location = await Geolocation.GetLocationAsync();
                if( location!= null)
                {
                    Latitud.Text = Convert.ToString(location.Latitude);
                    Longitud.Text = Convert.ToString(location.Longitude);

                }


            }
            catch ( Exception ex)
            {

            }
            
                

                

        }
    }
}