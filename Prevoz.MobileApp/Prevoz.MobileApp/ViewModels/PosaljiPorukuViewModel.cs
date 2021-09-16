using Prevoz.MobileApp.Views;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Poruka;
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
    public class PosaljiPorukuViewModel : BaseViewModel
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _poruka = new ApiService("poruka");
        string TekstPoruke = string.Empty;
        int KorisnikId = 0;
        public ObservableCollection<Poruka> listPoruke { get; set; } = new ObservableCollection<Poruka>();
        public string Text
        {
            get { return TekstPoruke; }
            set { SetProperty(ref TekstPoruke, value); }
        }

        public PosaljiPorukuViewModel(int KorisnikID)
        {
            KorisnikId = KorisnikID;
            SendMessageCommand = new Command(async () => await PosaljiPoruku());
            GetConversationCommand = new Command(async () => await GetConversation());
        }
        public PosaljiPorukuViewModel()
        {
        }
        public ICommand SendMessageCommand { get; set; }
        public ICommand GetConversationCommand { get; set; }

        public async Task PosaljiPoruku()
        {
            var korisnik = Memorija.Korisnik;
            var RequestPoruka = new PorukaUpsertRequest()
            {
                PosiljaocID = korisnik.KorisnikId,
                PrimaocID = KorisnikId,
                Sadrzaj = TekstPoruke,
                DatumVrijeme = DateTime.Now
            };
            await _poruka.Insert<Model.Poruka>(RequestPoruka);
        }
        public async Task GetConversation()
        {
            var korisnik = Memorija.Korisnik;
            var requestPoruke = new PorukaSearchRequest()
            {
                PosiljaocID = korisnik.KorisnikId,
                PrimaocID = KorisnikId
            };
            var poruke = await _poruka.Get<List<Model.Poruka>>(requestPoruke);
            foreach (var poruka in poruke)
            {
                poruka.JaPosiljaoc = korisnik.KorisnikId == poruka.PosiljaocID;
                listPoruke.Add(poruka);
            }
        }
    }
}