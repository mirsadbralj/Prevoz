using Prevoz.Model.Requests.Ocjena;
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
    public partial class frmOcjenaDetail : Form
    {
        ApiService _ocjena = new ApiService("ocjena");
        ApiService _korisnik = new ApiService("korisnik");
        ApiService _korisnikDetails = new ApiService("korisnikdetail");
        int _ocjenaId = 0;

        int KorisnikID_for_info = 0;
        public frmOcjenaDetail(int OcjenaID)
        {
            _ocjenaId = OcjenaID;
            InitializeComponent();
        }
        private async void frmOcjenaDetail_Load(object sender, EventArgs e)
        {
            var ocjena = await _ocjena.GetById<Model.Ocjena>(_ocjenaId);
            var korisnik = await _korisnik.GetById<Model.Korisnik>(ocjena.KorisnikId);
            var korisnikDetails = await _korisnikDetails.GetById<Model.KorisnikDetails>(ocjena.KorisnikId);

            lblKorisnickoIme.Text = korisnik.UserName.ToString();
            lblIme.Text = korisnikDetails.Ime;
            lblPrezime.Text = korisnikDetails.Prezime;
            lblOcjena.Text = ocjena.Ocjena1.ToString();
            lblKomentar.Text = ocjena.Komentar;
            KorisnikID_for_info = korisnik.KorisnikId;
        }

        private void lblKorisnickoIme_Click(object sender, EventArgs e)
        {
            frm_KorisnikInfo frm = new frm_KorisnikInfo(KorisnikID_for_info);
            frm.Show();
        }

        private void lblKorisnickoIme_MouseHover(object sender, EventArgs e)
        {
            lblKorisnickoIme.BackColor = Color.Green;
        }

        private void lblKorisnickoIme_MouseLeave(object sender, EventArgs e)
        {
            lblKorisnickoIme.BackColor = default;
        }
    }
}
