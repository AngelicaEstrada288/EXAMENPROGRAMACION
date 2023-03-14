using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace EXAMENPROGRAMACION.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagemapa : ContentPage
    {
        public Pagemapa()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var seleccion =(Models.Localizacion) this .BindingContext;

            var centromapa = new Xamarin.Forms.Maps.Position(seleccion.latitud, seleccion.longitud);
            Mapa.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(centromapa, 1, 1));

            Pin ubicacion = new Pin();
            ubicacion.Label = seleccion.descripcion_corta;
            ubicacion.Address = seleccion.descripcion_larga;
            ubicacion.Position= new Xamarin.Forms.Maps.Position(seleccion.latitud, seleccion.longitud);
            Mapa.Pins.Add(ubicacion);


        }
    }
}