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

            ErrorlabelOcjenaSelected.IsVisible = false;
            Errorlabelkomentar.IsVisible = false;
            ButtonPotvrdi.IsEnabled = false;
        }

        private void OcjenaSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(OcjenaSelected.SelectedIndex == -1)
            {
                ErrorlabelOcjenaSelected.IsVisible = true;
                ErrorlabelOcjenaSelected.Text = "Polje je mandatorno";
            }
            else
            {
                ErrorlabelOcjenaSelected.IsVisible = false;
            }
            CheckForm();
        }

        private void Komentar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Komentar.Text.Length < 5)
            {
                Errorlabelkomentar.IsVisible = true;
                Errorlabelkomentar.Text = "Polje je mandatorno, mora sadržavati najmanje 5 karaktera";
            }
            else
            {
                Errorlabelkomentar.IsVisible = false;
            }
            CheckForm();
        }
        private void CheckForm()
        {
            if(ErrorlabelOcjenaSelected.IsVisible == false && OcjenaSelected.SelectedIndex > -1 &&
               Errorlabelkomentar.IsVisible==false && Komentar.Text.Length >= 5)
            {
                ButtonPotvrdi.IsEnabled = true;
            }
            else
            {
                ButtonPotvrdi.IsEnabled = false;
            }
        }
    }
}