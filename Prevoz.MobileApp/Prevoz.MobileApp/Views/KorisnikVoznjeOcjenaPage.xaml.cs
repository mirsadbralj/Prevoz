using Prevoz.MobileApp.ViewModels;
using Prevoz.Model;
using Prevoz.Model.Requests.Rezervacija;
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
    public partial class KorisnikVoznjeOcjenaPage : ContentPage
    {
        private readonly ApiService _korisnici = new ApiService("korisnik");
        private readonly ApiService _rezervacije = new ApiService("korisnikrezervacija");
        int _KorisnikID = 0;
        KorisnikVoznjeOcjenaViewModel model = null;
        public KorisnikVoznjeOcjenaPage(int KorisnikID, List<Model.Voznja> listaVoznji)
        {
            _KorisnikID = KorisnikID;
            InitializeComponent();
            BindingContext = model = new KorisnikVoznjeOcjenaViewModel(KorisnikID, listaVoznji);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.GetVoznje();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Voznja;

            List<Model.Voznja> list = model.listaNeocijenjenihVoznji.ToList();
            Korisnik korisnik = await _korisnici.GetById<Model.Korisnik>(_KorisnikID);
            await Navigation.PushAsync(new OcijeniKorisnikaPage(content,korisnik));
            model.GetVoznje();
        }
    }
}