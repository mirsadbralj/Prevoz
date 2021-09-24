using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Vozilo;
using Prevoz.Model.Requests.Vožnja;
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
    public class VozilaViewModel 
    {
        private readonly ApiService _vozila = new ApiService("vozilo");
        private readonly ApiService _voznja = new ApiService("voznja");
        private readonly ApiService _korisnik = new ApiService("korisnik");
        int ID = 0;
        public VozilaViewModel()
        {
            GetVozilaCommand = new Command(async() => await GetVozila());
            RemoveVozilo = new Command(async () => await Remove(ID));
        }
        public ObservableCollection<Model.Vozilo> VozilaList { get; set; } = new ObservableCollection<Model.Vozilo>();

        public ICommand GetVozilaCommand { get; set; }
        public Command RemoveVozilo { get; set; }
        public async Task GetVozila()
        {
            VozilaList.Clear();
            var korisnikRequest = new KorisniciSearchRequest()
            {
                UserName = ApiService.Username
            };
            var korisnik = await _korisnik.Get<List<Model.Korisnik>>(korisnikRequest);

            var vozilaRequest = new VoziloSearchRequest()
            {
                KorisnikId=korisnik[0].KorisnikId
            };
            var vozila = await _vozila.Get<List<Model.Vozilo>>(vozilaRequest);

            foreach(var vozilo in vozila)
            {
                VozilaList.Add(vozilo);
            }
        }
        public async Task Remove(int Id)
        {
            ID = Id;
            var listVoznje = await _voznja.Get<List<Model.Voznja>>(null);

            List<Voznja> voznje = new List<Voznja>();

            foreach (var item in listVoznje)
            {
                if (item.VoziloId == Id)
                    voznje.Add(item);
            }
            for (int i = 0; i < voznje.Count(); i++)
            {

                voznje[i].VoziloId = null;
                var request = new VoznjaUpsertRequest()
                {
                    KorisnikId = voznje[i].KorisnikId,
                    DatumVoznje = voznje[i].DatumVoznje,
                    BrojSjedista = voznje[i].BrojSjedista,
                    CijenaSjedista = voznje[i].CijenaSjedista,
                    StartId = voznje[i].StartId,
                    EndId = voznje[i].EndId,
                    Status = voznje[i].Status,
                    VoziloId = voznje[i].VoziloId
                };
                await _voznja.Update<Model.Voznja>(voznje[i].VoznjaId, request);
            }
            await _vozila.Delete<Model.Vozilo>(Id);
        }
    }
}