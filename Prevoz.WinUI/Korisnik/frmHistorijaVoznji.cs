using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Rezervacija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;
using Prevoz.Model.Requests.Vožnja;
using Prevoz.Model.Requests.Lokacija;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmHistorijaVoznji : Form
    {
        private readonly ApiService _rezervacija= new ApiService("korisnikrezervacija");
        private readonly ApiService _voznja = new ApiService("voznja");
        int KorisnikId = -1;
        public frmHistorijaVoznji()
        {
            InitializeComponent();
        }
        private void FormatDGV()
        {
            dgvHistorijaRezervisanihVoznji.Columns["Detalji"].DisplayIndex = 9;
            dgvHistorijaRezervisanihVoznji.Columns[1].Visible = false;
            dgvHistorijaRezervisanihVoznji.Columns[2].Visible = false;
            dgvHistorijaRezervisanihVoznji.Columns[3].Visible = false;
            dgvHistorijaRezervisanihVoznji.Columns[4].Visible = false;
            dgvHistorijaRezervisanihVoznji.Columns[5].Visible = false;
            dgvHistorijaRezervisanihVoznji.Columns[6].Visible = false;

            dgvHistorijaPonudenihVoznji.Columns["DetaljiVoznje"].DisplayIndex = 9;
            dgvHistorijaPonudenihVoznji.Columns[1].Visible = false;
            dgvHistorijaPonudenihVoznji.Columns[2].Visible = false;
            dgvHistorijaPonudenihVoznji.Columns[3].Visible = false;
            dgvHistorijaPonudenihVoznji.Columns[4].Visible = false;
            dgvHistorijaPonudenihVoznji.Columns[5].Visible = false;
            dgvHistorijaPonudenihVoznji.Columns[6].Visible = false;


            if (dgvHistorijaPonudenihVoznji.Columns.Contains("AutomatskoOdobrenje"))
                dgvHistorijaPonudenihVoznji.Columns["AutomatskoOdobrenje"].Visible = false;

            if (dgvHistorijaPonudenihVoznji.Columns.Contains("Cigarete"))
                dgvHistorijaPonudenihVoznji.Columns["Cigarete"].Visible = false;

            if (dgvHistorijaPonudenihVoznji.Columns.Contains("KucniLJubimci"))
                dgvHistorijaPonudenihVoznji.Columns["KucniLJubimci"].Visible = false;

            if (dgvHistorijaPonudenihVoznji.Columns.Contains("Detaljnije"))
                dgvHistorijaPonudenihVoznji.Columns["Detaljnije"].Visible = false;


            if (dgvHistorijaRezervisanihVoznji.Columns.Contains("AutomatskoOdobrenje"))
                dgvHistorijaRezervisanihVoznji.Columns["AutomatskoOdobrenje"].Visible = false;

            if (dgvHistorijaRezervisanihVoznji.Columns.Contains("Cigarete"))
                dgvHistorijaRezervisanihVoznji.Columns["Cigarete"].Visible = false;

            if (dgvHistorijaRezervisanihVoznji.Columns.Contains("KucniLJubimci"))
                dgvHistorijaRezervisanihVoznji.Columns["KucniLJubimci"].Visible = false;

            if (dgvHistorijaRezervisanihVoznji.Columns.Contains("Detaljnije"))
                dgvHistorijaRezervisanihVoznji.Columns["Detaljnije"].Visible = false;

        }
        private List<Model.Voznja> CleanDuplicates(List<Model.Voznja> listaVoznji)
        {
            List<Model.Voznja> listaVoznjiWithoutDuplicates = new List<Model.Voznja>();
            listaVoznjiWithoutDuplicates.Add(listaVoznji[0]);
            bool duplicate = false;
            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                duplicate = false;
                for (int j = 0; j < listaVoznjiWithoutDuplicates.Count(); j++)
                {
                    if (listaVoznji[i].VoznjaId == listaVoznjiWithoutDuplicates[j].VoznjaId)
                    {
                        duplicate = true;
                    }
                }
                if (duplicate == false)
                    listaVoznjiWithoutDuplicates.Add(listaVoznji[i]);
            }
            return listaVoznjiWithoutDuplicates;
        }
        private List<Model.Voznja> GetHistorijaPonudenihVoznji(List<Model.Voznja> listaVoznji, int KorisnikId)
        {
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();
            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                if (listaVoznji[i].KorisnikId == KorisnikId)
                {
                    _listaVoznji.Add(listaVoznji[i]);
                }
            }
            return _listaVoznji;
        }
        private List<Model.Voznja> GetHistorijaRezervisanihVoznji(List<Model.Voznja> listaVoznji, List<Model.KorisnikRezervacija> listaRezervacija, Model.Korisnik korisnik)
        {
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();
            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                for (int j = 0; j < listaRezervacija.Count(); j++)
                {
                    if (listaVoznji[i].VoznjaId == listaRezervacija[j].VoznjaId && listaRezervacija[j].KorisnikId == korisnik.KorisnikId)
                    {
                        _listaVoznji.Add(listaVoznji[i]);
                    }
                }
            }
            _listaVoznji = CleanDuplicates(_listaVoznji);

            return _listaVoznji;
        }
        private async void frmHistorijaVoznji_Load(object sender, EventArgs e)
        {
            var korisnik = Memorija.Korisnik;

            var requestVoznjaKID = new VoznjaSearchRequest()
            {
                KorisnikId = korisnik.KorisnikId
            };
            var voznje = await _voznja.Get<List<Model.Voznja>>(null); 

            var rezervacijerequest = new KorisnikRezervacijaSearchRequest() { KorisnikId = korisnik.KorisnikId };
            var rezervacije = await _rezervacija.Get<List<Model.KorisnikRezervacija>>(rezervacijerequest);
            KorisnikId = korisnik.KorisnikId;

            List<Model.Voznja> _listaPonudenihVoznji = new List<Model.Voznja>();
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();

            if(voznje.Count() > 0 && rezervacije.Count > 0)
            _listaVoznji = GetHistorijaRezervisanihVoznji(voznje, rezervacije,korisnik);
            
            dgvHistorijaRezervisanihVoznji.DataSource = _listaVoznji;

            if(voznje.Count()>0)
            _listaPonudenihVoznji = GetHistorijaPonudenihVoznji(voznje, korisnik.KorisnikId);
            dgvHistorijaPonudenihVoznji.DataSource = _listaPonudenihVoznji;

            FormatDGV();
        }
        private void dgvHistorijaRezervisanihVoznji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHistorijaRezervisanihVoznji.Columns["Detalji"].Index && e.RowIndex >= 0)
            {
                if (dgvHistorijaRezervisanihVoznji.Columns.Contains("VoznjaId"))
                {
                    int VoznjaId = (int)dgvHistorijaRezervisanihVoznji.Rows[e.RowIndex].Cells["VoznjaId"].Value;
                    int KorisnikId = (int)dgvHistorijaRezervisanihVoznji.Rows[e.RowIndex].Cells["KorisnikId"].Value;
                    frmHistorijaVoznjiDetails frm = new frmHistorijaVoznjiDetails(VoznjaId, KorisnikId);
                    frm.Show();
                }
            }
        }
        private void dgvHistorijaPonudenihVoznji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHistorijaPonudenihVoznji.Columns["DetaljiVoznje"].Index && e.RowIndex >= 0)
            {
                if (dgvHistorijaPonudenihVoznji.Columns.Contains("VoznjaId"))
                {
                    int VoznjaId = (int)dgvHistorijaPonudenihVoznji.Rows[e.RowIndex].Cells["VoznjaId"].Value;
                    frmHistorijaVoznjiDetails frm = new frmHistorijaVoznjiDetails(VoznjaId, KorisnikId);
                    frm.Show();
                }
            }
        }
    }
}
