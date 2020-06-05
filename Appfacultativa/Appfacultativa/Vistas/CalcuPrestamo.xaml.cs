using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appfacultativa.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalcuPrestamo : ContentPage
    {
        public CalcuPrestamo()

        {
            InitializeComponent();
        }


        async void btncalcular_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(montopres.Text) || string.IsNullOrWhiteSpace(Tasainter.Text) || string.IsNullOrWhiteSpace(cuotas.Text))
            {
                await this.DisplayAlert("Aviso", "Ingresa los datos", "OK");

            }
            else
            {

                var total = decimal.Parse(montopres.Text);
                var Interes = total * (decimal.Parse(Tasainter.Text) / 100);
                var ncuota = int.Parse(cuotas.Text);
                var cuota = ((total / ncuota));
                var tinteres = ((Interes * ncuota));

                lblMonto.Detail = total.ToString("C");
                lblintereses.Detail = Interes.ToString("C");
                lbltintereses.Detail = tinteres.ToString("C");
                lblcuota.Detail = cuota.ToString("C");
            }
        }

        private async void backarrow(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }






}




