using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Ocjena;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Vožnja;
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
    public class ListNeocijenjeneRezervacijeViewModel : ContentPage
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _rezervacije = new ApiService("korisnikrezervacija");
        private readonly ApiService _ocjena = new ApiService("ocjena");
        private readonly ApiService _voznja = new ApiService("voznja");

        public List<KorisnikRezervacija> listaNeocijenjenihRezervacija { get; set; } = new List<KorisnikRezervacija>();
        public ListNeocijenjeneRezervacijeViewModel()
        {

        }
        public ObservableCollection<Model.Korisnik> OcijeniPreostaleRezervacijeListKorisnika { get; set; } = new ObservableCollection<Model.Korisnik>();

        public async Task GetKorisnike()
        {

            OcijeniPreostaleRezervacijeListKorisnika.Clear();

            var KorisnikRequest = new KorisniciSearchRequest() { UserName = ApiService.Username };
            var korisnik = Memorija.Korisnik;
            int IdKorisnikDet = korisnik.KorisnikId;
            var listaRezervacijaFull = await _rezervacije.Get<List<Model.KorisnikRezervacija>>(null);

            var RezervacijeRequest = new KorisnikRezervacijaSearchRequest() { KorisnikId = korisnik.KorisnikId };
            var listaRezervacija = await _rezervacije.Get<List<Model.KorisnikRezervacija>>(RezervacijeRequest);

            var VoznjaRequest = new VoznjaSearchRequest() { KorisnikId = korisnik.KorisnikId };
            var listaVoznji = await _voznja.Get<List<Model.Voznja>>(VoznjaRequest);

            var OcjeneRequest = new OcjenaSearchRequest() { };
            var ocjene = await _ocjena.Get<List<Model.Ocjena>>(OcjeneRequest);

            if (listaVoznji.Count() > 0)
                Set_OBC_listaPreostalihNeocijenjenihRezervacija(ocjene, listaVoznji, listaRezervacijaFull, korisnik);
        }
        private async void Set_OBC_listaPreostalihNeocijenjenihRezervacija(List<Model.Ocjena> ocjene, List<Model.Voznja> listaVoznji, List<Model.KorisnikRezervacija> listaRezervacija, Korisnik korisnik)
        {
            List<Model.Korisnik> _listaKorisnika = new List<Model.Korisnik>();
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();
            List<Model.KorisnikRezervacija> _listaRezervacija = new List<Model.KorisnikRezervacija>();
            List<Model.KorisnikRezervacija> _listaRezervacijaWithoutDuplicates = new List<Model.KorisnikRezervacija>();

            var voznjaRequeest = new VoznjaSearchRequest()
            {
                KorisnikId = Memorija.Korisnik.KorisnikId
            };
            _listaVoznji = await _voznja.Get<List<Model.Voznja>>(voznjaRequeest);

            if (_listaVoznji.Count > 0 && _listaVoznji != null)
            {
                _listaVoznji = _listaVoznji.Where(x => x.KorisnikId == Memorija.Korisnik.KorisnikId).ToList();

                var VoznjaIDs = _listaVoznji.Select(x => x.VoznjaId).ToList();
                _listaRezervacija = listaRezervacija;

                _listaRezervacija = listaRezervacija.Where(x => VoznjaIDs.Contains(x.VoznjaId)).ToList();
                _listaRezervacija = _listaRezervacija.Where(x => x.KorisnikId != Memorija.Korisnik.KorisnikId).ToList();

                var RezervacijeIDS = _listaRezervacija.Select(x => x.RezervacijaId);
                var OcijenjeniKorisnici = _listaRezervacija.Select(x => x.KorisnikId);

                ocjene = ocjene.Where(x => x.KorisnikId == Memorija.Korisnik.KorisnikId).ToList();
                var RezervacijeIDSOcjene = ocjene.Select(x => x.RezervacijaId);

                _listaRezervacija = listaRezervacija.Where(x => RezervacijeIDSOcjene.Contains(x.RezervacijaId)).ToList();
                var OcijenjeniKorisniciIDs = _listaRezervacija.Select(x => x.KorisnikId).Distinct().ToList();

                var _listarezervacijeTemp = listaRezervacija.Where(x => VoznjaIDs.Contains(x.VoznjaId)).ToList();
                _listarezervacijeTemp = _listarezervacijeTemp.Where(x => !RezervacijeIDSOcjene.Contains(x.RezervacijaId)).ToList();
                _listarezervacijeTemp = _listarezervacijeTemp.Where(x => x.KorisnikId != Memorija.Korisnik.KorisnikId).ToList();

                var NeocijenjeniKorisnikIDs = _listarezervacijeTemp.Select(x => x.KorisnikId).Distinct().ToList();

                NeocijenjeniKorisnikIDs = NeocijenjeniKorisnikIDs.Where(x => !OcijenjeniKorisniciIDs.Contains(x)).ToList();

                listaNeocijenjenihRezervacija = _listarezervacijeTemp;
                var rezervationIDs = _listarezervacijeTemp.Select(x => x.RezervacijaId);
                foreach (int item in NeocijenjeniKorisnikIDs)
                {
                    _listaKorisnika.Add(await _korisnik.GetById<Model.Korisnik>(item));
                }

                foreach (var item in _listaKorisnika)
                {
                    OcijeniPreostaleRezervacijeListKorisnika.Add(item);
                }

            }
        }
    }
}