using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Appfacultativa.Models;
using Appfacultativa.Vistas;

namespace Appfacultativa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpEliminar : PopupPage
    {
        public PopUpEliminar()
        {
            InitializeComponent();
        }

        [Obsolete]
        private async void eliminar_Clicked(object sender, EventArgs e)
        {
            var client = (clientes)BindingContext;
            await App.Database.deleteclienteAsync(client);
            await PopupNavigation.PopAsync();
            await Navigation.PushAsync(new Listcliente(), true);

        }

        [Obsolete]
        private async void cancelar_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
       
            
        }

        async void salir_a_actualizar()
        {
            await Navigation.PopAsync();
        }
    }
}