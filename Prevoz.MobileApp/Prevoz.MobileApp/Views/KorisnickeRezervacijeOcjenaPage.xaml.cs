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
    public partial class KorisnickeRezervacijeOcjenaPage : ContentPage
    {
        private readonly ApiService _korisnici = new ApiService ("korisnik");
        KorisnickeRezervacijeOcjenaViewModel model = null;
        int korisnikID = 0;
        public KorisnickeRezervacijeOcjenaPage(int KorisnikID, List<KorisnikRezervacija> rezervacije)
        {
            InitializeComponent();
            korisnikID = KorisnikID;
            BindingContext = model = new KorisnickeRezervacijeOcjenaViewModel(korisnikID, rezervacije);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.GetRezervacije();
        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as KorisnikRezervacija;

            Korisnik korisnik = await _korisnici.GetById<Model.Korisnik>(korisnikID);
            await Navigation.PushAsync(new OcijeniKorisnikaPage(content, korisnik)); 
        }
    }
}