using Acr.UserDialogs;
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
    public partial class ZahtjevPage : ContentPage
    {
        private readonly ApiService _voznje = new ApiService("voznja");
        private readonly ApiService _zahtjev = new ApiService("zahtjevi");
        ZahtjeviViewModel model = null;
        public ZahtjevPage()
        {
            InitializeComponent();
            BindingContext = model = new ZahtjeviViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.GetZahtjeve();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string ID = button.CommandParameter.ToString();

            int zahtjevID = Convert.ToInt32(ID);
            model.PonistiZahtjev(zahtjevID);
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string ID = button.CommandParameter.ToString();

            int zahtjevID = Convert.ToInt32(ID);
            model.OdobriZahtjev(zahtjevID);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string ID = button.CommandParameter.ToString();

            int zahtjevID = Convert.ToInt32(ID);
        
            Zahtjevi zahtjevi = await _zahtjev.GetById<Zahtjevi>(zahtjevID);

            await Navigation.PushAsync(new KorisnikInfoPage(zahtjevi.KorisnikID));
        }
    }
}