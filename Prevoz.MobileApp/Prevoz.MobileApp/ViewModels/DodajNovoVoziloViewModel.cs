using eProdaja.Mobile.Converters;
using Prevoz.Model.Requests;
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
    public class DodajNovoVoziloViewModel : BaseViewModel
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _vozila = new ApiService("vozilo");
        public DodajNovoVoziloViewModel()
        {
            SaveCommand = new Command(async () => await Save());
        }

        public ObservableCollection<string> BojaAutomobilaList { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> MarkaAutomobilaList { get; set; } = new ObservableCollection<string>();

        private string boja = string.Empty;
        private string marka = string.Empty;
        private string naziv = string.Empty;

        public byte[] SlikaK;
        public ICommand SaveCommand { get; set; }
        public ICommand AddImage { get; set; }
        public string nazivAutomobila
        {
            get { return naziv; }
            set { SetProperty(ref naziv, value); }
        }
        public string BojaAutomobila
        {
            get { return boja; }
            set { SetProperty(ref boja, value); }
        }
        public string MarkaAutomobila
        {
            get { return marka; }
            set { SetProperty(ref marka, value); }
        }
        public async Task LoadBoje() {
            BojaAutomobilaList.Add("");
            BojaAutomobilaList.Add("Bijela");
            BojaAutomobilaList.Add("Crna");
            BojaAutomobilaList.Add("Crvena");
            BojaAutomobilaList.Add("Siva");
            BojaAutomobilaList.Add("Plava");
            BojaAutomobilaList.Add("Smeđa");
            BojaAutomobilaList.Add("Žuta");
        }
        public async Task LoadMarkeVozila()
        {
            MarkaAutomobilaList.Add(" ");
            MarkaAutomobilaList.Add("Alfa Romeo");
            MarkaAutomobilaList.Add("BMW");
            MarkaAutomobilaList.Add("Citroen");
            MarkaAutomobilaList.Add("Dacia");
            MarkaAutomobilaList.Add("Fiat");
            MarkaAutomobilaList.Add("Ford");
            MarkaAutomobilaList.Add("Honda");
            MarkaAutomobilaList.Add("Hyundai");
            MarkaAutomobilaList.Add("Jeep");
            MarkaAutomobilaList.Add("Kia");
            MarkaAutomobilaList.Add("Land Rover");
            MarkaAutomobilaList.Add("Mazda");
            MarkaAutomobilaList.Add("Mercedes Benz");
            MarkaAutomobilaList.Add("Nissan");
            MarkaAutomobilaList.Add("Opel");
            MarkaAutomobilaList.Add("Peugeot");
            MarkaAutomobilaList.Add("Renault");
            MarkaAutomobilaList.Add("Toyota");
            MarkaAutomobilaList.Add("Volkswagen");
        }
        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        public async Task Load()
        {
            await LoadBoje();
            await LoadMarkeVozila();
        }
        public async Task Save()
        {           
            var korisnik = Memorija.Korisnik;
            var id = korisnik.KorisnikId;
            var request = new VoziloUpsertRequest()
            {
                KorisnikId = id,
                MarkaVozila = MarkaAutomobila,
                Naziv = nazivAutomobila,
                Boja = BojaAutomobila,
                Slika = SlikaK
            };
            await _vozila.Insert<Model.Vozilo>(request);
        }
    }
}
