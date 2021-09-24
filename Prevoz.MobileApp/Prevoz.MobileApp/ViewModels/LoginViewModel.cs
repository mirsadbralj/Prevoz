using Flurl.Http;
using Prevoz.Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prevoz.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        public LoginViewModel()
        {
            LoginCommand = new Command(async() => await Login());
        }
        public Command LoginCommand { get; }

        string _username = string.Empty;
        string _password = string.Empty;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        async Task Login()
        {
            IsBusy = true;
            ApiService.Username = Username;
            ApiService.Password = Password;
            try
            {
                var requestK = new KorisniciSearchRequest()
                {
                    UserName = ApiService.Username
                };
                var korisnik = await _korisnik.Get<List<Model.Korisnik>>(requestK);
                Memorija.Korisnik = korisnik[0];
                Application.Current.MainPage = new AppShell();
            }
             catch (FlurlHttpException ex)
            {
                await Application.Current.MainPage.DisplayAlert(ex.InnerException.ToString(), ex.Message, ex.GetBaseException().Message);
            }
        }
      
    }
}
