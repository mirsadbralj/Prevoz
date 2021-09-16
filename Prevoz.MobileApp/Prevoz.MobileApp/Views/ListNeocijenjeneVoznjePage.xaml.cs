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
    public partial class ListNeocijenjeneVoznjePage : ContentPage
    {
        private readonly ApiService _voznje = new ApiService("voznja");
        ListNeocijenjeneVoznjeViewModel model = null;
        public ListNeocijenjeneVoznjePage()
        {
            InitializeComponent();
            BindingContext = model = new ListNeocijenjeneVoznjeViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.GetKorisnike();
        }
        private async void ItemVoznjaTapped(object sesnder, ItemTappedEventArgs e)
        {
            var content = e.Item as Korisnik;
            await Navigation.PushAsync(new KorisnikVoznjeOcjenaPage(content.KorisnikId, model.NeocijenjeneVoznje));
        }
    }
}