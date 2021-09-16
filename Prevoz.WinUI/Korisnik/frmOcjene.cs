using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Ocjena;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Vožnja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmOcjene : Form
    {
        ApiService _korisnik = new ApiService("korisnik");
        ApiService _voznja = new ApiService("voznja");
        ApiService _ocjena = new ApiService("ocjena");
        ApiService _rezervacije = new ApiService("korisnikrezervacija");
        int KorisnikId = 0;
        int IdKorisnikDet = 0;
        List<Model.KorisnikRezervacija> listaNeocijenjenihRezervacija = new List<Model.KorisnikRezervacija>();
        List<Model.Voznja> listaNeocijenjenihVoznji = new List<Model.Voznja>();
        List<Model.Ocjena> _listaOcjenaZaIzracunavanjeProsjeka = new List<Model.Ocjena>();
        public frmOcjene()
        {
            InitializeComponent();
        }
        private void FormatDataGridView()
        {
            dgv_mojeOcjene.Columns[1].Visible = false;
            dgv_mojeOcjene.Columns[2].Visible = false;
            dgv_mojeOcjene.Columns[3].Visible = false;
            dgv_mojeOcjene.Columns[4].Visible = false;
            dgv_mojeOcjene.Columns["Detalji"].DisplayIndex = 6;
        }

        private void FormatdgvOcijeniPreostaleRezervacije()
        {
            dgvOcijeniPreostaleRezervacije.Columns[0].DisplayIndex = 8;
            dgvOcijeniPreostaleRezervacije.Columns[1].DisplayIndex = 7;
            dgvOcijeniPreostaleRezervacije.Columns[2].Visible = false;
            dgvOcijeniPreostaleRezervacije.Columns[4].Visible = false;
            dgvOcijeniPreostaleRezervacije.Columns[5].Visible = false;
            dgvOcijeniPreostaleRezervacije.Columns[6].Visible = false;
            dgvOcijeniPreostaleRezervacije.Columns[7].Visible = false;
            dgvOcijeniPreostaleRezervacije.Columns[8].Visible = false;
        }

        private void FormatDgvOcijeniPreostaleVoznje()
        {
            dgvOcijeniPreostale.Columns[2].Visible = false;
            dgvOcijeniPreostale.Columns[4].Visible = false;
            dgvOcijeniPreostale.Columns[5].Visible = false;
            dgvOcijeniPreostale.Columns[6].Visible = false;
            dgvOcijeniPreostale.Columns[7].Visible = false;
            dgvOcijeniPreostale.Columns[8].Visible = false;
            dgvOcijeniPreostale.Columns[0].DisplayIndex = 8;
            dgvOcijeniPreostale.Columns[1].DisplayIndex = 7;
        }

        private decimal GetProsjek(List<Model.Ocjena> ocjene)
        {
            decimal suma = 0;
            decimal prosjek = 0;
            int brojac = 0;

            for (int i = 0; i < ocjene.Count(); i++)
            {
                    suma += (decimal)ocjene[i].Ocjena1;
                    brojac++;
            }
            prosjek = suma /brojac;

            return prosjek;
        }
    
        private void Set_dgv_MojeOcjene(List<Model.Ocjena> ocjene, List<Model.Voznja> listaVoznji,List<Model.KorisnikRezervacija> listaRezervacija, Model.Korisnik _korisnik)
        {
            List<Model.KorisnikRezervacija> _listaRezervacija = new List<Model.KorisnikRezervacija>();
            List<Model.Ocjena> _listaOcjena = new List<Model.Ocjena>();
            List<Model.Voznja> _listaVoznji= new List<Model.Voznja>();

            for (int i = 0; i < listaRezervacija.Count(); i++)
            {
                for (int j = 0; j < ocjene.Count(); j++)
                {
                    if (ocjene[j].RezervacijaId == listaRezervacija[i].RezervacijaId && listaRezervacija[i].KorisnikId == _korisnik.KorisnikId)
                    {
                        _listaOcjena.Add(ocjene[j]);
                        _listaRezervacija.Add(listaRezervacija[i]);
                    }
                }
            }
            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                for (int j = 0; j < ocjene.Count(); j++)
                {
                    if(ocjene[j].VoznjaId == listaVoznji[i].VoznjaId && listaVoznji[i].KorisnikId == _korisnik.KorisnikId)
                    {
                        _listaVoznji.Add(listaVoznji[i]);
                        _listaOcjena.Add(ocjene[j]);
                    }
                }
            }

            NumberFormatInfo setPrecision = new NumberFormatInfo();
            setPrecision.NumberDecimalDigits = 2;
            decimal ocjena;
            if (_listaOcjena.Count() > 0)
                ocjena = GetProsjek(_listaOcjena);
            else
                ocjena = 0;
            dgv_mojeOcjene.DataSource = _listaOcjena;
            lbl_ProsjcnaOcjena.Text = ocjena.ToString("N", setPrecision);
            FormatDataGridView();
        }

        private List<Model.Korisnik> GetVlasnikeVoznji(List<Model.Voznja> listaVoznji, List<Model.Korisnik> listaKorisnika)
        {
            bool duplicate = false;
            List<Model.Voznja> listaVoznjiWithoutDuplicates = new List<Model.Voznja>();
            List<Model.Korisnik> _listaKorisnika = new List<Model.Korisnik>();
            listaVoznjiWithoutDuplicates.Add(listaVoznji[0]);

            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                duplicate = false;
                for (int j = 0; j < listaVoznjiWithoutDuplicates.Count(); j++)
                {
                    if (listaVoznji[i].KorisnikId == listaVoznjiWithoutDuplicates[j].KorisnikId)
                    {
                        duplicate = true;
                    }
                }
                if (duplicate == false)
                    listaVoznjiWithoutDuplicates.Add(listaVoznji[i]);
            }
            for (int i = 0; i < listaKorisnika.Count(); i++)
            {
                for (int j = 0; j < listaVoznjiWithoutDuplicates.Count(); j++)
                {
                    if (listaKorisnika[i].KorisnikId == listaVoznjiWithoutDuplicates[j].KorisnikId )
                    {
                        _listaKorisnika.Add(listaKorisnika[i]);
                    }
                }
            }
            return _listaKorisnika;
        }
        private List<Model.KorisnikRezervacija> CleanDuplicates(List<Model.KorisnikRezervacija> _listaRezervacija)
        {
            var KorisnikIds = _listaRezervacija.Select(x => x.KorisnikId);

            _listaRezervacija = _listaRezervacija.Where(x => KorisnikIds.Contains(x.KorisnikId)).Distinct().ToList();

            return _listaRezervacija;
        }
        private async void Set_dgv_ListaPreostalihNeocijenjenihVoznji(List<Model.Ocjena> ocjene, List<Model.KorisnikRezervacija> listaRezervacija, Model.Korisnik korisnik)
        {
            List<Model.KorisnikRezervacija> _listaRezervacija = new List<Model.KorisnikRezervacija>();
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();
            List<Model.Korisnik> _listaKorisnika = new List<Model.Korisnik>();
            bool ocijenio = false;
            for (int i = 0; i < listaRezervacija.Count(); i++)
            {
                ocijenio = false;
                for (int j = 0; j < ocjene.Count(); j++)
                {
                    if (ocjene[j].RezervacijaId == listaRezervacija[i].RezervacijaId && ocjene[j].KorisnikId == korisnik.KorisnikId)
                    {
                        ocijenio = true;
                    }
                }
                if (ocijenio == false)
                {
                    _listaRezervacija.Add(listaRezervacija[i]);
                }
            }
            dgvOcijeniPreostale.DataSource = _listaRezervacija;

            _listaRezervacija = CleanDuplicates(_listaRezervacija);

            for (int i = 0; i < _listaRezervacija.Count(); i++)
            {
                int VoznjaId = _listaRezervacija[i].VoznjaId;
                _listaVoznji.Add(await _voznja.GetById<Model.Voznja>(VoznjaId));
            }
            _listaKorisnika = await _korisnik.Get<List<Model.Korisnik>>(null);
            _listaKorisnika = GetVlasnikeVoznji(_listaVoznji, _listaKorisnika);
            listaNeocijenjenihVoznji = _listaVoznji;
            dgvOcijeniPreostale.DataSource = _listaKorisnika;
            FormatDgvOcijeniPreostaleVoznje();
        }

        private async void Set_dgv_listaPreostalihNeocijenjenihRezervacija(List<Model.Ocjena> ocjene, List<Model.Voznja> listaVoznji, List<Model.KorisnikRezervacija> listaRezervacija, Model.Korisnik korisnik)
        {
            List<Model.Korisnik> _listaKorisnika = new List<Model.Korisnik>();
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();
            List<Model.KorisnikRezervacija> _listaRezervacija = new List<Model.KorisnikRezervacija>();
            List<Model.KorisnikRezervacija> _listaRezervacijaWithoutDuplicates = new List<Model.KorisnikRezervacija>();

            var voznjaRequeest = new VoznjaSearchRequest()
            {
                KorisnikId = Memorija.Korisnik.KorisnikId
            };
            _listaVoznji = await _voznja.Get<List<Model.Voznja>>(voznjaRequeest);

            if(_listaVoznji.Count>0 && _listaVoznji != null) 
            {
                _listaVoznji = _listaVoznji.Where(x => x.KorisnikId == Memorija.Korisnik.KorisnikId).ToList();

                var VoznjaIDs = _listaVoznji.Select(x => x.VoznjaId).ToList();
                _listaRezervacija = listaRezervacija;

                _listaRezervacija = listaRezervacija.Where(x => VoznjaIDs.Contains(x.VoznjaId)).ToList();
                _listaRezervacija = _listaRezervacija.Where(x => x.KorisnikId != Memorija.Korisnik.KorisnikId).ToList();
                var RezervacijeIDS = _listaRezervacija.Select(x => x.RezervacijaId);
                var OcijenjeniKorisnici = _listaRezervacija.Select(x => x.KorisnikId);

                ocjene = ocjene.Where(x => x.KorisnikId == Memorija.Korisnik.KorisnikId).ToList();
                var RezervacijeIDSOcjene = ocjene.Select(x => x.RezervacijaId);

                _listaRezervacija = listaRezervacija.Where(x => RezervacijeIDSOcjene.Contains(x.RezervacijaId)).ToList();
                var OcijenjeniKorisniciIDs = _listaRezervacija.Select(x => x.KorisnikId).Distinct().ToList();

                var _listarezervacijeTemp = listaRezervacija.Where(x => VoznjaIDs.Contains(x.VoznjaId)).ToList();
                _listarezervacijeTemp = _listarezervacijeTemp.Where(x => !RezervacijeIDSOcjene.Contains(x.RezervacijaId)).ToList();
                _listarezervacijeTemp = _listarezervacijeTemp.Where(x => x.KorisnikId != Memorija.Korisnik.KorisnikId).ToList();

                var NeocijenjeniKorisnikIDs = _listarezervacijeTemp.Select(x => x.KorisnikId).Distinct().ToList();

                NeocijenjeniKorisnikIDs = NeocijenjeniKorisnikIDs.Where(x => !OcijenjeniKorisniciIDs.Contains(x)).ToList();

                listaNeocijenjenihRezervacija = _listarezervacijeTemp;
                var rezervationIDs = _listarezervacijeTemp.Select(x => x.RezervacijaId);
                foreach (int item in NeocijenjeniKorisnikIDs)
                {
                    _listaKorisnika.Add(await _korisnik.GetById<Model.Korisnik>(item));
                }

                dgvOcijeniPreostaleRezervacije.DataSource = _listaKorisnika;
                FormatdgvOcijeniPreostaleRezervacije();
            }
        }
        private async void frmOcjene_Load(object sender, EventArgs e)
        {
            var korisnik = Memorija.Korisnik;
            IdKorisnikDet = korisnik.KorisnikId;
            var listaRezervacijaFull = await _rezervacije.Get<List<Model.KorisnikRezervacija>>(null);

            var RezervacijeRequest = new KorisnikRezervacijaSearchRequest(){ KorisnikId = korisnik.KorisnikId };
            var listaRezervacija = await _rezervacije.Get<List<Model.KorisnikRezervacija>>(RezervacijeRequest);

            var VoznjaRequest = new VoznjaSearchRequest() { KorisnikId = korisnik.KorisnikId, DatumVoznje=DateTime.MinValue};
            var listaVoznji = await _voznja.Get<List<Model.Voznja>>(VoznjaRequest);

            var OcjeneRequest = new OcjenaSearchRequest() { };
            var ocjene = await _ocjena.Get<List<Model.Ocjena>>(null);

            if(listaRezervacija.Count() > 0)
            Set_dgv_ListaPreostalihNeocijenjenihVoznji(ocjene, listaRezervacija, korisnik);

            if (listaVoznji.Count() > 0)
            Set_dgv_listaPreostalihNeocijenjenihRezervacija(ocjene, listaVoznji, listaRezervacijaFull, korisnik);

            if(listaRezervacija.Count > 0 || listaVoznji.Count > 0)
            Set_dgv_MojeOcjene(ocjene, listaVoznji, listaRezervacija, korisnik);


            if (lbl_ProsjcnaOcjena.Text == "label2")
                lbl_ProsjcnaOcjena.Text = "Još niste ocijenjeni.";
        }

        private void dgv_mojeOcjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==dgv_mojeOcjene.Columns["Detalji"].Index && e.RowIndex >= 0 )
            {
                if (dgv_mojeOcjene.Columns.Contains("OcjenaId") && dgv_mojeOcjene.Rows[e.RowIndex].Cells["OcjenaId"].Value != null)
                {
                    int ocjena = (int)dgv_mojeOcjene.Rows[e.RowIndex].Cells["OcjenaId"].Value;
                    frmOcjenaDetail frm = new frmOcjenaDetail(ocjena);
                    frm.Show();
                }
            }
        }
        private void dgvOcijeniPreostaleRezervacije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvOcijeniPreostaleRezervacije.Columns["DetaljiRezervacije"].Index && e.RowIndex >= 0)
            {
                if (dgvOcijeniPreostaleRezervacije.Rows.Count >= 1 && dgvOcijeniPreostaleRezervacije.Columns.Contains("KorisnikId"))
                {
                    KorisnikId = (int)dgvOcijeniPreostaleRezervacije.Rows[e.RowIndex].Cells["KorisnikId"].Value;
                    int VoznjaId = 0;
                    for (int i = 0; i < listaNeocijenjenihRezervacija.Count(); i++)
                    {
                        if (listaNeocijenjenihRezervacija[i].KorisnikId == KorisnikId)
                            VoznjaId = listaNeocijenjenihRezervacija[i].VoznjaId;
                    }
                    frmHistorijaVoznjiDetails frm = new frmHistorijaVoznjiDetails(VoznjaId, KorisnikId);
                    frm.Show();
                }
            }

            else if(e.ColumnIndex == dgvOcijeniPreostaleRezervacije.Columns["OcijeniRezervaciju"].Index && e.RowIndex >= 0)
            {
                if (dgvOcijeniPreostaleRezervacije.Columns.Contains("KorisnikId"))
                {
                    KorisnikId = (int)dgvOcijeniPreostaleRezervacije.Rows[e.RowIndex].Cells["KorisnikId"].Value;
                    var rezervacija = listaNeocijenjenihRezervacija.Where(x => x.KorisnikId == KorisnikId).ToList();
                    frmOcijeniKorisnika frm = new frmOcijeniKorisnika(rezervacija[0], KorisnikId);
                    frm.Show();
                }
            }
        }
        private void dgvOcijeniPreostale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOcijeniPreostale.Columns["DetaljiVoznje"].Index && e.RowIndex >= 0)
            {
                
                if (dgvOcijeniPreostale.Rows.Count >= 1 && dgvOcijeniPreostale.Columns.Contains("KorisnikId"))
                {
                    KorisnikId = (int)dgvOcijeniPreostale.Rows[e.RowIndex].Cells["KorisnikId"].Value;
                    int VoznjaId = 0;
                 
                    VoznjaId = listaNeocijenjenihVoznji[e.RowIndex].VoznjaId;

                    frmHistorijaVoznjiDetails frm = new frmHistorijaVoznjiDetails(VoznjaId, KorisnikId);
                    frm.Show();
                }
            }
            else if (e.ColumnIndex == dgvOcijeniPreostale.Columns["Ocijeni"].Index && e.RowIndex >= 0 && dgvOcijeniPreostale.Columns.Contains("Ocijeni"))
            {
                if (dgvOcijeniPreostale.Columns.Contains("KorisnikId"))
                {
                    KorisnikId = (int)dgvOcijeniPreostale.Rows[e.RowIndex].Cells["KorisnikId"].Value;
                    var rezervacija = listaNeocijenjenihRezervacija[e.RowIndex];
                    frmOcijeniKorisnika frm = new frmOcijeniKorisnika(rezervacija, KorisnikId);
                    frm.Show();
                }
            }
        }
    }
}
