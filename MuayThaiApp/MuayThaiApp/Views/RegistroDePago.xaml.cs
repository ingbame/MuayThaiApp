using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuayThaiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroDePago : ContentPage
    {
        public RegistroDePago()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                //var prueba2 = new Pagos()
                //{
                //    FechaPago = DateTime.Now,
                //    MetodoPagoId = 1,
                //};
                //await App.Database.SavePagosPor15ClasesAsync(prueba2);
                //List<_Afiliado> res = new List<_Afiliado>();
                await DisplayAlert("Registro", "Se ingresó correctamente", "Ok");
            }
            else
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok");
        }
        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtFechaPago?.Text?.Trim() ?? null))
                return false;
            if (string.IsNullOrEmpty(txtMetodoPagoId?.Text?.Trim() ?? null))
                return false;
            if (string.IsNullOrEmpty(txtEvidencia?.Text?.Trim() ?? null))
                return false;
            return true;
        }
    }
}