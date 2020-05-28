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
    public partial class Addcliente : ContentPage
    {
        public Addcliente()
        {
            InitializeComponent();
            
        }

        async void btaddcliente_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnombrecliente.Text))
            {
                await this.DisplayAlert("Aviso!", "El cliente debe tener un Nombre y un Numero de cedula", "OK");
            }
            else
            {
                var client = (clientes)BindingContext;


                await App.Database.saveclienteAsync(client);
                await DisplayAlert("Exito", "Se han Actualizado los registros", "OK");
                await Navigation.PopAsync();

            }
           

            
        }

        async  void backarrow(object sender, EventArgs e)
        {
           
            await Navigation.PopAsync();

        }

       
    }
}