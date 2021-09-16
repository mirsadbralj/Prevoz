using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Prevoz.MobileApp.ViewModels
{
    public class KorisnikVoznjeOcjenaViewModel
    {
        private readonly ApiService _voznje = new ApiService("voznje");

        List<Model.Voznja> listaVoznji;
        int _KorisnikID = 0;

        public ObservableCollection<Model.Voznja> listaNeocijenjenihVoznji { get; set; } = new ObservableCollection<Model.Voznja>();
        public KorisnikVoznjeOcjenaViewModel(int KorisnikID, List<Model.Voznja> voznje)
        {
            _KorisnikID = KorisnikID;
            listaVoznji = voznje;
        }
        public KorisnikVoznjeOcjenaViewModel() { }

        public void GetVoznje()
        {
            listaNeocijenjenihVoznji.Clear();
            foreach(var item in listaVoznji)
            {
                if (item.KorisnikId == _KorisnikID)
                    listaNeocijenjenihVoznji.Add(item);
            }
        }
    }
}
