using Prevoz.MobileApp.Views;
using System;
using Xamarin.Forms;

namespace Prevoz.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(ListVozilaPage), typeof(ListVozilaPage));
            Routing.RegisterRoute(nameof(ListHistorijaVoznji), typeof(ListHistorijaVoznji));
            Routing.RegisterRoute(nameof(HistorijaVoznjiDetails), typeof(HistorijaVoznjiDetails));
            Routing.RegisterRoute(nameof(ZahtjevPage), typeof(ZahtjevPage));
            Routing.RegisterRoute(nameof(KorisnikInfoPage), typeof(KorisnikInfoPage));
            Routing.RegisterRoute(nameof(ListOcjenePage), typeof(ListOcjenePage));
            Routing.RegisterRoute(nameof(ListFaqPage), typeof(ListFaqPage));

        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
