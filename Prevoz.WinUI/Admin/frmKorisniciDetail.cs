using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.WinUI.Korisnik;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmKorisniciDetail : Form
    {
        private readonly ApiService _service = new ApiService("korisnik");
        private readonly ApiService _serviceDetail = new ApiService("korisnikdetail");

        private int? _id = null;
        public frmKorisniciDetail(int? korisnikId = null)  
        {
            InitializeComponent();
            _id = korisnikId;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // frmWarning frm = new frmWarning();
            // frm.Show
            // korisnikD = await _serviceDetail.Delete<Model.KorisnikDetails>(_id);
            MessageBox.Show("Da li ste sigurni da zelite ukloniti korisnika?");
            //var korisnikDet = await _serviceDetail.Delete<Model.KorisnikDetails>(_id);
            var korisnik = await _service.Delete<Model.Korisnik>(_id);
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtTelefon.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            MessageBox.Show("Korisnik je uspješno uklonjen iz baze podataka.");
        }

        private async void frmKorisniciDetail_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var korisnikD = await _serviceDetail.GetById<Model.KorisnikDetails>(_id);
                var korisnik = await _service.GetById<Model.Korisnik>(_id);
                if (korisnikD != null) {
                    txtIme.Text = korisnikD.Ime;
                    txtPrezime.Text = korisnikD.Prezime;
                    txtTelefon.Text = korisnikD.Telefon;
                    txtEmail.Text = korisnikD.Email;
                }
               
               //else {
               //     txtIme.Text = korisnikD.Ime;
               //     txtPrezime.Text = korisnikD.Prezime;
               //     txtTelefon.Text = korisnikD.Telefon;
               //     txtEmail.Text = korisnikD.Email;
               // }
                txtUserName.Text = korisnik.UserName;
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            var request = new KorisniciUpsertRequests
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                PasswordConfirmation = txtPotvrda.Text
            };
            var request2 = new KorisnikDetail_UpsertRequest
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Telefon = txtTelefon.Text,
                Email = txtEmail.Text
                //ostali parametri to do
            };
            if (_id.HasValue)
            {
                await _serviceDetail.Update<Model.KorisnikDetails>(_id, request2);
                await _service.Update<Model.Korisnik>(_id, request);
            }
            else
            {
                await _service.Insert<Model.Korisnik>(request);
                await _serviceDetail.Insert<Model.KorisnikDetails>(request2);
            }
            MessageBox.Show("Informacije su uspješno spremljene u bazi podataka.");
        }
    }
}
