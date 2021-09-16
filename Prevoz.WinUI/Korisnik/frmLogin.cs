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
    public partial class frmLogin : Form
    {
        ApiService service = new ApiService("korisnik");
        public frmLogin()
        {
            InitializeComponent();
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                try
                {
                    ApiService.Username = txtUsername.Text;
                    ApiService.Password = txtPassword.Text;

                    var requestK = new KorisniciSearchRequest()
                    {
                        UserName = ApiService.Username
                    };

                    var korisnik = await service.Get<List<Model.Korisnik>>(requestK);
                    Memorija.Korisnik = korisnik[0];

                    this.Close();

                    frmPocetnaFormaKorisnik frm = new frmPocetnaFormaKorisnik();
                    frm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Autentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmKorisnikRegistration frm = new frmKorisnikRegistration();
            frm.Show();
        }
        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) && txtUsername.Text.Length < 2)
            {
                errorProviderLogin.SetError(txtUsername, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if(txtUsername.Text.Length < 2)
            {
                errorProviderLogin.SetError(txtUsername,"Polje mora sadržavati najmanje 2 karaktera");
                e.Cancel = true;
            }
            else
            {
                errorProviderLogin.SetError(txtUsername, null);
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 4)
            {
                errorProviderLogin.SetError(txtPassword, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderLogin.SetError(txtPassword, null);
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
