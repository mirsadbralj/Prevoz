using Prevoz.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmKorisnikRegistration : Form
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _korisnikDetail = new ApiService("korisnikdetail");

        public frmKorisnikRegistration()
        {
            InitializeComponent();
        }
        
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new KorisniciUpsertRequests()
                {
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtPasswordConfirmation.Text
                };

                var request2 = new KorisnikDetail_UpsertRequest()
                {
                    Ime = "",
                    Prezime = "",
                    Telefon = "",
                    Email = ""
                };

                try
                {
                    await _korisnik.Insert<Model.Korisnik>(request);
                    MessageBox.Show("Vaša registracija je uspiješna, možete se prijaviti na aplikaciju");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                errorProviderRegistration.SetError(txtUsername, "Polje je obavezno i minimalno 2 karaktera je potrebno unijeti");
                e.Cancel = true;
            }
            else
            {
                errorProviderRegistration.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProviderRegistration.SetError(txtPassword, "Polje je obavezno i minimalno 6 karaktera je potrebno unijeti");
                e.Cancel = true;
            }
            else
            {
                errorProviderRegistration.SetError(txtPassword, null);
            }
        }

        private void txtPasswordConfirmation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordConfirmation.Text))
            {
                errorProviderRegistration.SetError(txtPasswordConfirmation, "Polje je obavezno i minimalno 6 karaktera je potrebno unijeti");
                e.Cancel = true;
            }
            else if(txtPassword.Text != txtPasswordConfirmation.Text)
            {
                errorProviderRegistration.SetError(txtPasswordConfirmation, "Potvrda lozinke i lozinka nisu iste! ");
            }
            else
            {
                errorProviderRegistration.SetError(txtPassword, null);
            }

        }

        private void frmKorisnikRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
