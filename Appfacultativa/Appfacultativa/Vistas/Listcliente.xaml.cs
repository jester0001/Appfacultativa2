using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Appfacultativa.Models;

namespace Appfacultativa.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listcliente : ContentPage
    {
    
        int itemIndex = -1;
       

        public Listcliente()
        {
            InitializeComponent();
            
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Addcliente { BindingContext = new clientes()});
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

        async void deletecliente(object sender, EventArgs e)
        {
            var client = (clientes)BindingContext;
            await App.Database.deleteclienteAsync(client);
        }

       
    }
}