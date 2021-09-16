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
    public partial class TraziVoznjuPage : ContentPage
    {
        protected TraziVoznjuViewModel model = null;
        public TraziVoznjuPage()
        {
            InitializeComponent();
            this.BindingContext = model = new TraziVoznjuViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ErrorLabelPolaznaLokacija.IsVisible = false;
            ErrorLabelDestinacija.IsVisible = false;
            ErrorLabelDatumVoznje.IsVisible = false;
            TraziButton.IsEnabled = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(CheckForm())
            await model.Trazi();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Voznja;
            
            await Navigation.PushModalAsync(new VoznjaDetailsPage(content));
        }

        private void PolaznaLokacija_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PolaznaLokacija.Text.Length < 3)
            {
                ErrorLabelPolaznaLokacija.IsVisible = true;
                ErrorLabelPolaznaLokacija.Text = "minimalno 3 karaktera";
            }
            else if (PolaznaLokacija.Text.Length > 40)
            {
                PolaznaLokacija.Text = RemoveLastCharacter(PolaznaLokacija.Text);
            }
            else
                ErrorLabelPolaznaLokacija.IsVisible = false;

            CheckForm();
        }
        private void PolaznaLokacija_Completed(object sender, EventArgs e)
        {
            if(PolaznaLokacija.Text.Length < 3 || PolaznaLokacija.Text.Length > 40)
            {
                ErrorLabelPolaznaLokacija.IsVisible = true;
                ErrorLabelPolaznaLokacija.Text = "Netačna polazna lokacija";
            }
            else
            {
                ErrorLabelPolaznaLokacija.IsVisible = false;
            }
            CheckForm();
        }
        private void Destinacija_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Destinacija.Text.Length < 3)
            {
                ErrorLabelDestinacija.IsVisible = true;
                ErrorLabelDestinacija.Text = ";inimalno 3 karaktera";
            }
            else if (Destinacija.Text.Length > 40)
                Destinacija.Text = RemoveLastCharacter(Destinacija.Text);
            else
                ErrorLabelDestinacija.IsVisible = false;

            CheckForm();
        }
        private void Destinacija_Completed(object sender, EventArgs e)
        {
            if (Destinacija.Text.Length < 3 || Destinacija.Text.Length > 40)
            {
                ErrorLabelDestinacija.IsVisible = true;
                ErrorLabelDestinacija.Text = "Netačna polazna lokacija";
            }
            else
            {
                ErrorLabelDestinacija.IsVisible = false;
            }

            CheckForm();
        }
        private void DatumVoznje_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (DatumVoznjePicker.Date < DateTime.Now.Date)
            {
                ErrorLabelDatumVoznje.IsVisible = true;
                ErrorLabelDatumVoznje.Text = "Nije moguće odabrati datum iz prošlosti";
            }
            else
                ErrorLabelDatumVoznje.IsVisible = false;
            CheckForm();
        }
        private bool CheckForm()
        {
            if (ErrorLabelPolaznaLokacija.IsVisible == false && PolaznaLokacija.Text.Length > 2
                && ErrorLabelDestinacija.IsVisible == false && Destinacija.Text.Length > 2
                && ErrorLabelDatumVoznje.IsVisible == false && DatumVoznjePicker.Date >= model._MinDatetime.Date)
            {
                TraziButton.IsEnabled = true;
                return true;
            }
            else
            {
                TraziButton.IsEnabled = false;
                return false;
            }
        }
        private string RemoveLastCharacter(string str)
        {
            int l = str.Length;
            string text = str.Remove(l - 1, 1);
            return text;
        }
    }
}