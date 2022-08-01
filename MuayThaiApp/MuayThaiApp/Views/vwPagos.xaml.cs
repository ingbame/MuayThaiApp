using MuayThaiApp.Tools;
using MuayThaiApp.Tools.Enums;
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
    public partial class vwPagos : ContentPage
    {
        public vwPagos()
        {
            InitializeComponent();

            RestHelper prueba = new RestHelper
            {
                ApiUrl = @"http://ingbame.somee.com/api",
                ContollerName = "Security",
                _HttpMethod = HttpMethodsEnum.Get
            };
            //prueba.RestRequest();

            //if (pagosList != null)
            //    lstPagos.ItemsSource = pagosList;
        }
    }
}