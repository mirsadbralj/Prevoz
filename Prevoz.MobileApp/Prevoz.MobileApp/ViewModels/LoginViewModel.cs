using Flurl.Http;
using Prevoz.MobileApp.Views;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.MobileApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            ApiService.Username = _username;
            ApiService.Password = _password;
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
               // await Application.Current.MainPage.DisplayAlert(ex.InnerException.ToString(), ex.Message, ex.GetBaseException().Message);
               // await Application.Current.MainPage.DisplayAlert("Greška", "Niste autentificirani", "OK");
            }
        }
      
    }
}
