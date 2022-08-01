using MuayThaiApp.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuayThaiApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            flyout.lvMenu.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                flyout.lvMenu.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}