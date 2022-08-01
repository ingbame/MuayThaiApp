using MuayThaiApp.Tools;
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
    public partial class vwUsuarios : ContentPage
    {
        public vwUsuarios()
        {
            InitializeComponent();
            label1.Text = Md5Helper.Instance.PasswordMd5Hash("$Parral00");
        }
    }
}