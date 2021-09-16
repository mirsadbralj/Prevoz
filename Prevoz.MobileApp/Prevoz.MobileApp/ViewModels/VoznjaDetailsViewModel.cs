using Prevoz.MobileApp.Views;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Vožnja;
using Prevoz.Model.Requests.Zahtjevi;
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
    public class VoznjaDetailsViewModel : BaseViewModel
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _voznja = new ApiService("voznja");
        private readonly ApiService _lokacija = new ApiService("lokacija");
        private readonly ApiService _korisnikRezervacija = new ApiService("korisnikrezervacija");
        private readonly ApiService _zahtjevi = new ApiService("zahtjevi");

        public ObservableCollection<Voznja> listaPreporucenihVoznji { get; set; } = new ObservableCollection<Voznja>();
        public Voznja voznja = new Voznja();
        public string _username = string.Empty;
        public string _polaznaLokacija = string.Empty;
        public string _destinacija = string.Empty;
        public string detaljnije = string.Empty;
        public string automatskoOdobrenje = string.Empty;
        public string cigarete = string.Empty;
        public string kucniLjubimci= string.Empty;
        public decimal _cijenaSjedista = 0;
        public int _preostaloSjedista = 0;
        public DateTime _datumVoznje = new DateTime();
        public string _status = string.Empty;
        public int voznjaId;
        public int _korisnikID;

        public ICommand GetKorisnikInfoCommand { get; set; }
        public VoznjaDetailsViewModel()
        {
        }
        public VoznjaDetailsViewModel(Voznja item)
        {
            DetaljiCommand = new Command(async () => await DetaljiVoznje());
            RezervisiCommand = new Command(async () => await Rezervacija());
            GetKorisnikInfoCommand = new Command(async () => await GetKorisnikInfo());
            voznjaId = item.VoznjaId;
            voznja = item;
        }
        public string Detaljnije
        {
            get { return detaljnije; }
            set { SetProperty(ref detaljnije, value); }
        }
        public string AutomatskoOdobrenje
        {
            get { return automatskoOdobrenje; }
            set { SetProperty(ref automatskoOdobrenje, value); }
        }
        public string KucniLjubimci
        {
            get { return kucniLjubimci; }
            set { SetProperty(ref kucniLjubimci, value); }
        }
        public string Cigarete
        {
            get { return cigarete; }
            set { SetProperty(ref cigarete, value); }
        }
        public string username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        public string polaznaLokacija
        {
            get { return _polaznaLokacija; }
            set { SetProperty(ref _polaznaLokacija, value); }
        }
        public string destinacija
        {
            get { return _destinacija; }
            set { SetProperty(ref _destinacija, value); }
        }
        public decimal cijenaSjedista
        {
            get { return _cijenaSjedista; }
            set { SetProperty(ref _cijenaSjedista, value); }
        }
        public int preostaloSjedista
        {
            get { return _preostaloSjedista; }
            set { SetProperty(ref _preostaloSjedista, value); }
        }
        public string status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
        public string DatumVoznje
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
        public Command DetaljiCommand { get; set; }
        public Command RezervisiCommand { get; set; }
        public async Task DetaljiVoznje()
        {
            var request = new VoznjaSearchRequest()
            {
                VoznjaId = voznjaId
            };
            var voznja = await _voznja.GetById<Model.Voznja>(voznjaId);

            var korisnik = await _korisnik.GetById<Model.Korisnik>(voznja.KorisnikId);
            var requestStartLocation = await _lokacija.GetById<Model.Lokacija>(voznja.StartId);
            var requestEndLocation = await _lokacija.GetById<Model.Lokacija>(voznja.EndId);

            _korisnikID = voznja.KorisnikId;
            username = korisnik.UserName;
            polaznaLokacija = requestStartLocation.Naziv;
            destinacija = requestEndLocation.Naziv;
            cijenaSjedista = voznja.CijenaSjedista;
            preostaloSjedista = (int)voznja.BrojSjedista;
            DatumVoznje = voznja.DatumVoznje.ToString();
            AutomatskoOdobrenje = voznja.AutomatskoOdobrenje;
            Cigarete = voznja.Cigarete;
            KucniLjubimci = voznja.KucniLJubimci;
            Detaljnije = voznja.Detaljnije;

            if (voznja.Status == true)
                status = "Aktivno";
            else
                status = "Završeno";
            await BindPreporuceneVoznje();
        }
        public async Task BindPreporuceneVoznje()
        {
            var preporuceneVoznje = await _voznja.GetAction<List<Voznja>>("PreporuciVoznje", new VoznjaSearchRequest
            {
                VoznjaId = voznja.VoznjaId
            });

            listaPreporucenihVoznji.Clear();

            foreach (var preporucenaVoznja in preporuceneVoznje)
            {
                if(preporucenaVoznja.Status==true && preporucenaVoznja.DatumVoznje.Date >= DateTime.Now.Date)
                listaPreporucenihVoznji.Add(preporucenaVoznja);
            }
        }
        public async Task Rezervacija()
        {
            var entityKorisnik = Memorija.Korisnik;

            var entityVoznja = await _voznja.GetById<Model.Voznja>(voznjaId);


            if(entityVoznja.AutomatskoOdobrenje == "NE")
            {
                var zahtjevRequest = new ZahtjeviUpsertRequest()
                {
                    VoznjaID = voznjaId,
                    KorisnikID = Memorija.Korisnik.KorisnikId,
                    Datum = DateTime.Now,
                    Status = null
                };
                await Application.Current.MainPage.DisplayAlert("Vožnja zahtjeva odobrenje od vozača.", "Zahtjev je poslan.\nUkoliko vozač odobri vašu rezervaciju možete je pronaći u rezervacijama", "OK");
                await _zahtjevi.Insert<Model.Zahtjevi>(zahtjevRequest);
            }
            else
            {
                if (voznja.KorisnikId != entityKorisnik.KorisnikId)
                {
                    if (entityVoznja.BrojSjedista > 0)
                    {
                        var requestRezervacija = new KorisnikRezervacijaUpsertRequest()
                        {
                            KorisnikId = entityKorisnik.KorisnikId,
                            VoznjaId = entityVoznja.VoznjaId,
                            BrojSjedista = +1,
                            UkupnoPlaceno = entityVoznja.CijenaSjedista,
                            DatumRezervacije = DateTime.Now
                        };
                        await _korisnikRezervacija.Insert<Model.KorisnikRezervacija>(requestRezervacija);
                        --entityVoznja.BrojSjedista;
                        var UpdateRequestVoznja = new VoznjaUpsertRequest()
                        {
                            KorisnikId = entityVoznja.KorisnikId,
                            VoziloId = entityVoznja.VoziloId,
                            BrojSjedista = entityVoznja.BrojSjedista,
                            CijenaSjedista = entityVoznja.CijenaSjedista,
                            DatumVoznje = entityVoznja.DatumVoznje,
                            AutomatskoOdobrenje = entityVoznja.AutomatskoOdobrenje,
                            Cigarete = entityVoznja.Cigarete,
                            KucniLjubimci = entityVoznja.KucniLJubimci,
                            Detaljnije = entityVoznja.Detaljnije,
                            StartId = entityVoznja.StartId,
                            EndId = entityVoznja.EndId,
                            Status = entityVoznja.Status
                        };
                        await _voznja.Update<Model.Voznja>(voznjaId, UpdateRequestVoznja);

                        await Application.Current.MainPage.DisplayAlert("", "Vožnja uspješno rezervisana", "OK");
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Rezervacija neuspješna", "Sva sjedišta su rezervisana", "OK");
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Rezervacija neuspješna", "Nije moguće rezervisati vlastitu vožnju", "OK");
            }
            
        }

        public async Task GetKorisnikInfo()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new KorisnikInfoPage(_korisnikID));
        }
    }
}