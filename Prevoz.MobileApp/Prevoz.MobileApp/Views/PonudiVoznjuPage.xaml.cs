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
    public partial class PonudiVoznjuPage : ContentPage
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _feedbacks = new ApiService("feedback");

        PonudiVoznjuViewModel model = null;
        public PonudiVoznjuPage()
        {
            InitializeComponent();

            this.BindingContext = model = new PonudiVoznjuViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.PonudiVoznju();
            await model.SetOCS();

            ButtonObjaviVoznju.IsEnabled = false;
            ErrorLabelCijenaSjedista.IsVisible = false;
            ErrorLabelBrojSjedista.IsVisible = false;
            ErrorLabelOdaberiAutomobil.IsVisible = false;
            ErrorLabelAutomatskoOdobrenje.IsVisible = false;
            ErrorLabelCigarete.IsVisible = false;
            ErrorLabelKucniLjubimci.IsVisible = false;
            ErrorLabelPolaznaLokacija.IsVisible = false;
            ErrorLabelDestinacija.IsVisible = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await model.ObjaviVoznju();
        }

        private void EntryCijenaSjedista_TextChanged(object sender, TextChangedEventArgs e)
        {
            var isNumeric = int.TryParse(CijenaSjedista.Text, out int n);
            if (CijenaSjedista.Text.Length == 0 || !isNumeric)
            {
                ErrorLabelCijenaSjedista.IsVisible = true;
                ErrorLabelCijenaSjedista.Text = "Obavezno polje, vrijednost mora biti numerička";
            }
            else
            {
                ErrorLabelCijenaSjedista.IsVisible = false;
            }
        }

        private void PickerOdaberiAutomobil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(PickerOdaberiAutomobil.SelectedIndex == -1)
            {
                ErrorLabelOdaberiAutomobil.IsVisible = true;
                ErrorLabelOdaberiAutomobil.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabelOdaberiAutomobil.IsVisible = false;
            }
            CheckForm();
        }


        private void CheckForm()
        {
            if (PickerOdaberiAutomobil.SelectedIndex != -1 && CijenaSjedista.Text.Length > 0 && ErrorLabelCijenaSjedista.IsVisible == false
                                                           && PickerBrojSjedista.SelectedIndex != -1 && ErrorLabelBrojSjedista.IsVisible == false
                                                           && AutomatskoOdobrenje.SelectedIndex != -1 && ErrorLabelAutomatskoOdobrenje.IsVisible == false
                                                           && Cigarete.SelectedIndex != -1 && ErrorLabelCigarete.IsVisible == false
                                                           && KucniLjubimci.SelectedIndex != -1 && ErrorLabelKucniLjubimci.IsVisible == false
                                                           && PolaznaLokacija.Text.Length > 0 && ErrorLabelPolaznaLokacija.IsVisible == false
                                                           && Destinacija.Text.Length > 0 && ErrorLabelDestinacija.IsVisible == false)

            {
                ButtonObjaviVoznju.IsEnabled = true;
                ErrorLabelForm.IsVisible = false;
            }
            else
            {
                ButtonObjaviVoznju.IsEnabled = false;
                ErrorLabelForm.IsVisible = true;
                ErrorLabelForm.Text = "Niste popunili sva potrebna polja.";
            }
        }

        private void PickerBrojSjedista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PickerBrojSjedista.SelectedIndex == -1)
            {
                ErrorLabelBrojSjedista.IsVisible = true;
                ErrorLabelBrojSjedista.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabelBrojSjedista.IsVisible = false;
            }
            CheckForm();
        }

        private void AutomatskoOdobrenje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(AutomatskoOdobrenje.SelectedIndex == -1)
            {
                ErrorLabelAutomatskoOdobrenje.IsVisible = true;
                ErrorLabelAutomatskoOdobrenje.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabelAutomatskoOdobrenje.IsVisible = false;
            }
            CheckForm();
        }

        private void Cigarete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cigarete.SelectedIndex == -1)
            {
                ErrorLabelCigarete.IsVisible = true;
                ErrorLabelCigarete.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabelCigarete.IsVisible = false;
            }
            CheckForm();
        }

        private void KucniLjubimci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KucniLjubimci.SelectedIndex == -1)
            {
                ErrorLabelKucniLjubimci.IsVisible = true;
                ErrorLabelKucniLjubimci.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabelKucniLjubimci.IsVisible = false;
            }
            CheckForm();
        }

        private void PolaznaLokacija_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PolaznaLokacija.Text.Length < 0 || !PolaznaLokacija.Text.All(char.IsLetter))
            {
                ErrorLabelPolaznaLokacija.IsVisible = true;
                ErrorLabelPolaznaLokacija.Text = "Polje obavezno (naziv grada)"; 
            }
            else
            {
                ErrorLabelPolaznaLokacija.IsVisible = false;
            }
            CheckForm();
        }

        private void Destinacija_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Destinacija.Text.Length < 0 || !Destinacija.Text.All(char.IsLetter))
            {
                ErrorLabelDestinacija.IsVisible = true;
                ErrorLabelDestinacija.Text = "Polje obavezno (naziv grada)";
            }
            else
            {
                ErrorLabelDestinacija.IsVisible = false;
            }
            CheckForm();
        }
    }
}