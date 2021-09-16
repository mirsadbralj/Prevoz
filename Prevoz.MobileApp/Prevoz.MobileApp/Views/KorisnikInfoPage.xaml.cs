using Prevoz.MobileApp.ViewModels;
using Prevoz.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prevoz.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KorisnikInfoPage : ContentPage
    {
        KorisnikInfoViewModel model = null;
        int korisnikID = 0;
        public KorisnikInfoPage(int KorisnikId)
        {
            InitializeComponent();
            korisnikID = KorisnikId;
            BindingContext = model = new KorisnikInfoViewModel(KorisnikId);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.GetInfo();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PosaljiPorukuPage(korisnikID));
        }
    }
}