using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Ocjena;
using Prevoz.Model.Requests.Rezervacija;
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
    public class ListMojeOcjeneViewModel : ContentPage
    {
        private readonly ApiService _rezervacije = new ApiService("korisnikrezervacija");
        private readonly ApiService _ocjena = new ApiService("ocjena");
        private readonly ApiService _voznja = new ApiService("voznja");
        private readonly ApiService _korisnici = new ApiService("korisnik");
        public ListMojeOcjeneViewModel()
        {
            
        }
        public ObservableCollection<Model.Ocjena> MojeOcjeneLista { get; set; } = new ObservableCollection<Model.Ocjena>();
        public ObservableCollection<Model.Korisnik> OcijeniPreostaleVoznjeListKorisnika { get; set; } = new ObservableCollection<Model.Korisnik>();
        public async Task GetListaOcjena()
        {
            MojeOcjeneLista.Clear();
          
            var korisnik = Memorija.Korisnik;
            int IdKorisnikDet = korisnik.KorisnikId;
            var listaRezervacijaFull = await _rezervacije.Get<List<Model.KorisnikRezervacija>>(null);

            var RezervacijeRequest = new KorisnikRezervacijaSearchRequest() { KorisnikId = korisnik.KorisnikId };
            var listaRezervacija = await _rezervacije.Get<List<Model.KorisnikRezervacija>>(RezervacijeRequest);

            var VoznjaRequest = new VoznjaSearchRequest() { KorisnikId = korisnik.KorisnikId };
            var listaVoznji = await _voznja.Get<List<Model.Voznja>>(VoznjaRequest);

            var OcjeneRequest = new OcjenaSearchRequest() { };
            var ocjene = await _ocjena.Get<List<Model.Ocjena>>(OcjeneRequest);

            if (listaRezervacija.Count > 0 || listaVoznji.Count > 0)
                Set_MojeOcjene_List(ocjene, listaVoznji, listaRezervacija, korisnik);
        }
        private async void Set_MojeOcjene_List(List<Model.Ocjena> ocjene, List<Model.Voznja> listaVoznji, List<Model.KorisnikRezervacija> listaRezervacija, Model.Korisnik _korisnik)
        {
            List<Model.KorisnikRezervacija> _listaRezervacija = new List<Model.KorisnikRezervacija>();
            List<Model.Ocjena> _listaOcjena = new List<Model.Ocjena>();
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();

            for (int i = 0; i < listaRezervacija.Count(); i++)
            {
                for (int j = 0; j < ocjene.Count(); j++)
                {
                    if (ocjene[j].RezervacijaId == listaRezervacija[i].RezervacijaId && listaRezervacija[i].KorisnikId == _korisnik.KorisnikId)
                    {
                        _listaOcjena.Add(ocjene[j]);
                        _listaRezervacija.Add(listaRezervacija[i]);
                    }
                }
            }
            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                for (int j = 0; j < ocjene.Count(); j++)
                {
                    if (ocjene[j].VoznjaId == listaVoznji[i].VoznjaId && listaVoznji[i].KorisnikId == _korisnik.KorisnikId)
                    {
                        _listaVoznji.Add(listaVoznji[i]);
                        _listaOcjena.Add(ocjene[j]);
                    }
                }
            }

            NumberFormatInfo setPrecision = new NumberFormatInfo();
            setPrecision.NumberDecimalDigits = 2;
            decimal ocjena;
            if (_listaOcjena.Count() > 0)
                ocjena = GetProsjek(_listaOcjena);
            else
                ocjena = 0;

            foreach (var item in _listaOcjena)
            {
                var korisickoIme = await _korisnici.GetById<Model.Korisnik>(item.KorisnikId);
                item.KorisnickoIme = korisickoIme.UserName;
                MojeOcjeneLista.Add(item);
            }
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