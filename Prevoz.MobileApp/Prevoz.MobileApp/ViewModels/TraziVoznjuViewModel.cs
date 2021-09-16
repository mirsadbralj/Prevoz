using Prevoz.Model;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model.Requests.Vožnja;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prevoz.MobileApp.ViewModels
{
    public class TraziVoznjuViewModel : BaseViewModel
    {
        private readonly ApiService _lokacija = new ApiService("lokacija");
        private readonly ApiService _voznja = new ApiService("voznja");
        public string _PolaznaLokacija = string.Empty;
        public string _destinacija = string.Empty;
        public DateTime _DatumVoznje;
        public DateTime _MinDatetime = DateTime.Now;

        
        public TraziVoznjuViewModel()
        {
            TraziVoznju = new Command(async () => await Trazi());
        }
        public ObservableCollection<Voznja> ListaDostupnihVoznji { get; set; } = new ObservableCollection<Voznja>();
        public Command TraziVoznju { get; set; }
        public string destinacija
        {
            get { return _destinacija; }
            set { SetProperty(ref _destinacija, value); }
        }
        public string PolaznaLokacija
        {
            get { return _PolaznaLokacija; }
            set { SetProperty(ref _PolaznaLokacija, value); }
        }
        public DateTime DatumVoznje
        {
            get { return _DatumVoznje; }
            set { SetProperty(ref _DatumVoznje, value); }
        }
        public DateTime MinimumDateTime
        {
            get { return _MinDatetime; }
            set { SetProperty(ref _MinDatetime, value); }
        }
        public async Task Trazi()
        {
            if (DatumVoznje.Date == DateTime.MinValue.Date)
                DatumVoznje = DateTime.Now;
            var listaSvihVoznji = await _voznja.Get<List<Model.Voznja>>(null);
            ListaDostupnihVoznji.Clear();

            if (DatumVoznje.Date < DateTime.Now.Date)
                await Application.Current.MainPage.DisplayAlert("Greška", "Datum ne može biti stariji od danas", "OK");
            else
            {
                var StartLocationRequest = new LokacijaSearchRequest()
                {
                    Latitude = null,
                    Longitude = null,
                    Naziv = PolaznaLokacija,
                    PostalCode = null
                };
                var StartLocation = await _lokacija.Get<List<Model.Lokacija>>(StartLocationRequest);
                var EndLocationRequest = new LokacijaSearchRequest()
                {
                    Latitude = null,
                    Longitude = null,
                    Naziv = destinacija,
                    PostalCode = null
                };
                var EndLocation = await _lokacija.Get<List<Model.Lokacija>>(EndLocationRequest);

                var listaVoznjiStart = await _voznja.Get<List<Model.Voznja>>(null);
                var listaVoznjiEnd = await _voznja.Get<List<Model.Voznja>>(null);


                var StartLocationIDs = StartLocation.Select(x => x.LokacijaId);
                var EndLocationIDs = EndLocation.Select(x => x.LokacijaId);

                listaSvihVoznji = listaVoznjiStart.Where(x => StartLocationIDs.Contains(x.StartId)).ToList();
                listaSvihVoznji = listaSvihVoznji.Where(x => EndLocationIDs.Contains(x.EndId)).ToList();

                List<Voznja> listaVoznjiWD = new List<Voznja>();
                IEnumerable<Voznja> listaVoznjiWDDateTime = new List<Voznja>();

                if (listaSvihVoznji.Count > 0)
                {
                    listaVoznjiWD.Add(listaSvihVoznji[0]);
                    bool pronadji = false;
                    for (int i = 0; i < listaSvihVoznji.Count; i++)
                    {
                        pronadji = false;
                        for (int j = 0; j < listaVoznjiWD.Count; j++)
                        {
                            if (listaVoznjiWD[j].VoznjaId == listaSvihVoznji[i].VoznjaId)
                                pronadji = true;
                        }
                        if (pronadji == false)
                            listaVoznjiWD.Add(listaSvihVoznji[i]);
                    }
                    listaVoznjiWDDateTime = listaVoznjiWD.Where(x => x.DatumVoznje.Date == DatumVoznje.Date && x.BrojSjedista > 0);
                    foreach (var item in listaVoznjiWDDateTime)
                    {
                        ListaDostupnihVoznji.Add(item);
                    }
                }
            }
        }
    }
}