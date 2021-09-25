using Prevoz.MobileApp.ViewModels;
using Prevoz.Model;
using System;
using Windows.UI.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Prevoz.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PosaljiPorukuPage : ContentPage
    {
        PosaljiPorukuViewModel model = null;
        public PosaljiPorukuPage(int KorisnikID )
        {
            InitializeComponent();
            BindingContext = model = new PosaljiPorukuViewModel(KorisnikID);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
          
            await model.GetConversation();
            ErrorText.IsVisible = false;
            SendButton.IsEnabled = false;
        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Text.Text.Length == 0)
            {
                ErrorText.IsVisible = true;
                ErrorText.Text = "Nije moguće poslati praznu poruku.";
                EnableSendButon();
            }
            else
            {
                ErrorText.IsVisible = false;
                EnableSendButon();
            }
        }
        private void EnableSendButon()
        {
            if (ErrorText.IsVisible == true)
                SendButton.IsEnabled = false;
            else
                SendButton.IsEnabled = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}