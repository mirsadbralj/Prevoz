using Prevoz.Model;
using Prevoz.Model.Requests.Rezervacija;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.MobileApp.ViewModels
{
    public class ListNeocijenjeneVoznjeViewModel : BaseViewModel
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _rezervacije = new ApiService("korisnikrezervacija");
        private readonly ApiService _ocjena = new ApiService("ocjena");
        private readonly ApiService _voznja = new ApiService("voznja");
        public ListNeocijenjeneVoznjeViewModel()
        {
        }
        public List<Voznja> NeocijenjeneVoznje { get; set; } = new List<Voznja>();

        public ObservableCollection<Korisnik> OcijeniPreostaleVoznjeListKorisnika { get; set; } = new ObservableCollection<Korisnik>();

        public async Task GetKorisnike()
        {
            OcijeniPreostaleVoznjeListKorisnika.Clear();

            var korisnik = Memorija.Korisnik;

            var RezervacijeRequest = new KorisnikRezervacijaSearchRequest() { KorisnikId = korisnik.KorisnikId };
            var listaRezervacija = await _rezervacije.Get<List<Model.KorisnikRezervacija>>(RezervacijeRequest);
            var listaVoznji = await _voznja.Get<List<Voznja>>(null);

            var ocjene = await _ocjena.Get<List<Ocjena>>(null);

            if (listaRezervacija.Count() > 0 && listaVoznji!=null && listaVoznji.Count > 0)
                Set_OBC_ListaPreostalihNeocijenjenihVoznji(ocjene, listaVoznji, listaRezervacija);
        }
        private async void Set_OBC_ListaPreostalihNeocijenjenihVoznji(List<Ocjena> ocjene, List<Voznja> listaVoznji, List<KorisnikRezervacija> listaRezervacija)
        {
            var MojaListaRezervacija = listaRezervacija.Where(x=>x.KorisnikId == Memorija.Korisnik.KorisnikId);

            var MojeOcjeneZaVoznje = ocjene.Where(x => x.VoznjaId != null && x.KorisnikId == Memorija.Korisnik.KorisnikId);

            var MojeOcjeneVoznjeIDs = MojeOcjeneZaVoznje.Select(x=>x.VoznjaId).ToList();

            MojaListaRezervacija = MojaListaRezervacija.Where(x => !MojeOcjeneVoznjeIDs.Contains(x.VoznjaId)).ToList();

            var NeocijenjeneVoznjeIDs = MojaListaRezervacija.Select(x => x.VoznjaId).ToList();

            listaVoznji = listaVoznji.Where(x => NeocijenjeneVoznjeIDs.Contains(x.VoznjaId)).ToList();

            List<Korisnik> korisnici = new List<Korisnik>();
            foreach(var item in listaVoznji)
            {
                Korisnik korisnik = await _korisnik.GetById<Model.Korisnik>(item.KorisnikId);
                korisnici.Add(korisnik);
            }
            NeocijenjeneVoznje = listaVoznji;
            List<Korisnik> korisniciUnikatni = new List<Korisnik>();

            foreach(var item in korisnici)
            {
                if (korisniciUnikatni.Any(x => x.KorisnikId == item.KorisnikId))
                    continue;

                korisniciUnikatni.Add(item);
            }

            foreach (var item in korisniciUnikatni)
            {
                Korisnik korisnik = await _korisnik.GetById<Model.Korisnik>(item.KorisnikId);
                OcijeniPreostaleVoznjeListKorisnika.Add(korisnik);
            }
        }
    }
}