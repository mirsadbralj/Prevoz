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
    public partial class ListNeocijenjeneRezervacijePage : ContentPage
    {
        ListNeocijenjeneRezervacijeViewModel model = null;
        public ListNeocijenjeneRezervacijePage()
        {
            InitializeComponent();

            BindingContext = model = new ListNeocijenjeneRezervacijeViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.GetKorisnike();
        }
        private async void ItemVoznjaTapped(object sesnder, ItemTappedEventArgs e)
        {
            var content = e.Item as Korisnik;

            List<KorisnikRezervacija> list = new List<KorisnikRezervacija>();
            KorisnikRezervacija rezervacija = new KorisnikRezervacija();
            list = model.listaNeocijenjenihRezervacija;


            List<KorisnikRezervacija> rezervacijeL = list.Where(x => x.KorisnikId == content.KorisnikId).ToList();

            await Navigation.PushAsync(new KorisnickeRezervacijeOcjenaPage(content.KorisnikId, list));
        }
    }
}