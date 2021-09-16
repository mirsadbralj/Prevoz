using eProdaja.Mobile.Converters;
using Prevoz.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prevoz.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DodajNovoVoziloPage : ContentPage
    {
        DodajNovoVoziloViewModel model = null;
        public DodajNovoVoziloPage()
        {
            InitializeComponent();
            BindingContext = model = new DodajNovoVoziloViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Load();
            ErrorNazivAutomobila.IsVisible = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await model.Save();
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var file = await FilePicker.PickAsync(
                    new PickOptions
                    {
                        FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                        {
                             { DevicePlatform.iOS, new[] { "public.my.comic.extension" } },
                             { DevicePlatform.Android, new[] { "application/comics" } },
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
                    model.SlikaK = bytes;   
                }
            }
            catch (Exception ex){
                await DisplayAlert("", ex.Message, "OK");
            }
        }

        private void NazivAutomobila_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(NazivAutomobila.Text.Length < 2)
            {
                ErrorNazivAutomobila.IsVisible = true;
                ErrorNazivAutomobila.Text = "Minimalno 2 karaktera";
                EnableAddVoziloButton();
            }
            else
            {
                ErrorNazivAutomobila.IsVisible = false;
                EnableAddVoziloButton();
            }

        }
        private void EnableAddVoziloButton()
        {
            if (ErrorNazivAutomobila.IsVisible == true)
                SacuvajVoziloButton.IsEnabled = false;
            else
                SacuvajVoziloButton.IsEnabled = true;
        }
    }
}