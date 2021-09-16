using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.MobileApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Prevoz.Model.Requests.Vožnja;

namespace Prevoz.MobileApp.ViewModels
{
    public class HistorijaVoznjiViewModel:BaseViewModel
    {
        private readonly ApiService _voznje = new ApiService("voznja");
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _rezervacija = new ApiService("korisnikrezervacija");
        public HistorijaVoznjiViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Voznja> PonudeneVoznjeList { get; set; } = new ObservableCollection<Voznja>();
        public ObservableCollection<Voznja> RezervisaneVoznjeList { get; set; } = new ObservableCollection<Voznja>();

        public double UkupniPrihodiOdVoznjeSum = 0;
        public double UkupniTroskoviRezervacijaSum = 0;
        public string prikaziPrihode = string.Empty;
        public string prikaziTroskove = string.Empty;

        public ICommand InitCommand { get; set; }

        public string PrikaziPrihode
        {
            get { return prikaziPrihode; }
            set { SetProperty(ref prikaziPrihode, value); }
        }
        public string PrikaziTroskove
        {
            get { return prikaziTroskove; }
            set { SetProperty(ref prikaziTroskove, value); }
        }
        public async Task GetUkupneTroskove()
        {
            UkupniTroskoviRezervacijaSum = 0;
            var rezervacijeRequest = new KorisnikRezervacijaSearchRequest()
            {
                KorisnikId = Memorija.Korisnik.KorisnikId
            };
            var listaRezervacija = await _rezervacija.Get<List<Model.KorisnikRezervacija>>(rezervacijeRequest);
            List<double> UkupniTroskoviRezervacija = new List<double>();
            foreach (KorisnikRezervacija rezervacija in listaRezervacija)
            {
                UkupniTroskoviRezervacija.Add(Convert.ToDouble(rezervacija.UkupnoPlaceno));
            }
            foreach (var item in UkupniTroskoviRezervacija)
                UkupniTroskoviRezervacijaSum += item;

            PrikaziTroskove = UkupniTroskoviRezervacijaSum.ToString() + "€";
        }
        public async Task GetUkupnePrihode()
        {
            UkupniPrihodiOdVoznjeSum = 0;
            var voznjaRequest = new VoznjaSearchRequest()
            {
                VoznjaId = 0,
                StartId = null,
                EndId = null,
                DatumVoznje = DateTime.MinValue,
                KorisnikId = Memorija.Korisnik.KorisnikId
            };
            var listaVoznji = await _voznje.Get<List<Model.Voznja>>(voznjaRequest);

            var listaRezervacija = await _rezervacija.Get<List<Model.KorisnikRezervacija>>(null);

            var listaVoznjiIDs = listaVoznji.Select(x => x.VoznjaId);
            listaRezervacija = listaRezervacija.Where(x => listaVoznjiIDs.Contains(x.VoznjaId)).ToList();


            List<double> UkupniPrihodiOdVoznji = new List<double>();
            foreach(KorisnikRezervacija rezervacija in listaRezervacija)
            {
                UkupniPrihodiOdVoznji.Add(Convert.ToDouble(rezervacija.UkupnoPlaceno));
            }

            foreach (var item in UkupniPrihodiOdVoznji)
                UkupniPrihodiOdVoznjeSum += item;

            PrikaziPrihode = UkupniPrihodiOdVoznjeSum.ToString() + "€";
        }
        public async Task Init()
        {
            PonudeneVoznjeList.Clear();
            RezervisaneVoznjeList.Clear();

            var korisnik = Memorija.Korisnik;

            var voznje = await _voznje.Get<List<Model.Voznja>>(null);

            var rezervacijerequest = new KorisnikRezervacijaSearchRequest() { KorisnikId = korisnik.KorisnikId };

            var rezervacije = await _rezervacija.Get<List<Model.KorisnikRezervacija>>(rezervacijerequest);

            List<Model.Voznja> _listaPonudenihVoznji = new List<Model.Voznja>();
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();

            if (voznje.Count() > 0)
                _listaPonudenihVoznji = GetHistorijaPonudenihVoznji(voznje, korisnik.KorisnikId);

            if (voznje.Count() > 0 && rezervacije.Count > 0)
                _listaVoznji = GetHistorijaRezervisanihVoznji(voznje, rezervacije, korisnik);

            foreach (var voznja in _listaPonudenihVoznji)
            {
                PonudeneVoznjeList.Add(voznja);
            }
            foreach (var voznja in _listaVoznji)
            {
                RezervisaneVoznjeList.Add(voznja);
            }
        }
        private List<Model.Voznja> GetHistorijaRezervisanihVoznji(List<Model.Voznja> listaVoznji, List<Model.KorisnikRezervacija> listaRezervacija, Model.Korisnik korisnik)
        {
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();
            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                for (int j = 0; j < listaRezervacija.Count(); j++)
                {
                    if (listaVoznji[i].VoznjaId == listaRezervacija[j].VoznjaId && listaRezervacija[j].KorisnikId == korisnik.KorisnikId)
                    {
                        _listaVoznji.Add(listaVoznji[i]);
                    }
                }
            }
            _listaVoznji = CleanDuplicates(_listaVoznji);

            return _listaVoznji;
        }
        private List<Model.Voznja> GetHistorijaPonudenihVoznji(List<Model.Voznja> listaVoznji, int KorisnikId)
        {
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();
            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                if (listaVoznji[i].KorisnikId == KorisnikId)
                {
                    _listaVoznji.Add(listaVoznji[i]);
                }
            }
            return _listaVoznji;
        }
        private List<Model.Voznja> CleanDuplicates(List<Model.Voznja> listaVoznji)
        {
            List<Model.Voznja> listaVoznjiWithoutDuplicates = new List<Model.Voznja>();
            listaVoznjiWithoutDuplicates.Add(listaVoznji[0]);
            bool duplicate = false;
            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                duplicate = false;
                for (int j = 0; j < listaVoznjiWithoutDuplicates.Count(); j++)
                {
                    if (listaVoznji[i].VoznjaId == listaVoznjiWithoutDuplicates[j].VoznjaId)
                    {
                        duplicate = true;
                    }
                }
                if (duplicate == false)
                    listaVoznjiWithoutDuplicates.Add(listaVoznji[i]);
            }
            return listaVoznjiWithoutDuplicates;
        }
    }
}
