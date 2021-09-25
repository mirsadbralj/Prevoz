using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Ocjena;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Prevoz.MobileApp.ViewModels
{
    public class OcijeniKorisnikaViewModel : BaseViewModel
    {
        string komentar = string.Empty;
        string username = string.Empty;
        public int EOcjena = new int();
        private readonly ApiService _korisnici = new ApiService("korisnik");
        private readonly ApiService _ocjena = new ApiService("ocjena");
        public Korisnik _korisnik = new Korisnik();
        public KorisnikRezervacija _rezervacija;
        public Voznja _voznja = new Voznja();
        public ObservableCollection<int> OcjeneList { get; set; } = new ObservableCollection<int>();
        public string Komentar
        {
            get { return komentar; }
            set { SetProperty(ref komentar, value); }
        }
        public int OcjenaSelected
        {
            get => EOcjena;
            set => SetProperty(ref EOcjena, value);
        }
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }
        public OcijeniKorisnikaViewModel()
        {

        }
        public void LoadOcjeneList()
        {
            OcjeneList.Add(1);
            OcjeneList.Add(2);
            OcjeneList.Add(3);
            OcjeneList.Add(4);
            OcjeneList.Add(5);
        }
        public OcijeniKorisnikaViewModel(KorisnikRezervacija rezervacija, Korisnik korisnik)
        {
            _korisnik = korisnik;
            _rezervacija = rezervacija;
            LoadKorisnika = new Command(async () => await LoadKorisnik());
            SaveRating = new Command(async () => await SaveOcjena());
        }

        public OcijeniKorisnikaViewModel(Voznja voznja, Korisnik korisnik)
        {
            _korisnik = korisnik;
            _voznja = voznja;
            LoadKorisnika = new Command(async () => await LoadKorisnik());
            SaveRating = new Command(async () => await SaveOcjena());
        }
        public ICommand LoadKorisnika { get; set; }
        public ICommand SaveRating { get; set; }
        public ICommand SaveOcjenaVoznjaCommand { get; set; }
        public ICommand GetKorisnikInfoCommand { get; set; }
        public async Task LoadKorisnik()
        {
            LoadOcjeneList();
            var korisnik = await _korisnici.GetById<Model.Korisnik>(_korisnik.KorisnikId);
            Username = korisnik.UserName;
        }
        private async Task SaveOcjena()
        {
            var korisnik = Memorija.Korisnik;
            if (_rezervacija == null) 
            {
                await SaveOcjenaVoznja();
                return;

            }
            
            var requestOcjena = new OcjenaUpsertRequest()
            {
                VoznjaId = null,
                KorisnikId = korisnik.KorisnikId,
                RezervacijaId = _rezervacija.RezervacijaId,
                Ocjena1 = OcjenaSelected,
                Komentar = Komentar
            };
            await _ocjena.Insert<Model.Ocjena>(requestOcjena);
            await Application.Current.MainPage.DisplayAlert("Ocjena uspješno sačuvana", "", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private async Task SaveOcjenaVoznja() 
        {
            var korisnik = Memorija.Korisnik;
            
            var requestOcjena = new OcjenaUpsertRequest()
            {
                VoznjaId = _voznja.VoznjaId,
                KorisnikId = korisnik.KorisnikId,
                RezervacijaId = null,
                Ocjena1 = OcjenaSelected,
                Komentar = Komentar
            };
            await _ocjena.Insert<Model.Ocjena>(requestOcjena);
            await Application.Current.MainPage.DisplayAlert("Ocjena uspješno sačuvana", "", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
