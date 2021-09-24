using Prevoz.Model.Requests;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prevoz.MobileApp.ViewModels
{
    public class RegistracijaViewModel : BaseViewModel
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");

        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _passwordConfirmation = string.Empty;

        public RegistracijaViewModel()
        {
            RegistrationCommand = new Command(async () => await Registration());
        }
        public Command RegistrationCommand { get; }
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
        public string PasswordConfirm
        {
            get { return _passwordConfirmation; }
            set { SetProperty(ref _passwordConfirmation, value); }
        }
        public async Task Registration() 
        {
            var request = new KorisniciUpsertRequests()
            {
                UserName = Username,
                Password = Password,
                PasswordConfirmation = PasswordConfirm
            };

            var request2 = new KorisnikDetail_UpsertRequest()
            {
                Ime = "",
                Prezime = "",
                Telefon = "",
                Email = ""
            };

            try
            {
                await _korisnik.Insert<Model.Korisnik>(request);
                await Application.Current.MainPage.DisplayAlert("Uspješna registracija", "Sada možete izvršiti prijavu na sistem", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Korisničko ime ili lozinka nisu validni "+ ex.Message ,"OK");
            }
        }
    }
}