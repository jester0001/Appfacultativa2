using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Appfacultativa.Data;
namespace Appfacultativa
{
    public partial class App : Application
    {
        static cliente_database database;
        public static cliente_database Database
        {
            get
            {
                if (database == null)
                {
                    database = new cliente_database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clientes.db3"));
                }
                return database;
            }
        }


        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQyODgzQDMxMzgyZTMxMmUzMFp4R2k1SDlDY0E0YlV1blpJbytvY2tSWUFWdnVjSGI5a3NFenBtcllockE9");

            InitializeComponent();



            MainPage = new NavigationPage(new Appfacultativa.Vistas.Home());

            MainPage.BackgroundColor = ColorConverters.FromHex("#F5F5F5");
            
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
