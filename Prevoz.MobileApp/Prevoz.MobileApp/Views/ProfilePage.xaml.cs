using Prevoz.MobileApp.ViewModels;
using Prevoz.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prevoz.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private ProfileViewModel model = null;
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = model = new ProfileViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Profile();
            ErrorUserName.IsVisible = false;
            ErrorIme.IsVisible = false;
            ErrorPrezime.IsVisible = false;
            ErrorGrad.IsVisible = false;
            ErrorTelefon.IsVisible = false;
            ErrorPassword.IsVisible = false;
            ErrorPasswordConfirm.IsVisible = false;
            ErrorLabelPasswordAndConfirm.IsVisible = false;
            ErrorEmail.IsVisible = false;
            DatumRodjenjaxaml.Date = model.Datum;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var file = await FilePicker.PickAsync(
                    new PickOptions
                    {
                        FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                        {
                             { DevicePlatform.UWP, new[] { ".jpg" } },
                        })
                    });
                if (file == null)
                    return;
                if (file != null)
                {
                    var stream = await file.OpenReadAsync();
                    var bytes = new byte[(int)stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    model.UserImage = bytes;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.Message, "OK");
            }
        }

        private async void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UserName.Text.Length < 2)
            {
                ErrorUserName.IsVisible = true;
                ErrorUserName.Text = "Najmanje 2 karaktera";
                EnableSaveButton();
            }
            else
            {
                ErrorUserName.IsVisible = false;
            }

            if (ErrorUserName.IsVisible == false)
            {
                var userName = new KorisniciUpsertRequests()
                {
                    UserName = UserName.Text
                };

                if (UserName.Text.Length >= 2)
                {
                    var korisnik = await _korisnik.Get<List<Model.Korisnik>>(userName);

                    if (korisnik.Count > 0 && korisnik[0].UserName != Memorija.Korisnik.UserName)
                    {
                        ErrorUserName.IsVisible = true;
                        ErrorUserName.Text = "Korisničko ime " + UserName.Text + " već postoji.";
                        EnableSaveButton();
                    }
                }
                EnableSaveButton();
            }
        }
        private void EnableSaveButton()
        {
            if (ErrorUserName.IsVisible == false && UserName.Text.Length > 0 &&
                ErrorIme.IsVisible == false && Ime.Text.Length > 0 
                && ErrorEmail.IsVisible == false && Email.Text.Length > 0 
                && ErrorPrezime.IsVisible == false && Prezime.Text.Length > 0
                &&ErrorTelefon.IsVisible == false && Telefon.Text.Length > 0)
                SaveButton.IsEnabled = true;
            else
                SaveButton.IsEnabled = false;
        }
        private void Ime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Ime.Text.Length == 1 || Ime.Text.Length > 50)
            {
                ErrorIme.IsVisible = true;
                ErrorIme.Text = "Minimalno 2, maksimalno 50 karaktera";
                EnableSaveButton();
            }
            else
            {
                ErrorIme.IsVisible = false;
                EnableSaveButton();
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsValidEmail(Email.Text))
            {
                ErrorEmail.IsVisible = true;
                ErrorEmail.Text = "Email addresa nije validna";
                EnableSaveButton();
            }
            else
            {
                ErrorEmail.IsVisible = false;
                EnableSaveButton();
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void Prezime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Grad.Text != null && Prezime.Text.Length == 1 || Prezime.Text.Length > 50)
            {
                ErrorPrezime.IsVisible = true;
                ErrorPrezime.Text = "Minimalno 2 karaktera, maksimalno 50 karaktera";
                EnableSaveButton();
            }
            else
            {
                ErrorPrezime.IsVisible = false;
                EnableSaveButton();
            }
        }

        private void Grad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Grad.Text != null)
            if (Grad.Text.Length == 1 || Grad.Text.Length > 100)
            {
                ErrorGrad.IsVisible = true;
                ErrorGrad.Text = "Minimalno 2 a maksimalno 100 karaktera";
                EnableSaveButton();
            }
            else
            {
                ErrorGrad.IsVisible = false;
                EnableSaveButton();
            }
        }
        private void Telefon_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Telefon.Text.Length < 6 && Telefon.Text.Length > 0)
            {
                ErrorTelefon.IsVisible = true;
                ErrorTelefon.Text = "Minimalno 6 brojeva";
                EnableSaveButton();
            }
            else
            {
                ErrorTelefon.IsVisible = false;
                EnableSaveButton();
            }
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Password.Text.Length < 5 && Password.Text.Length > 0)
            {
                ErrorPassword.IsVisible = true;
                ErrorPassword.Text = "Lozinka mora imati minimalno 6 karaktera.\n Minimalno po: 1 veliko, 1 malo slovo i 1 specijalni karakter";
            }
            else if (Password.Text.Any(ch => char.IsUpper(ch)) &&
                    Password.Text.Any(ch => char.IsLower(ch)) &&
                    Password.Text.Any(ch => !char.IsLetterOrDigit(ch)) &&
                    Password.Text.Length >= 6)
            {
                ErrorPassword.IsVisible = false;
                EnableSaveButton();
            }
            EnableSaveButton();
        }
        private void PasswordConfirm_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordConfirm.Text.Length < 5 && PasswordConfirm.Text.Length > 0)
            {
                ErrorPasswordConfirm.IsVisible = true;
                ErrorPasswordConfirm.Text = "Lozinka mora imati minimalno 6 karaktera.\n Minimalno po: 1 veliko, 1 malo slovo i 1 specijalni karakter";
            }
            else if (PasswordConfirm.Text.Any(ch => char.IsUpper(ch)) &&
                    PasswordConfirm.Text.Any(ch => char.IsLower(ch)) &&
                    PasswordConfirm.Text.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                ErrorLabelPasswordAndConfirm.IsVisible = false;
                ErrorPasswordConfirm.IsVisible = false;
                EnableSaveButton();
            }
        }
    }
}