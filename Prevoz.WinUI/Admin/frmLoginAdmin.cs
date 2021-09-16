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

namespace Prevoz.WinUI.Admin
{
    public partial class frmLoginAdmin : Form
    {
        ApiService _service = new ApiService("korisnik");
        ApiService _uloge = new ApiService("uloge");
        ApiService _korisnikUloge = new ApiService("korisnikuloge");
        public frmLoginAdmin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ApiService.Username = txtUsername.Text;
                ApiService.Password = txtPassword.Text;
               
                await _service.Get<dynamic>(null);
                
                var request = new KorisniciSearchRequest(){UserName=ApiService.Username};
                var requestKU = await _korisnikUloge.Get<List<Model.KorisnikUloge>>(null);
                var korisnik = await _service.Get<List<Model.Korisnik>>(request);
                Memorija.Korisnik = korisnik[0];
                bool checkAuth = false;

                for (int i = 0; i < requestKU.Count(); i++)
                {
                    if (requestKU[i].KorisnikId == korisnik[0].KorisnikId && (requestKU[i].UlogaId==2 || requestKU[i].UlogaId==3))
                        checkAuth = true;
                }
                if (checkAuth == true)
                {
                    this.Close();
                    frmPocetnaFormaAdmin frm = new frmPocetnaFormaAdmin();
                    frm.Show();
                }
                else
                {
                    frmPocetnaFormaKorisnik frm = new frmPocetnaFormaKorisnik();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Autentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
