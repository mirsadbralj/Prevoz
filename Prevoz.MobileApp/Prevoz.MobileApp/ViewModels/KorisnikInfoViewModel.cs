using Android.Content.Res;
using Prevoz.MobileApp.Views;
using Prevoz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prevoz.MobileApp.ViewModels
{
    public class KorisnikInfoViewModel : BaseViewModel
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _korisnikDetails = new ApiService("korisnikdetail");
        private readonly ApiService _ocjene = new ApiService("ocjena");
        private readonly ApiService _rezervacije = new ApiService("korisnikrezervacija");
        private readonly ApiService _voznje = new ApiService("voznja");
        Voznja _voznja = new Voznja();

        string _Ime = string.Empty;
        string _Prezime = string.Empty;
        string _korisnickoIme = string.Empty;
        string _datumRodenja = string.Empty;
        string _datumKreiranja = string.Empty;
        decimal prosjek = 0;
        int _korisnikID = 0;
        public ObservableCollection<Ocjena> listOcjene { get; set; } = new ObservableCollection<Ocjena>();
        public byte[] userImage { get; set; }
        int _KorisnikID = 0;
        public KorisnikInfoViewModel()
        {

        }
        public KorisnikInfoViewModel(int KorisnikID)
        {
            _KorisnikID = KorisnikID;
            GetKorisnikInfoCommand = new Command(async () => await GetInfo());
        }
        public string Ime
        {
            get => _Ime;
            set => SetProperty(ref _Ime, value);
        }
        public string Prezime
        {
            get => _Prezime;
            set => SetProperty(ref _Prezime, value);
        }
        public string KorisnickoIme
        {
            get => _korisnickoIme;
            set => SetProperty(ref _korisnickoIme, value);
        }
        public string DatumRodjenja
        {
            get => _datumRodenja;
            set => SetProperty(ref _datumRodenja, value);
        }
        public string DatumKreiranja
        {
            get => _datumKreiranja;
            set => SetProperty(ref _datumKreiranja, value);
        }
        public decimal ProsjecnaOcjena
        {
            get => prosjek;
            set => SetProperty(ref prosjek, value);
        }
        public byte[] UserImage
        {
            get { return userImage; }
            set
            {
                if (value != userImage)
                {
                    userImage = value;
                    OnPropertyChanged("UserImage");
                }
            }
        }
        public ICommand GetKorisnikInfoCommand { get; set; }
        public ICommand BackCommand { get;  set; }
        public async Task GetInfo()
        {
            if (_korisnikID != 0)
                _KorisnikID = _korisnikID;

            var korisnik = await _korisnik.GetById<Model.Korisnik>(_KorisnikID);
            KorisnikDetails korisnikDetails = await _korisnikDetails.GetById<Model.KorisnikDetails>(_KorisnikID);
            var ocjene = await _ocjene.Get<List<Ocjena>>(null);
            
            if(korisnik!=null && korisnik.Slika!=null)
            UserImage = korisnik.Slika;

            if (korisnikDetails != null)
            {
                Ime = korisnikDetails.Ime;
                Prezime = korisnikDetails.Prezime;
                DatumRodjenja = korisnikDetails.DatumRođenja.ToString();
            }
            else
            {
                Ime = " ";
                Prezime = " ";
                DatumRodjenja = DateTime.Now.ToString();
            }
            KorisnickoIme = korisnik.UserName;
           
            DatumKreiranja = korisnik.CreatedAt.ToString();
            GetKorisnikOcjene(ocjene);
        }
        private async void GetKorisnikOcjene(List<Ocjena> ocjene)
        {
            listOcjene.Clear();
            List<Ocjena> _listaOcjena = new List<Ocjena>();
            List<Voznja> _listaVoznji = new List<Voznja>();
            List<KorisnikRezervacija> _listaRezervacija = new List<KorisnikRezervacija>();

            var listaRezervacija = await _rezervacije.Get<List<Model.KorisnikRezervacija>>(null);
            var listaVoznji = await _voznje.Get<List<Model.Voznja>>(null);

            for (int i = 0; i < listaRezervacija.Count(); i++)
            {
                for (int j = 0; j < ocjene.Count(); j++)
                {
                    if (ocjene[j].RezervacijaId == listaRezervacija[i].RezervacijaId && listaRezervacija[i].KorisnikId == _KorisnikID)
                    {
                        listOcjene.Add(ocjene[j]);
                        _listaOcjena.Add(ocjene[j]);
                        _listaRezervacija.Add(listaRezervacija[i]);
                    }
                }
            }
            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                for (int j = 0; j < ocjene.Count(); j++)
                {
                    if (ocjene[j].VoznjaId == listaVoznji[i].VoznjaId && listaVoznji[i].KorisnikId == _KorisnikID)
                    {
                        listOcjene.Add(ocjene[j]);
                        _listaVoznji.Add(listaVoznji[i]);
                        _listaOcjena.Add(ocjene[j]);
                    }
                }
            }
            decimal ocjena=0;
            if (_listaOcjena.Count() > 0)
                ocjena = GetProsjek(_listaOcjena);
            else
                ocjena = 0;
            ProsjecnaOcjena = decimal.Round(ocjena, 2);
        }
        private decimal GetProsjek(List<Model.Ocjena> ocjene)
        {
            decimal suma = 0;
            decimal prosjek = 0;
            int brojac = 0;
            for (int i = 0; i < ocjene.Count(); i++)
            {
                suma += (decimal)ocjene[i].Ocjena1;
                brojac++;
            }
            prosjek = suma / brojac;
            return prosjek;
        }
    }
}