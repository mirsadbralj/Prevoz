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
    public partial class ListVozilaPage : ContentPage
    {
        private VozilaViewModel model= null;
        public ListVozilaPage()
        {
            InitializeComponent();
            BindingContext = model = new VozilaViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.GetVozila();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Vozilo;
            
            var res = await DisplayAlert("", "Želite ukloniti vozilo?", "DA", "NE");
            
            if (res)
            {
                await model.Remove(item.VoziloId);
                await DisplayAlert("Vozilo je uklonjeno", "", "OK");
                await model.GetVozila();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DodajNovoVoziloPage());
        }
    }
}