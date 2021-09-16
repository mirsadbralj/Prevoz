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
    public partial class ListHistorijaVoznji : ContentPage
    {
        private HistorijaVoznjiViewModel model = null;
        public ListHistorijaVoznji()
        {
            InitializeComponent();
            BindingContext = model = new HistorijaVoznjiViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            await model.GetUkupnePrihode();
            await model.GetUkupneTroskove();
        }
        private async void ItemVoznjaTapped(object sesnder, ItemTappedEventArgs e)
        {
            var content = e.Item as Voznja;
            await Navigation.PushAsync(new HistorijaVoznjiDetails(content)); 
        }
    }
}