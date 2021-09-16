using Prevoz.Model;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Vožnja;
using Stripe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prevoz.MobileApp.ViewModels
{
    public class HomeViewModel
    {
        private readonly ApiService _rezervacije = new ApiService("korisnikrezervacija");
        private readonly ApiService _voznje = new ApiService("voznja");
        private readonly ApiService _lokacije= new ApiService("lokacija");
        private readonly ApiService _korisnik = new ApiService("korisnik");
        public HomeViewModel()
        {
        }
        public ObservableCollection<Voznja> listaVoznji { get; set; } = new ObservableCollection<Voznja>();
        public async Task GetRezervacije()
        {
            listaVoznji.Clear();
            var RezRequest = new KorisnikRezervacijaSearchRequest()
            {
                KorisnikId = Memorija.Korisnik.KorisnikId
            };
            var listaRezervacija = await _rezervacije.Get<List<KorisnikRezervacija>>(RezRequest);

            var voznje = await _voznje.Get<List<Voznja>>(null);
            var lokacije = await _lokacije.Get<List<Lokacija>>(null);

            List<Voznja> listaTrazenihVoznji = new List<Voznja>();
            List<Lokacija> listaTrazenihPolaznihLokacija = new List<Lokacija>();
            List<Lokacija> listaTrazenihDestinacijskihLokacija = new List<Lokacija>();

            List<Lokacija> AktivnolistaTrazenihPolaznihLokacija = new List<Lokacija>();
            List<Lokacija> AktivnolistaTrazenihDestinacijskihLokacija = new List<Lokacija>();

            var rezervacijeIDs = listaRezervacija.Select(x => x.VoznjaId).ToList();
            listaTrazenihVoznji = voznje.Where(x => rezervacijeIDs.Contains(x.VoznjaId)).ToList();
            
            var voznjaStartIDs = voznje.Select(x => x.StartId);
            var voznjaEndIDs = voznje.Select(x => x.EndId);
           
            listaTrazenihPolaznihLokacija = lokacije.Where(x => voznjaStartIDs.Contains(x.LokacijaId)).ToList();
            listaTrazenihDestinacijskihLokacija = lokacije.Where(x => voznjaEndIDs.Contains(x.LokacijaId)).ToList();
            
            
            List<Voznja> listaTrazenihAktivnihVoznji = new List<Voznja>();
            listaTrazenihAktivnihVoznji = voznje.Where(x => x.Status == true && x.DatumVoznje.Date>=DateTime.Now.Date).ToList();
            voznjaStartIDs = listaTrazenihVoznji.Select(x => x.StartId);
            voznjaEndIDs = listaTrazenihVoznji.Select(x => x.EndId);
            
            AktivnolistaTrazenihPolaznihLokacija = lokacije.Where(x => voznjaStartIDs.Contains(x.LokacijaId)).ToList();
            AktivnolistaTrazenihDestinacijskihLokacija = lokacije.Where(x => voznjaEndIDs.Contains(x.LokacijaId)).ToList();
            
            var listTPL = listaTrazenihPolaznihLokacija.Select(x => x.Naziv).ToList();
            AktivnolistaTrazenihPolaznihLokacija = AktivnolistaTrazenihPolaznihLokacija.Where(x => x.Naziv !=null && listTPL.Contains(x.Naziv)).ToList();

            var listpolaznih = AktivnolistaTrazenihPolaznihLokacija.Select(x => x.LokacijaId).ToList();

            List<Voznja> listaVoznjiFinal = new List<Voznja>();

            var IDsPolazne = AktivnolistaTrazenihPolaznihLokacija.Select(x => x.LokacijaId).ToList();
            listaTrazenihAktivnihVoznji = listaTrazenihAktivnihVoznji.Where(x => IDsPolazne.Contains(x.StartId)).ToList();

            var IDsDestinacijske = AktivnolistaTrazenihDestinacijskihLokacija.Select(x => x.LokacijaId).ToList();
            listaTrazenihAktivnihVoznji = listaTrazenihAktivnihVoznji.Where(x => IDsDestinacijske.Contains(x.EndId)).ToList();

            foreach (var item in listaTrazenihAktivnihVoznji)
                listaVoznji.Add(item);
        }
    }
}
