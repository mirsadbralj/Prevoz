using Prevoz.MobileApp.ViewModels;
using Prevoz.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prevoz.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistorijaVoznjiDetails : ContentPage
    {
        private HistorijaVoznjiDetailsViewModel model = null;

        Voznja _voznja = new Voznja();
        public HistorijaVoznjiDetails(Voznja voznja)
        {
            InitializeComponent();
            _voznja = voznja;
            BindingContext = model = new HistorijaVoznjiDetailsViewModel(voznja);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }     
    }
}