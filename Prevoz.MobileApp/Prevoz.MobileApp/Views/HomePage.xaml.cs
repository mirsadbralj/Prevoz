using Prevoz.MobileApp.ViewModels;
using Prevoz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prevoz.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeViewModel model = null;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = model = new HomeViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TraziVoznjuPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PonudiVoznjuPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.GetRezervacije();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Voznja;
            Navigation.PushAsync(new VoznjaDetailsPage(content));
        }
    }
}