using Plugin.Media;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.MobileApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Prevoz.Model.Requests.Lokacija;

namespace Prevoz.MobileApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _korisnikDetail = new ApiService("korisnikdetail");
        private readonly ApiService _lokacija = new ApiService("lokacija");
        public ProfileViewModel()
        {
            ProfileCommand = new Command(async () => await Profile());
            SaveCommand = new Command(async () => await Save());
        }
        public ICommand ProfileCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public Entry Username { get; set; } = new Entry();
        public Entry Ime { get; set; } = new Entry();
        public Entry Prezime { get; set; } = new Entry();
        public Entry Email { get; set; } = new Entry();
        public Entry Telefon { get; set; } = new Entry();
        public DateTime Datum { get; set; } = new DateTime();
        public Entry Password { get; set; } = new Entry();
        public Entry Potvrda { get; set; } = new Entry();
        public byte[] userImage { get; set; }
        public byte[] profilePhoto { get; set; } = null;
        public string _Grad = string.Empty;

        
        public string Grad
        {
            get { return _Grad; }
            set { SetProperty(ref _Grad, value); }
        }
        public byte[] UserImage
        {
            get { return userImage; }
            set
            {
                if (value != userImage)
                {
                    userImage = value;
                    OnPropertyChanged("UserImage");
                }
            }
        }
        public async Task Save()
        {
            var korisnikC = Memorija.Korisnik;

            var korisnikD = await _korisnikDetail.GetById<Model.KorisnikDetails>(korisnikC.KorisnikId);
            var korisnik = await _korisnik.GetById<Model.Korisnik>(korisnikC.KorisnikId);
            Lokacija lokacija2 = new Lokacija();
            if (korisnikD != null) 
            {
                if (korisnikD.Lokacija != null )
                {
                    var lokacija = await _lokacija.GetById<Model.Lokacija>(korisnikD.Lokacija);

                    
                    var LokacijaRequest = new LokacijaUpsertRequest()
                    {
                        Naziv = Grad
                    };
                       
                    await _lokacija.Update<Model.Lokacija>(lokacija.LokacijaId, LokacijaRequest);

                    var KorisnikUpdateRequest = new KorisniciUpsertRequests()
                    {
                        UserName = Username.Text,
                        Password = Password.Text,
                        PasswordConfirmation = Potvrda.Text,
                        Slika = UserImage
                    };
                    var KorisnikDetailsUpdateRequest = new KorisnikDetail_UpsertRequest()
                    {
                        KorisnikId = korisnik.KorisnikId,
                        Ime = Ime.Text,
                        Prezime = Prezime.Text,
                        Email = Email.Text,
                        Lokacija = lokacija.LokacijaId,
                        Telefon = Telefon.Text,
                        DatumRođenja = Datum
                    };
                    var checkDetail = await _korisnikDetail.GetById<Model.KorisnikDetails>(korisnik.KorisnikId);

                    if (Password.Text != null && (Password.Text == Potvrda.Text) || Username.Text != korisnik.UserName || userImage != null)
                        await _korisnik.Update<Model.Korisnik>(korisnik.KorisnikId, KorisnikUpdateRequest);

                    if (checkDetail != null && checkDetail.KorisnikId > 0)
                    {
                        await _korisnikDetail.Update<Model.KorisnikDetails>(korisnik.KorisnikId, KorisnikDetailsUpdateRequest);
                    }
                    else
                        await _korisnikDetail.Insert<Model.KorisnikDetails>(KorisnikDetailsUpdateRequest);
                    

                }
                await Application.Current.MainPage.DisplayAlert("Podaci uspješno spremljeni", "", "OK");
            }
            else
            {
                var LokacijaRequest = new LokacijaUpsertRequest()
                {
                    Naziv = Grad
                };
                lokacija2 = await _lokacija.Insert<Model.Lokacija>(lokacija2);

                var KorisnikUpdateRequest = new KorisniciUpsertRequests()
                {
                    UserName = Username.Text,
                    Password = Password.Text,
                    PasswordConfirmation = Potvrda.Text,
                    Slika = UserImage
                };
                var KorisnikDetailsUpdateRequest = new KorisnikDetail_UpsertRequest()
                {
                    KorisnikId = korisnik.KorisnikId,
                    Ime = Ime.Text,
                    Prezime = Prezime.Text,
                    Email = Email.Text,
                    Lokacija = lokacija2.LokacijaId,
                    Telefon = Telefon.Text,
                    DatumRođenja = Datum
                };
                var checkDetail = await _korisnikDetail.GetById<Model.KorisnikDetails>(korisnik.KorisnikId);

                if (Password.Text != null && (Password.Text == Potvrda.Text) || Username.Text != korisnik.UserName || userImage != null)
                    await _korisnik.Update<Model.Korisnik>(korisnik.KorisnikId, KorisnikUpdateRequest);

                if (checkDetail != null && checkDetail.KorisnikId > 0)
                {
                    await _korisnikDetail.Update<Model.KorisnikDetails>(korisnik.KorisnikId, KorisnikDetailsUpdateRequest);
                }
                else
                    await _korisnikDetail.Insert<Model.KorisnikDetails>(KorisnikDetailsUpdateRequest);

                await Application.Current.MainPage.DisplayAlert("Podaci uspješno spremljeni", "", "OK");
            }
           
        }
        public async Task Profile()
        {
            var korisnikC = Memorija.Korisnik;
            
            var korisnikD = await _korisnikDetail.GetById<Model.KorisnikDetails>(korisnikC.KorisnikId);
            var korisnik = await _korisnik.GetById<Model.Korisnik>(korisnikC.KorisnikId);

            Lokacija lokacija = new Lokacija();
            if(korisnikD!=null && korisnikD.Lokacija!=null)
            lokacija = await _lokacija.GetById<Model.Lokacija>(korisnikD.Lokacija);

            if (korisnikD != null)
            {
                UserImage = korisnik.Slika;
                Ime.Text = korisnikD.Ime;
                Prezime.Text = korisnikD.Prezime;
                Email.Text = korisnikD.Email;
                Telefon.Text = korisnikD.Telefon;
                if (korisnikD.DatumRođenja != null)
                    Datum = (DateTime)korisnikD.DatumRođenja;
            }
            else
            {
                UserImage = null;
                Ime.Text = "";
                Prezime.Text = "";
                Email.Text = "";
                Telefon.Text = "";
                Datum = DateTime.MinValue.Date;
            }
            Username.Text = korisnik.UserName;
            if(lokacija!=null)
            Grad = lokacija.Naziv;
            userImage = null;
        }

    }
}