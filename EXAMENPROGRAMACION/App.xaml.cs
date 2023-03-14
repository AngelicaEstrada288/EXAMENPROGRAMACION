using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace EXAMENPROGRAMACION
{
    public partial class App : Application
    {
        static Controles.LocalizacionControles database;
        public static Controles.LocalizacionControles Database
        {
            get
            {
                var pathdatabase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var dbname = "Prog4.db3";
                var fullpath = Path.Combine(pathdatabase, dbname);
                database = new Controles.LocalizacionControles(fullpath);
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Views.PageLocalizacion());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
