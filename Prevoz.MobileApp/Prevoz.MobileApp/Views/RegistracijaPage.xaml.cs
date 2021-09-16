using Prevoz.MobileApp.ViewModels;
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
    public partial class RegistracijaPage : ContentPage
    {
        private RegistracijaViewModel model = null;
        public RegistracijaPage()
        {
            InitializeComponent();

            this.BindingContext = model = new RegistracijaViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ErrorLabelUsername.IsVisible = true;
            ErrorLabelPassword.IsVisible = true;
            ErrorLabelPasswordConfirm.IsVisible = true;
            ErrorLabelPasswordAndCOnfirm.IsVisible = false;
            ButtonRegistracija.IsEnabled = false;
        }
        private void EnableRegistracijaButton()
        {
            if (ErrorLabelUsername.IsVisible == true || ErrorLabelPasswordAndCOnfirm.IsVisible == true || ErrorLabelPassword.IsVisible == true || ErrorLabelPasswordConfirm.IsVisible == true )
                ButtonRegistracija.IsEnabled = false;
            else
                ButtonRegistracija.IsEnabled = true;
        }
        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Username.Text.Length < 2 || Username.Text.Length > 50)
            {
                ErrorLabelUsername.IsVisible = true;
                ErrorLabelUsername.Text = "Polje mora imati više od 3 i manje od 50 karaktera.";
            }
            else
                ErrorLabelUsername.IsVisible = false;

            EnableRegistracijaButton();
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Password.Text.Length < 5)
            {
                ErrorLabelPassword.IsVisible = true;
                ErrorLabelPassword.Text = "Lozinka mora imati minimalno 6 karaktera.\n Minimalno po: 1 veliko, 1 malo slovo i 1 specijalni karakter";
            }
            else if (Password.Text.Any(ch => char.IsUpper(ch)) &&
                    Password.Text.Any(ch => char.IsLower(ch)) &&
                    Password.Text.Any(ch => !char.IsLetterOrDigit(ch)) &&
                    Password.Text.Length>=6)
            {
                ErrorLabelPassword.IsVisible = false;
                EnableRegistracijaButton();
            }
            EnableRegistracijaButton();
        }
        private void PasswordConfirm_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordConfirm.Text.Length < 5)
            {
                ErrorLabelPasswordConfirm.IsVisible = true;
                ErrorLabelPasswordConfirm.Text = "Lozinka mora imati minimalno 6 karaktera.\n Minimalno po: 1 veliko, 1 malo slovo i 1 specijalni karakter";
            }
            else if (PasswordConfirm.Text.Any(ch => char.IsUpper(ch)) &&
                    PasswordConfirm.Text.Any(ch => char.IsLower(ch)) &&
                    PasswordConfirm.Text.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                ErrorLabelPasswordAndCOnfirm.IsVisible = false;
                ErrorLabelPasswordConfirm.IsVisible = false;
                EnableRegistracijaButton();
            }
        }
        private void PasswordConfirm_Completed(object sender, EventArgs e)
        {
            if (Password.Text != PasswordConfirm.Text)
            {
                ErrorLabelPasswordConfirm.Text = "Lozinka i potvrda nisu isti. Pokušajte ponovo";
                ErrorLabelPasswordConfirm.IsVisible = true;
            }
        }
    }
}