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
    public partial class MojeOcjene : ContentPage
    {
        public ListMojeOcjeneViewModel model = null;
        public MojeOcjene()
        {
            InitializeComponent();
            BindingContext = model = new ListMojeOcjeneViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.GetListaOcjena();
        }
    }


}