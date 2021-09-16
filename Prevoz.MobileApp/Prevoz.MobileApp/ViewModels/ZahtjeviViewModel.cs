using Acr.UserDialogs;
using Prevoz.Model;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Vožnja;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prevoz.MobileApp.ViewModels
{
    public class ZahtjeviViewModel
    {
        private readonly ApiService _voznje = new ApiService("voznja");
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _zahtjevi = new ApiService("zahtjevi");
        private readonly ApiService _korisnikRezervacija = new ApiService("korisnikrezervacija");
        public int KorisnikID = -1;
        public ZahtjeviViewModel()
        {
        }
        public ObservableCollection<Zahtjevi> listaZahtjeva { get; set; } = new ObservableCollection<Zahtjevi>();
        public ObservableCollection<Zahtjevi> listaZahtjevaPrihvaceni { get; set; } = new ObservableCollection<Zahtjevi>();
        public ObservableCollection<Zahtjevi> listaZahtjevaOtkazani { get; set; } = new ObservableCollection<Zahtjevi>();
        public async Task GetZahtjeve()
        {
            listaZahtjeva.Clear();
            listaZahtjevaPrihvaceni.Clear();
            listaZahtjevaOtkazani.Clear();
            
            var voznjeRequest = new VoznjaSearchRequest()
            {
                KorisnikId = Memorija.Korisnik.KorisnikId
            };
            var listaVoznji = await _voznje.Get<List<Model.Voznja>>(voznjeRequest);
            var VoznjeIDs = listaVoznji.Select(x => x.VoznjaId);
            var listazahtjeva = await _zahtjevi.Get<List<Zahtjevi>>(null);

            listazahtjeva = listazahtjeva.Where(x => VoznjeIDs.Contains(x.VoznjaID)).ToList();

            var listazahtjevaprihvaceni = listazahtjeva.Where(x => x.Status == "Odobreno").ToList();
            var listazahtjevaotkazani= listazahtjeva.Where(x => x.Status == "Otkazano").ToList();
            listazahtjeva = listazahtjeva.Where(x => x.Status != "Odobreno" && x.Status != "Otkazano").ToList();

            foreach (var item in listazahtjeva.ToList())
                listaZahtjeva.Add(item);
            foreach (var item in listazahtjevaprihvaceni.ToList())
                listaZahtjevaPrihvaceni.Add(item);
            foreach (var item in listazahtjevaotkazani.ToList())
                listaZahtjevaOtkazani.Add(item);
        }
        public async void PonistiZahtjev(int zahtjevID)
        {
            var zahtjev = await _zahtjevi.GetById<Zahtjevi>(zahtjevID);
            zahtjev.Status = "Otkazano";
            await _zahtjevi.Update<Model.Zahtjevi>(zahtjevID, zahtjev);
        }
        public async void OdobriZahtjev(int zahtjevID)
        {
            var voznjeRequest = new VoznjaSearchRequest()
            {
                KorisnikId = Memorija.Korisnik.KorisnikId
            };
            var listaVoznji = await _voznje.Get<List<Model.Voznja>>(voznjeRequest);
            var VoznjeIDs = listaVoznji.Select(x => x.VoznjaId);
            var zahtjev = await _zahtjevi.GetById<Model.Zahtjevi>(zahtjevID);
            var listazahtjeva = await _zahtjevi.Get<List<Zahtjevi>>(null);
            var voznja = await _voznje.GetById<Model.Voznja>(zahtjev.VoznjaID);

            if (voznja.KorisnikId != zahtjev.KorisnikID)
            {
                if (voznja.BrojSjedista > 0)
                {
                    var requestRezervacija = new KorisnikRezervacijaUpsertRequest()
                    {
                        KorisnikId = zahtjev.KorisnikID,
                        VoznjaId = zahtjev.VoznjaID,
                        BrojSjedista = +1,
                        UkupnoPlaceno = voznja.CijenaSjedista,
                        DatumRezervacije = DateTime.Now
                    };
                    await _korisnikRezervacija.Insert<Model.KorisnikRezervacija>(requestRezervacija);
                    --voznja.BrojSjedista;
                    var UpdateRequestVoznja = new VoznjaUpsertRequest()
                    {
                        KorisnikId = voznja.KorisnikId,
                        VoziloId = voznja.VoziloId,
                        BrojSjedista = voznja.BrojSjedista,
                        CijenaSjedista = voznja.CijenaSjedista,
                        DatumVoznje = voznja.DatumVoznje,
                        AutomatskoOdobrenje = voznja.AutomatskoOdobrenje,
                        Cigarete = voznja.Cigarete,
                        KucniLjubimci = voznja.KucniLJubimci,
                        Detaljnije = voznja.Detaljnije,
                        StartId = voznja.StartId,
                        EndId = voznja.EndId,
                        Status = voznja.Status
                    };
                    await _voznje.Update<Model.Voznja>(voznja.VoznjaId, UpdateRequestVoznja);

                    zahtjev.Status = "Odobreno";
                    await _zahtjevi.Update<Model.Zahtjevi>(zahtjev.ZahtjevID, zahtjev);
                }
                else 
                {
                    zahtjev.Status = "Otkazano";
                    await _zahtjevi.Update<Model.Zahtjevi>(zahtjev.ZahtjevID, zahtjev);
                }
            }
        }
    }
}
