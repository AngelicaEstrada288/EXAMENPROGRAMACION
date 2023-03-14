using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLitePCL;

namespace EXAMENPROGRAMACION.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagelistGeo : ContentPage
    {
        public PagelistGeo()
        {
            InitializeComponent();
        }

        private async void listlocal_DoubleSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccion = (Models.Localizacion)e.CurrentSelection[0];
            var pag = new Views.Pagemapa();
           pag.BindingContext = seleccion;  
            await Navigation.PushAsync(pag);


        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listlocal.ItemsSource =  await App.Database.Getlisubica();
        }

        private async void btnelimanr_Clicked(object sender, EventArgs e)
        {
            var elim = await App.Database.Getlisubica();
            if (elim != null)  
            {
                await App.Database.Deleteubi(elim);
                await DisplayAlert("Dato","Se elimino de manera exitosa","Ok");
            }
        }

        private void btnbtnactualizar_Clicked(object sender, EventArgs e)
        { 

        }


    }
}