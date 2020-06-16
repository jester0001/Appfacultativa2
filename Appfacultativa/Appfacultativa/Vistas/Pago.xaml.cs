using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appfacultativa.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appfacultativa.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pago : ContentPage
    {
        public Pago()
        {
            InitializeComponent();
        }

        async void backarrow(object sender, EventArgs e)
        {

            await Navigation.PopAsync();

        }

        private async void btnpagocuota_Clicked(object sender, EventArgs e)
        {
            // datos que se obtienen de la vista 
            decimal pago_cuota = Convert.ToDecimal(txtpagcuota.Text); decimal monto_total = Convert.ToDecimal(txtmontoTotal.Text); decimal saldo_rest = Convert.ToDecimal(txtsaldotresta.Text); decimal saldo_pagado = Convert.ToDecimal(txtsaldopagado.Text);

            if (saldo_rest == 0 && saldo_pagado==0)
            {

                var prest = (prestamos)BindingContext;
                prest.saldorest = monto_total - pago_cuota;
                prest.saldopagado = pago_cuota;
                await App.Database.saveprestamoAsync(prest);
                await DisplayAlert("Exito", "Se ha Realizado el Pago de una Cuota.", "OK");
                await Navigation.PopAsync();


            }

            else if (saldo_pagado==monto_total)
            {
                await this.DisplayAlert("Exito", "Este Prestamo ha Sido cancelado", "OK");
                await Navigation.PopAsync();

            }

            else if (saldo_rest > 0)
            {

                var prest = (prestamos)BindingContext;
                prest.saldorest = saldo_rest - pago_cuota;
                prest.saldopagado = saldo_pagado + pago_cuota;
                await App.Database.saveprestamoAsync(prest);
                await DisplayAlert("Exito", "Se ha Realizado el Pago de una Cuota.", "OK");
                await Navigation.PopAsync();

            }


        }
    }
}