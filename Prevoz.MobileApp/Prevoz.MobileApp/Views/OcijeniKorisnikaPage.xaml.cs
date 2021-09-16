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
    public partial class OcijeniKorisnikaPage : ContentPage
    {
        OcijeniKorisnikaViewModel model = null;
        public OcijeniKorisnikaPage(KorisnikRezervacija rezervacija, Korisnik korisnik) 
        {
            InitializeComponent();
            BindingContext = model = new OcijeniKorisnikaViewModel(rezervacija,korisnik);
        }
        public OcijeniKorisnikaPage(Voznja voznja, Korisnik korisnik)
        {
            InitializeComponent();
            BindingContext = model = new OcijeniKorisnikaViewModel(voznja, korisnik);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadKorisnik();
        }
    }
}