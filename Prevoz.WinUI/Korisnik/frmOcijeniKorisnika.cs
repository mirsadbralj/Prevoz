using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Ocjena;
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
    public partial class frmOcijeniKorisnika : Form
    {
        ApiService _korisnik = new ApiService("korisnik");
        ApiService _voznja = new ApiService("voznja");
        ApiService _rezervacije = new ApiService("korisnikrezervacija");
        ApiService _ocjena = new ApiService("ocjena");
        SqlConnection con = new SqlConnection("Server =.; Database=Prevoz;Trusted_Connection=True;MultipleActiveResultSets=true");

        Model.KorisnikRezervacija _rezervacija = new Model.KorisnikRezervacija();
        int _KorisnikId;
        public frmOcijeniKorisnika(Model.KorisnikRezervacija rezervacija, int KorisnikId)
        {
            _rezervacija = rezervacija;
            _KorisnikId = KorisnikId;
            InitializeComponent();
        }
        private void LoadcmbOcjena()
        {
            cmbOcjena.Items.Add(" ");
            cmbOcjena.Items.Add("1");
            cmbOcjena.Items.Add("2");
            cmbOcjena.Items.Add("3");
            cmbOcjena.Items.Add("4");
            cmbOcjena.Items.Add("5");
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
        private async void frmOcijeniKorisnika_Load(object sender, EventArgs e)
        {
            LoadcmbOcjena();
            var korisnik = await _korisnik.GetById<Model.Korisnik>(_KorisnikId);

            lblUsername.Text = korisnik.UserName;
            picBoxSlikaProfila.SizeMode = PictureBoxSizeMode.Zoom;
            if(korisnik.Slika.Length>0 && korisnik.Slika!=null)
            picBoxSlikaProfila.Image = ByteToImage(korisnik.Slika);
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (cmbOcjena.SelectedItem.ToString() == " ") {
                MessageBox.Show("Niste unijeli ocjenu.","",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                cmbOcjena.BackColor = Color.Red;
                    }
            else
            {
                var korisnik = Memorija.Korisnik;
                var request = new OcjenaUpsertRequest()
                {
                    RezervacijaId = _rezervacija.RezervacijaId,
                    KorisnikId = korisnik.KorisnikId,
                    VoznjaId = null,
                    Ocjena1 = Convert.ToInt32(cmbOcjena.SelectedItem)
                };
                await _ocjena.Insert<Model.Korisnik>(request);
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            frm_KorisnikInfo frm = new frm_KorisnikInfo(_KorisnikId);
            frm.Show();
        }

        private void lblUsername_MouseHover(object sender, EventArgs e)
        {
            lblUsername.BackColor = Color.Green;
        }

        private void lblUsername_MouseLeave(object sender, EventArgs e)
        {
            lblUsername.BackColor = default;
        }
    }
}
