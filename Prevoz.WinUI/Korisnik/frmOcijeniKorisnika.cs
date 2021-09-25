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
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _ocjena = new ApiService("ocjena");
        
        private Model.KorisnikRezervacija _rezervacija ;
        private Model.Voznja _voznja = new Model.Voznja();
        int _KorisnikId;
        public frmOcijeniKorisnika(Model.KorisnikRezervacija rezervacija, int KorisnikId)
        {
            _rezervacija = rezervacija;
            _KorisnikId = KorisnikId;
            InitializeComponent();
        }
        public frmOcijeniKorisnika(Model.Voznja voznja, int KorisnikId)
        {
            _voznja = voznja;
            _KorisnikId = KorisnikId;
            InitializeComponent();
        }
        private void LoadcmbOcjena()
        {
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
            if (ValidateChildren())
            {
                var korisnik = Memorija.Korisnik;
                if (_rezervacija != null && _rezervacija.RezervacijaId > 0) {
                    var request = new OcjenaUpsertRequest()
                    {
                        RezervacijaId = _rezervacija.RezervacijaId,
                        KorisnikId = korisnik.KorisnikId,
                        VoznjaId = null,
                        Ocjena1 = Convert.ToInt32(cmbOcjena.SelectedItem)
                    };
                    await _ocjena.Insert<Model.Ocjena>(request);
                }
                else 
                {
                    var request = new OcjenaUpsertRequest()
                    {
                        RezervacijaId = null,
                        KorisnikId = korisnik.KorisnikId,
                        VoznjaId = _voznja.VoznjaId,
                        Ocjena1 = Convert.ToInt32(cmbOcjena.SelectedItem)
                    };
                    await _ocjena.Insert<Model.Ocjena>(request);
                }
                MessageBox.Show("Vaša ocjena je spremljena", "", MessageBoxButtons.OK);

                this.Close();
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
        private void cmbOcjena_Validating(object sender, CancelEventArgs e)
        {
            if (cmbOcjena.SelectedItem == null)
            {
                errorProviderOcjenaKomentar.SetError(cmbOcjena, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderOcjenaKomentar.SetError(cmbOcjena, null);
            }
        }

    }
}
