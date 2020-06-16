using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Appfacultativa.Models;

namespace Appfacultativa.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listaprestamos : ContentPage
    {
        public Listaprestamos()
        {
            InitializeComponent();
        }

        async void backarrow(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            allprestamos.ItemsSource = await App.Database.GetPrestamosAsync();
        }

        [Obsolete]
        private async void allprestamos_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new Pago { BindingContext = e.ItemData as prestamos });
        }

        [Obsolete]
        private async void allprestamos_ItemHolding(object sender, Syncfusion.ListView.XForms.ItemHoldingEventArgs e)
        {
            await PopupNavigation.PushAsync(new PopPrestamos { BindingContext = e.ItemData as prestamos });
        }

        private async void plusnewprestamo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Prestamo { BindingContext = new prestamos() });
        }
    }
}