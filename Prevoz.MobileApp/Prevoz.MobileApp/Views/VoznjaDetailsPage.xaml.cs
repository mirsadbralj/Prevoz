using Prevoz.MobileApp.ViewModels;
using Prevoz.Model;
using Prevoz.Model.Requests;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prevoz.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VoznjaDetailsPage : ContentPage
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _feedbacks = new ApiService("feedback");
        VoznjaDetailsViewModel model = null;
        public VoznjaDetailsPage()
        {
            InitializeComponent();
        }
        public VoznjaDetailsPage(Voznja content)
        {
            InitializeComponent();
            BindingContext = model = new VoznjaDetailsViewModel(content);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.DetaljiVoznje();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await model.Rezervacija();
            var korisnikRequest = new KorisniciSearchRequest()
            {
                UserName = ApiService.Username
            };
            var feedback = await _feedbacks.Get<List<Model.Feedback>>(null);
            var korisnik = await _korisnik.Get<List<Model.Feedback>>(korisnikRequest);
            bool ocijenio = false;
            foreach(var item in feedback)
            {
                if (item.KorisnikId == korisnik[0].KorisnikId)
                    ocijenio = true;
            }
            if (!ocijenio)
            {
                var res = await DisplayAlert("", "Želite li ocjeniti korištenje aplikacije?", "DA", "NE");
                if (res)
                {
                    await Navigation.PushAsync(new LeaveFeedbackPage());
                }
            }
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            int voznjaId = model.voznjaId;
            await Navigation.PushAsync(new PaymentGatewayPage(voznjaId));
        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Voznja;
            await Navigation.PushAsync(new VoznjaDetailsPage(content));
        }

        private void GoBackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}