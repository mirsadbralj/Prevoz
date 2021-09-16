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
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.LoadCollectionListaOcjena();
        }
    }
}