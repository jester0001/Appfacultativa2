using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Appfacultativa.Models;
namespace Appfacultativa.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Prestamo : ContentPage
    {

        public Prestamo()
        {
            InitializeComponent();


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            combocliente.DataSource = await App.Database.GetClientesAsync();
            combocliente.DisplayMemberPath = "nombre";

        }

        async void backarrow(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void btguardarprestamo(object sender, EventArgs e)
        {
            if (combocliente.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtmonto.Text))
            {
                await this.DisplayAlert("Error", "No has seleccionado a un Cliente", "ok");

            }
            else
            {
                //datos que se van a optener de la tarjeta de datos en prestamos
                decimal montoneto=Convert.ToDecimal(txtmonto.Text); decimal mes=Convert.ToDecimal(txtmeses.Text); decimal porcinteres=Convert.ToInt32(txtproceninter.Text);
                // datos para la tabla prestamos calculados internamente
                decimal converporcen=porcinteres/100 ; decimal valorinteres=montoneto*converporcen; decimal montotal=montoneto+valorinteres; decimal cuota = montotal/mes;

                //para capturar el nombre del cliente

                var cliente = Convert.ToString(combocliente.SelectedValue);

                var prest = (prestamos)BindingContext;

                prest.cliente = cliente;
                prest.interes = valorinteres;
                prest.montoTotal = montotal;
                prest.cuota = cuota;
                prest.fechaprestamo = DateTime.Now;
                await App.Database.saveprestamoAsync(prest);
                await DisplayAlert("Exito", "Se ha Registrado un nuevo Prestamo", "OK");
                await Navigation.PopAsync();

            }


        }


    }
}