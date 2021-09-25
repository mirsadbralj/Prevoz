using Prevoz.Model;
using Prevoz.Model.Requests.Poruka;
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
    public partial class frmPosaljiPoruku : Form
    {
        private readonly ApiService _poruka = new ApiService("poruka");
        private readonly int KorisnikId = 0;
        List<Poruka> listPoruke = new List<Poruka>();
        public frmPosaljiPoruku(int KorisnikID)
        {
            KorisnikId = KorisnikID;
            InitializeComponent();
        }

        private async void frmPosaljiPoruku_Load(object sender, EventArgs e)
        {
            var korisnik = Memorija.Korisnik;
            var requestPoruke = new PorukaSearchRequest()
            {
                PosiljaocID = korisnik.KorisnikId,
                PrimaocID = KorisnikId
            };
            var poruke = await _poruka.Get<List<Model.Poruka>>(requestPoruke);
            foreach (var poruka in poruke)
            {
                poruka.JaPosiljaoc = korisnik.KorisnikId == poruka.PosiljaocID;
                listPoruke.Add(poruka);
            }

            dgv_listaPoruka.DataSource = listPoruke;


            if (dgv_listaPoruka.Columns.Contains("JaPosiljaoc"))
                dgv_listaPoruka.Columns["JaPosiljaoc"].Visible = false;

            if (dgv_listaPoruka.Columns.Contains("JaNisamPosiljaoc"))
                dgv_listaPoruka.Columns["JaNisamPosiljaoc"].Visible = false;
        }

        private async void RefreshMessages()
        {
            var korisnik = Memorija.Korisnik;
            var requestPoruke = new PorukaSearchRequest()
            {
                PosiljaocID = korisnik.KorisnikId,
                PrimaocID = KorisnikId
            };
            var poruke = await _poruka.Get<List<Model.Poruka>>(requestPoruke);
            foreach (var poruka in poruke)
            {
                poruka.JaPosiljaoc = korisnik.KorisnikId == poruka.PosiljaocID;
                listPoruke.Add(poruka);
            }

            dgv_listaPoruka.DataSource = listPoruke;
        }
        private async void btnPosaljiPoruku_Click(object sender, EventArgs e)
        {
            var korisnik = Memorija.Korisnik;
            var RequestPoruka = new PorukaUpsertRequest()
            {
                PosiljaocID = korisnik.KorisnikId,
                PrimaocID = KorisnikId,
                Sadrzaj = txtTekstPoruke.Text,
                DatumVrijeme = DateTime.Now
            };
            await _poruka.Insert<Model.Poruka>(RequestPoruka);

            RefreshMessages();

            txtTekstPoruke.Text = "";

            MessageBox.Show("Poruka poslana");
        }
    }
}
