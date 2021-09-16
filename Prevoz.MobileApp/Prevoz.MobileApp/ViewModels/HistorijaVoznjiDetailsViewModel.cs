using Prevoz.Model;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model.Requests.Rezervacija;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Prevoz.MobileApp.ViewModels
{
    public partial class HistorijaVoznjiDetailsViewModel:BaseViewModel
    {
        public string lokacijaStart = string.Empty;
        public string lokacijaDest = string.Empty;
        public string VozacIme = string.Empty;
        public string automobil = string.Empty;
        public string status = string.Empty ;
        public byte[] userImage { get; set; }
        DateTime datumVoznje = new DateTime();

        public ObservableCollection<Korisnik> listaPutnika { get; set; } = new ObservableCollection<Korisnik>();
        public HistorijaVoznjiDetailsViewModel(Voznja voznja)
        {
            _voznja = voznja;
            InitCommand = new Command(async () => await Init());
        }
        public HistorijaVoznjiDetailsViewModel()
        {
            
        }
        public byte[] Slika
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
        public string Vozilo
        {
            get => automobil;
            set => SetProperty(ref automobil, value);
        }
        public DateTime DatumVoznje
        {
            get => datumVoznje;
            set => SetProperty(ref datumVoznje, value);
        }
        public string Vozac
        {
            get => VozacIme;
            set => SetProperty(ref VozacIme, value);
        }
        public string LokacijaStart
        {
            get => lokacijaStart;
            set => SetProperty(ref lokacijaStart, value);
        }
        public string LokacijaDest
        {
            get => lokacijaDest;
            set => SetProperty(ref lokacijaDest, value);
        }
        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }
        private readonly ApiService _lokacija = new ApiService("lokacija");
        private readonly ApiService _voznje = new ApiService("voznja");
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _rezervacija = new ApiService("korisnikrezervacija");
        private readonly ApiService _vozilo = new ApiService("vozilo");
        
        Voznja _voznja = new Voznja();

        public ICommand InitCommand { get; set; }

        public void KorisnikFilter() {
            List<Korisnik> listaP = new List<Korisnik>();
            if (listaPutnika.Count > 0)
            {
                listaP.Add(listaPutnika[0]);

                for (int i = 1; i < listaPutnika.Count(); i++)
                {

                    bool duplicate = false;
                    for (int j = 0; j < listaP.Count(); j++)
                    {
                        if (listaPutnika[i].KorisnikId == listaP[j].KorisnikId)
                            duplicate = true;
                    }
                    if (duplicate == false)
                        listaP.Add(listaPutnika[i]);
                }
                listaPutnika.Clear();
                foreach (var item in listaP)
                {
                    listaPutnika.Add(item);
                }
            }
        }
        public async Task Init()
        {
            listaPutnika.Clear();
            var voznje = await _voznje.GetById<Voznja>(_voznja.VoznjaId);
            var rezervacijerequest = new KorisnikRezervacijaSearchRequest()
            {
                KorisnikId = _voznja.KorisnikId
            };
            var rezervacije = await _rezervacija.Get<List<KorisnikRezervacija>>(null); 
            var RezervacijeVoznje = rezervacije.Where(x => x.VoznjaId.Equals(_voznja.VoznjaId));

            foreach(var item in RezervacijeVoznje)
            {
                var korisnikL = await _korisnik.GetById<Model.Korisnik>(item.KorisnikId);
                listaPutnika.Add(korisnikL);
            }
            KorisnikFilter();
            var korisnik = await _korisnik.GetById<Korisnik>(_voznja.KorisnikId);

            if (_voznja.VoziloId != null)
            {
                var vozilo = await _vozilo.GetById<Vozilo>(_voznja.VoziloId);
                Vozilo = vozilo.Naziv;
            }

            Vozac = korisnik.UserName;
            DatumVoznje = _voznja.DatumVoznje;

            var _lokacijaStart = await _lokacija.GetById<Model.Lokacija>(_voznja.StartId);
            var _lokacijaEnd = await _lokacija.GetById<Model.Lokacija>(_voznja.EndId);

            LokacijaStart = _lokacijaStart.Naziv;
            LokacijaDest = _lokacijaEnd.Naziv;

            if (_voznja.Status == true)
                Status = "Aktivno";
            else
                Status = "Završeno";
        } 
        private double ConvertToDouble(string s)
        {
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (s != null)
                    if (!s.Contains(","))
                        result = double.Parse(s, CultureInfo.InvariantCulture);
                    else
                        result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception e)
            {
                try
                {
                    result = Convert.ToDouble(s);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
                    }
                    catch
                    {
                        throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return result;
        }
    }
}
