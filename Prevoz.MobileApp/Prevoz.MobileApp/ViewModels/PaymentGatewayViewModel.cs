using Acr.UserDialogs;
using Prevoz.MobileApp.Services;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Uplate;
using Prevoz.Model.Requests.Vožnja;
using Prevoz.Model.Requests.Zahtjevi;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prevoz.MobileApp.ViewModels
{
    public class PaymentGatwayPageViewModel : BindableBase
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _korisnikDetails = new ApiService("korisnikdetail");
        private readonly ApiService _voznja = new ApiService("voznja");
        private readonly ApiService _lokacija = new ApiService("lokacija");
        private readonly ApiService _rezervacija = new ApiService("korisnikrezervacija");
        private readonly ApiService _uplate = new ApiService("uplate");

        #region Variable

        private CreditCardModel _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;
        private string _lokacijaKorisnika = string.Empty;
        KorisnikDetails LogkorisnikDetails = new KorisnikDetails();
        Lokacija LoglokacijaKorisnika = new Lokacija();

        KorisnikDetails OSkorisnikDetails = new KorisnikDetails();
        Korisnik OSkorisnik = new Korisnik();
        int VoznjaId = 0;
        public Voznja voznja = new Voznja();
        public UplateUpsertRequest Uplata = new UplateUpsertRequest();

        #endregion Variable

        #region Public Property
        private string StripeTestApiKey = "{pk_test_51JSjRAFzqt6OnFqZAQBbgCEnBM8K6noiE2NfXPuDOTsdKGLdtmDQeqb56WSEJEPoTa1DIXovKqyuHlaE44nbB6VC00Tu4Jp4yG}";
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }

        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }

        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }

        public CreditCardModel CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }

        #endregion Public Property

        #region Constructor

        public PaymentGatwayPageViewModel(int VoznjaID)
        {
            CreditCardModel = new CreditCardModel();
            Title = "Card Details";
            VoznjaId = VoznjaID;
        }

        public PaymentGatwayPageViewModel()
        {
            CreditCardModel = new CreditCardModel();
            Title = "Card Details";
        }

        #endregion Constructor

        #region Command

        public DelegateCommand SubmitCommand => new DelegateCommand(async () =>
        {
            CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth);
            CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            try
            {
                UserDialogs.Instance.ShowLoading("Uplata se procesuira..");
                await Task.Run(async () =>
                {
                    var Token = CreateToken();
                    Console.Write("Payment Gateway" + "Token :" + Token);
                    if (Token != null)
                    {
                        IsTransectionSuccess = MakePayment(Token);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Neispravni podaci o kartici", null, "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
            }
            finally
            {
                if (IsTransectionSuccess)
                {
                    UserDialogs.Instance.HideLoading();
                    await Rezervacija();
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert("GREŠKA", "Uplata nije izvršena", "OK");
                    Console.Write("Payment Gateway" + "Payment Failure ");
                }
            }

        });

        #endregion Command



        #region Method
        private async void GetKorisnikInfoAndLocation()
        {
            var korisnik = Memorija.Korisnik;

            var korisnikDetails = await _korisnikDetails.GetById<KorisnikDetails>(korisnik.KorisnikId);
            if (korisnikDetails != null)
            {
                this.LogkorisnikDetails = korisnikDetails;
                if (korisnikDetails.Lokacija != null)
                {
                    var korisnikLokacija = await _lokacija.GetById<Lokacija>(korisnikDetails.Lokacija);
                    this.LoglokacijaKorisnika = korisnikLokacija;
                    _lokacijaKorisnika = korisnikLokacija.Naziv;
                }
            }
        }
        private async void GetVoznjaInfo()
        {
            voznja = await _voznja.GetById<Voznja>(VoznjaId);

            var korisnik = await _korisnik.GetById<Korisnik>(voznja.KorisnikId);

            OSkorisnikDetails = await _korisnikDetails.GetById<KorisnikDetails>(korisnik.KorisnikId);

            OSkorisnik = korisnik;
        }
        private string CreateToken()
        {
            var korisnik = Memorija.Korisnik;

            GetKorisnikInfoAndLocation();
            GetVoznjaInfo();

            try
            {
                StripeConfiguration.SetApiKey("sk_test_51JSjRAFzqt6OnFqZD8Tx7bpoqemWqOtxJSZxmecjZaUumDgu8FKB3knuZSawaym4bXaAS06eqNr1P4twugN3sHrV000KSOkre0");
                var service = new ChargeService();

                if (_lokacijaKorisnika == null)
                {
                    _lokacijaKorisnika = " ";
                }
                var Tokenoptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = korisnik.UserName,
                        
                        AddressCity = _lokacijaKorisnika,
                        Currency = "eur",
                    }
                };
                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool MakePayment(string token)
        {
            try
            {
                var korisnik = Memorija.Korisnik;
                GetVoznjaInfo();
                StripeConfiguration.SetApiKey("sk_test_51JSjRAFzqt6OnFqZD8Tx7bpoqemWqOtxJSZxmecjZaUumDgu8FKB3knuZSawaym4bXaAS06eqNr1P4twugN3sHrV000KSOkre0");
                if (IsValidEmail(LogkorisnikDetails.Email)==false)
                {
                    LogkorisnikDetails.Email = "sample@gmail.com";
                }
                var options = new ChargeCreateOptions
                {
                    Amount = (long)float.Parse(((voznja.CijenaSjedista * 100)).ToString()),
                    Currency = "eur",
                    Description = "Uplata za jedno sjedište, na vožnji za korisnika:" + OSkorisnik.UserName,
                    Source = stripeToken.Id,
                    StatementDescriptor = "AAA",
                    Capture = true,
                    ReceiptEmail = LogkorisnikDetails.Email,
                };
                var service = new ChargeService();
                Charge charge = service.Create(options);

                var uplata = new UplateUpsertRequest()
                {
                    KorisnikId = korisnik.KorisnikId,
                    Iznos = voznja.CijenaSjedista,
                    DatumUplate = DateTime.Now
                };
                Uplata = uplata;
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway (CreateCharge)" + ex.Message);
                throw ex;
            }
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public async Task Rezervacija()
        {
            var korisnik = Memorija.Korisnik;

            if (voznja.KorisnikId != korisnik.KorisnikId)
            {
                if (voznja.BrojSjedista > 0)
                {
                    var requestRezervacija = new KorisnikRezervacijaUpsertRequest()
                    {
                        KorisnikId = korisnik.KorisnikId,
                        VoznjaId = voznja.VoznjaId,
                        BrojSjedista = +1,
                        UkupnoPlaceno = voznja.CijenaSjedista,
                        DatumRezervacije = DateTime.Now
                    };
                    await _rezervacija.Insert<Model.KorisnikRezervacija>(requestRezervacija);
                    voznja.BrojSjedista--;
                    var UpdateRequestVoznja = new VoznjaUpsertRequest()
                    {
                        KorisnikId = voznja.KorisnikId,
                        VoziloId = voznja.VoziloId,
                        BrojSjedista = voznja.BrojSjedista--,
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
                    await _voznja.Update<Model.Voznja>(voznja.VoznjaId, UpdateRequestVoznja);
                    await _uplate.Insert<Uplate>(Uplata);
                    UserDialogs.Instance.Alert("Sredstva su uplaćena", "Vožnja uspješno rezervisana", "OK");
                }
                else
                {
                    UserDialogs.Instance.Alert("Rezervacija neuspješna", "Sva sjedišta su rezervisana", "OK");
                }

            }
            else
            {
                UserDialogs.Instance.Alert("Rezervacija neuspješna", "Nije moguće rezervisati vlastitu vožnju", "OK");
            }
        }
        private bool ValidateCard()
        {
            if (CreditCardModel.Number.Length == 16 && ExpMonth.Length == 2 && ExpYear.Length == 2 && CreditCardModel.Cvc.Length == 3)
            {
            }
            return true;
        }
        #endregion Method
    }
}
