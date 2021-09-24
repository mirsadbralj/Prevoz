using Prevoz.MobileApp.Views;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model.Requests.Vožnja;
using Prevoz.MobileApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prevoz.MobileApp.ViewModels
{
    public class PonudiVoznjuViewModel : BaseViewModel
    {
        private readonly ApiService _feedbacks = new ApiService("feedback");
        private readonly ApiService _vozilo = new ApiService("vozilo");
        private readonly ApiService _lokacija = new ApiService("lokacija");
        private readonly ApiService _voznja = new ApiService("voznja");
        public ObservableCollection<Vozilo> VozilaList { get; set; } = new ObservableCollection<Vozilo>();
        public ObservableCollection<int> BrojSjedistaList { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<string> OCAutomatskoOdobrenje { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> OCCigarete { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> OCKucniLjubimci { get; set; } = new ObservableCollection<string>();
        public Command Ponudi { get; set; }
        public Command Objavi { get; set; }

        public string automatskoOdobrenje = string.Empty;
        public string cigarete = string.Empty;
        public string kucniLjubimci = string.Empty;
        public string _PolaznaLokacija = string.Empty;
        public string _destinacija = string.Empty;
        public string _vozila = string.Empty;
        public string detaljnije = string.Empty;
        public decimal _cijenaSjedista;
        

        public DateTime _MinDatetime = DateTime.Now;

        public TimeSpan Time = new TimeSpan();
        public void SetOCS()
        {
            OCAutomatskoOdobrenje.Add("DA");
            OCAutomatskoOdobrenje.Add("NE");

            OCCigarete.Add("DA");
            OCCigarete.Add("NE");

            OCKucniLjubimci.Add("DA");
            OCKucniLjubimci.Add("NE");
        }
        public PonudiVoznjuViewModel()
        {
            Ponudi = new Command(async () => await PonudiVoznju());
            Objavi = new Command(async () => await ObjaviVoznju());
        }
        public Vozilo _voziloSelected = new Vozilo();

        public int BrojSjedista = 0;
        public DateTime _DatumVoznje = new DateTime();

        public string AutomatskoOdobrenje
        {
            get { return automatskoOdobrenje; }
            set { SetProperty(ref automatskoOdobrenje, value); }
        }
        public string Cigarete
        {
            get { return cigarete; }
            set { SetProperty(ref cigarete, value); }
        }
        public string KucniLjubimci
        {
            get { return kucniLjubimci; }
            set { SetProperty(ref kucniLjubimci, value); }
        }
        public string Detaljnije
        {
            get { return detaljnije; }
            set { SetProperty(ref detaljnije, value); }
        }
        public TimeSpan VrijemeVoznje
        {
            get { return Time; }
            set { SetProperty(ref Time, value); }
        }
        public DateTime MinimumDateTime
        {
            get { return _MinDatetime; }
            set { SetProperty(ref _MinDatetime, value); }
        }
        public decimal cijenaSjedista
        {
            get { return _cijenaSjedista; }
            set { SetProperty(ref _cijenaSjedista, value); }
        }
        public string destinacija
        {
            get { return _destinacija; }
            set { SetProperty(ref _destinacija, value); }
        }
        public string PolaznaLokacija
        {
            get { return _PolaznaLokacija; }
            set { SetProperty(ref _PolaznaLokacija, value); }
        }
        public Vozilo voziloSelected  
        { 
            get { return _voziloSelected; }
            set { SetProperty(ref _voziloSelected, value); }

        }
        public int BrojSjedistaSelected
        {
            get { return BrojSjedista; }
            set { SetProperty(ref BrojSjedista, value); }
        }
        public DateTime DatumVoznje
        {
            get { return _DatumVoznje; }
            set { SetProperty(ref _DatumVoznje, value); }
        }
        private async Task LoadListaVozila()
        {
            var korisnici = Memorija.Korisnik;
            var request = new VoznjaSearchRequest();
            var vozila = await _vozilo.Get<List<Model.Vozilo>>(request);
            var Vozila = new List<Vozilo>();

            for (int i = 0; i < vozila.Count(); i++)
            {
                if (vozila[i].KorisnikId.ToString() == korisnici.KorisnikId.ToString())
                {
                    Vozila.Add(vozila[i]);
                }
            }

            foreach(var vozilo in Vozila)
            {
                VozilaList.Add(vozilo);
            }

            for (int i = 1; i <= 10; i++)
            {
                BrojSjedistaList.Add(i);
            }
        }

        public async Task ObjaviVoznju()
        {
            if (voziloSelected.Naziv != null && BrojSjedista > 0) 
            {
                var LokacijaStart = new LokacijaUpsertRequest()
                {
                    Naziv = PolaznaLokacija,
                    Latitude = null,
                    Longitude= null,
                    PostalCode = null
                };
                var LokacijaEnd = new LokacijaUpsertRequest()
                {
                    Naziv = destinacija,
                    Latitude = null,
                    Longitude = null,
                    PostalCode = null
                };
                var start = await _lokacija.Insert<Lokacija>(LokacijaStart);
                var end = await _lokacija.Insert<Lokacija>(LokacijaEnd);

                var korisnici = Memorija.Korisnik;
                var var = korisnici.KorisnikId;

                var vozilo = voziloSelected;

                if (DatumVoznje == DateTime.MinValue)
                    DatumVoznje = _MinDatetime;

                DatumVoznje = DatumVoznje.Date + VrijemeVoznje;

                var datum = _DatumVoznje.TimeOfDay.Add(VrijemeVoznje);
                CultureInfo cultures = new CultureInfo("en-US");
                var request = new VoznjaUpsertRequest()
                {
                    KorisnikId = korisnici.KorisnikId,
                    StartId = start.LokacijaId,
                    EndId = end.LokacijaId,
                    VoziloId = voziloSelected.VoziloId,
                    CijenaSjedista = Convert.ToDecimal(cijenaSjedista, cultures),
                    BrojSjedista = BrojSjedista,
                    AutomatskoOdobrenje = AutomatskoOdobrenje,
                    Cigarete = Cigarete,
                    KucniLjubimci = KucniLjubimci,
                    Detaljnije = Detaljnije,
                    Status = true,
                    DatumVoznje = DatumVoznje
                };
                await _voznja.Insert<Model.Voznja>(request);
                var feedback = await _feedbacks.Get<List<Model.Feedback>>(null);
                var korisnik = Memorija.Korisnik;
                bool ocijenio = false;
                foreach (var item in feedback)
                {
                    if (item.KorisnikId == korisnik.KorisnikId)
                        ocijenio = true;
                }
                if (!ocijenio)
                {
                    var result = await Application.Current.MainPage.DisplayAlert("Vaša vožnja je uspješno objavljena.", "Da li želite ocijeniti kvalitet korištenja aplikacije", "DA", "NE");
                    if(result)
                    await Application.Current.MainPage.Navigation.PushAsync(new LeaveFeedbackPage());
                }
                else
                    await Application.Current.MainPage.DisplayAlert("", "Vaša vožnja je uspješno objavljena", "OK");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Greška", "Niste popunili sva odgovarajuća polja forme.", "OK");
        }
        public async Task PonudiVoznju()
        {
            VozilaList.Clear();
            await LoadListaVozila();
        }
    }
}