using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.FAQ;
using Prevoz.MobileApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prevoz.MobileApp.ViewModels
{
    public class FAQViewModel : BaseViewModel
    {
        private readonly ApiService _Faq = new ApiService("faq");
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private int brojacIStih;
        string _pitanje = string.Empty;
        string _odgovor = string.Empty;
        public ObservableCollection<Faq> listFaq { get; set; } = new ObservableCollection<Faq>();
        public string pitanje
        {
            get { return _pitanje; }
            set { SetProperty(ref _pitanje, value); } 
        }
        public string odgovor
        {
            get { return _odgovor; }
            set { SetProperty(ref _odgovor, value); }
        }
        public FAQViewModel()
        {
            FaqListCommand = new Command(async () => await FaqList());
        }
        public ICommand FaqListCommand { get; set; }
        public async Task FaqList()
        {
           
            var korisnik = Memorija.Korisnik;

            var FAQ = await _Faq.Get<List<Faq>>(null);
            
            var request = new FaqUpsertRequest();
            var insert = new FaqUpsertRequest()
            {
                KorisnikId = korisnik.KorisnikId,
                Pitanje = pitanje
            };

            for (int i = 0; i <FAQ.Count(); i++)
            {
                if (insert.Pitanje == FAQ[i].Pitanje)
                {
                    brojacIStih++;
                }
            }
            if (brojacIStih >= 4)
            {
                await Application.Current.MainPage.DisplayAlert("Hvala na pitanju", "Ukoliko se odgovor još uvijek ne nalazi u sekciji molimo vas za strpljenje.\nHvala!", "OK");
                return;
            }
            if (brojacIStih <= 3)
            {
                await _Faq.Insert<Model.Faq>(insert);
            }
        }
        public async Task FAQ_Load()
        {
            var search = new FaqUpsertRequest();
            var list = await _Faq.Get<List<Model.Faq>>(search);
            var result = list;


            list = list.Where(x => x.Pitanje != "" && x.Pitanje != null).ToList();

            list = list.Where(x => x.Odgovor != "" && x.Odgovor != null).ToList();

            var listaPitanja = list.Select(x => x.Pitanje).Distinct();

            list = list.Where(x => listaPitanja.Contains(x.Pitanje)).ToList();


            foreach(var item in list)
            {
                listFaq.Add(item);
            }
        }
    }
}