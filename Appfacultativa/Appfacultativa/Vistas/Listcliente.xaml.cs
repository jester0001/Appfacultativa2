using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms.Xaml;
using Appfacultativa.Models;

namespace Appfacultativa.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listcliente : ContentPage
    {

        public Listcliente()
        {
            InitializeComponent();

        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Addcliente { BindingContext = new clientes() });
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listaclientes.ItemsSource = await App.Database.GetClientesAsync();
        }

        async void listaclientes_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if (e.ItemData != null)

            {
                await Navigation.PushAsync(new Addcliente { BindingContext = e.ItemData as clientes });


            }
        }


        async void backarrow(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        [Obsolete]
        private async void listaclientes_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            await PopupNavigation.PushAsync(new PopUpEliminar { BindingContext = e.ItemData as clientes });
         
           
        }


        private void listaclientes_SwipeReset(object sender, Syncfusion.ListView.XForms.ResetSwipeEventArgs e)
        {
            if (e.ItemIndex == 1)
                e.Cancel = true;

        }
    }




}
