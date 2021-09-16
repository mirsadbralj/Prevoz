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
    public partial class ListFaqPage : ContentPage
    {
        private FAQViewModel model = null;

        public ListFaqPage()
        {
            InitializeComponent();
            BindingContext = model = new FAQViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.FAQ_Load();
        }
    }
}