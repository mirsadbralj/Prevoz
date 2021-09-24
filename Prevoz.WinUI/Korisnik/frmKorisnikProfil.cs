using Prevoz.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmKorisnikProfil : Form
    {
        private readonly ApiService _service = new ApiService("korisnik");
        private readonly ApiService _serviceDetail = new ApiService("korisnikdetail");

        private int? _id = null;
        private byte[] SlikaK = null;
        private byte[] SlikaDatabase = null;
        public frmKorisnikProfil(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
        }
        private async void frmKorisnikProfil_Load(object sender, EventArgs e)
        {
            var korisnikC = Memorija.Korisnik;
            if (korisnikC.Slika != null && korisnikC.Slika.Length!=0)
            {
                SlikaDatabase = korisnikC.Slika;
                picBoxSLikaProfila.SizeMode = PictureBoxSizeMode.Zoom;
                picBoxSLikaProfila.Image = ByteToImage(SlikaDatabase);
            }
            _id = korisnikC.KorisnikId;
            if (_id.HasValue)
                {
                    var korisnikD = await _serviceDetail.GetById<Model.KorisnikDetails>(_id);
                    var korisnik = await _service.GetById<Model.Korisnik>(_id);
                if (korisnikD != null) 
                {
                    txtIme.Text = korisnikD.Ime;
                    txtPrezime.Text = korisnikD.Prezime;
                    txtTelefon.Text = korisnikD.Telefon;
                    txtEmail.Text = korisnikD.Email;
                }
                    txtUserName.Text = korisnik.UserName;
             
                if (korisnikD != null)
                if (korisnikD.DatumRođenja != null && korisnikD.DatumRođenja > DateTime.MinValue)
                {
                    var datum = korisnikD.DatumRođenja.Value;
                    datumRodenjaPicker.Value = new DateTime(datum.Year, datum.Month, datum.Day, datum.Hour, datum.Minute, datum.Second);
                }
                else
                    datumRodenjaPicker.Value = DateTime.Now;

            }
        }
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var korisnikC = Memorija.Korisnik;
                _id = korisnikC.KorisnikId;

                var request = new KorisniciUpsertRequests
                {
                    KorisnikId = korisnikC.KorisnikId,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtPotvrda.Text,
                    Slika = SlikaK
                };
                var request2 = new KorisnikDetail_UpsertRequest
                {
                    KorisnikId = korisnikC.KorisnikId,
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Telefon = txtTelefon.Text,
                    Email = txtEmail.Text,
                    DatumRođenja = new DateTime(datumRodenjaPicker.Value.Year, datumRodenjaPicker.Value.Month, datumRodenjaPicker.Value.Day, datumRodenjaPicker.Value.Hour, datumRodenjaPicker.Value.Minute, datumRodenjaPicker.Value.Second)
                };
                if (_id.HasValue)
                {
                    if (request.UserName != korisnikC.UserName || request.Password != "" && (request.Password == request.PasswordConfirmation) || request.Slika != korisnikC.Slika)
                        await _service.Update<Model.Korisnik>(_id, request);

                    var checkDetail = await _serviceDetail.GetById<Model.KorisnikDetails>(_id);

                    if (checkDetail != null && checkDetail.KorisnikId > 0)
                    {
                        await _serviceDetail.Update<Model.KorisnikDetails>(_id, request2);
                    }
                    else if (checkDetail == null || checkDetail.KorisnikId == 0)
                    {
                        request2.KorisnikId = korisnikC.KorisnikId;
                        await _serviceDetail.Insert<Model.KorisnikDetails>(request2);
                    }
                }
                else
                {
                    await _service.Insert<Model.Korisnik>(request);
                    await _serviceDetail.Insert<Model.KorisnikDetails>(request2);
                }
                Memorija.Korisnik = await _service.GetById<Model.Korisnik>(request.KorisnikId);
                MessageBox.Show("Informacije su uspješno spremljene u bazi podataka.");
            }
        }
        private void btnDodajSliku(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg";
            picBoxSLikaProfila.SizeMode = PictureBoxSizeMode.Zoom;

            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                picBoxSLikaProfila.Image = Image.FromFile(fileOpen.FileName);
            }
           
            fileOpen.Dispose();

            var korisnik = Memorija.Korisnik;
            SlikaDatabase = korisnik.Slika;
            

            SlikaK = converterDemo(picBoxSLikaProfila.Image);
        }
        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        public static Bitmap ByteToImage(byte[] blob)
        {  
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private void btnAddVozilo_Click(object sender, EventArgs e)
        {
            frmVoziloAdd frm = new frmVoziloAdd();
            frm.Show();
        }
        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (txtIme.Text.Length < 2)
            {
                errorProviderKorisnikProfil.SetError(txtIme, "Minimalno 2 karaktera!");
                e.Cancel = true;
            }
            else
            {
                errorProviderKorisnikProfil.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (txtPrezime.Text.Length < 2)
            {
                errorProviderKorisnikProfil.SetError(txtPrezime, "Minimalno 2 karaktera!");
                e.Cancel = true;
            }
            else
            {
                errorProviderKorisnikProfil.SetError(txtPrezime, null);
            }
        }
        private void frmKorisnikProfil_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Length < 9 )
            {
                errorProviderKorisnikProfil.SetError(txtEmail, "Neispravan unos (Odgovarajuci fomrat E-maila: someone@example.com) ");
                e.Cancel = true;
            }
            else
            {
                errorProviderKorisnikProfil.SetError(txtEmail, null);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserName.Text.Length == 0)
            {
                errorProviderKorisnikProfil.SetError(txtUserName, "Polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProviderKorisnikProfil.SetError(txtUserName, null);
            }
        }

        private async void txtUserName_TextChanged(object sender, EventArgs e)
        {
            var request = new KorisniciSearchRequest()
            {
                UserName=txtUserName.Text
            };
            if (request.UserName.Length >= 2)
            {
                var korisnik = await _service.Get<List<Model.Korisnik>>(request);


                if (korisnik.Count > 0 && korisnik[0].UserName != Memorija.Korisnik.UserName)
                {
                    errorProviderKorisnikProfil.SetError(txtUserName, "Korisničko ime je zauzeto");
                }
                else
                {
                    errorProviderKorisnikProfil.SetError(txtUserName, null);
                }
            }
            else
            {
                errorProviderKorisnikProfil.SetError(txtUserName, "Minimalno 2 karaktera");
            }
        }
    }
}

