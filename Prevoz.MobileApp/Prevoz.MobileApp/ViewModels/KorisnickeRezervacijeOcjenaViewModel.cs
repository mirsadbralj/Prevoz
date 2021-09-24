using Prevoz.Model;
using Prevoz.Model.Requests.Rezervacija;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prevoz.MobileApp.ViewModels
{
    public class KorisnickeRezervacijeOcjenaViewModel : BaseViewModel
    {
        int KorisnikID = 0;
        List<KorisnikRezervacija> rezervacije = new List<KorisnikRezervacija>();
        public ObservableCollection<KorisnikRezervacija> listaRezervacija { get; set; } = new ObservableCollection<KorisnikRezervacija>();
        public KorisnickeRezervacijeOcjenaViewModel(int KorisnikId, List<KorisnikRezervacija> listRezervacije)
        {
            KorisnikID = KorisnikId;
            rezervacije = listRezervacije;
        }
        public KorisnickeRezervacijeOcjenaViewModel()
        {
        }
        public void GetRezervacije()
        {
            listaRezervacija.Clear();

            rezervacije = rezervacije.Where(x => x.KorisnikId == KorisnikID).ToList();

            foreach (var item in rezervacije)
                listaRezervacija.Add(item);
        }
    }
}
