﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.IO;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Appfacultativa.Models;

namespace Appfacultativa.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
                     
           
        }

        private void Btnclientes_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Listcliente());
        }

        async void Btnaddcliente_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Addcliente { BindingContext = new clientes() });
         
        }

        private void Btncalculaprestamo_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage) this.Parent).PushAsync(new CalcuPrestamo());
        }

        async void btnprestamo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Prestamo { BindingContext = new prestamos() });
        }

        private void btncreditos(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Listaprestamos());
        }

       
    }
}