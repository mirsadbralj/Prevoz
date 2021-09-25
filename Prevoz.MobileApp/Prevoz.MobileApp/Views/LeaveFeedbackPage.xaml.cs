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
    public partial class LeaveFeedbackPage : ContentPage
    {
        LeaveFeedbackViewModel model = null;
        public LeaveFeedbackPage()
        {
            InitializeComponent();
            BindingContext = model = new LeaveFeedbackViewModel();
            ButtonPotvrdi.IsEnabled = false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.LoadCollectionListaOcjena();
        }

        private void Back_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Ocjena_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Ocjena.SelectedIndex == -1)
            {
                OcjenaLabelError.IsVisible = true;
                OcjenaLabelError.Text = "Obavezno polje";
            }
            else
            {
                OcjenaLabelError.IsVisible = false;
            }
            ChechForm();
        }

        private void ChechForm()
        {
            if(OcjenaLabelError.IsVisible == false && Ocjena.SelectedIndex > -1 && ButtonPotvrdi.IsEnabled == false)
            {
                ButtonPotvrdi.IsEnabled = true;
            }
            else
            {
                ButtonPotvrdi.IsEnabled = false;
            }
        }
    }
}