using Microsoft.Reporting.WinForms;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.WinUI.Reports.ReportRegistrovaniKorisnici;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI.Reports
{
    public partial class frmBrojRegistrovanihKorisnikaReport : Form
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _korisnikDetails = new ApiService("korisnikdetail");
        private readonly ApiService _lokacija = new ApiService("lokacija");

        List<Model.Korisnik> korisnicilist = new List<Model.Korisnik>();
        List<Lokacija> _listaLokacija = new List<Lokacija>();
        public frmBrojRegistrovanihKorisnikaReport()
        {
            InitializeComponent();
        }
        public List<Model.Korisnik> SetListaKorisnikaPoLokaciji( List<KorisnikDetails> listaKOrisnikDetails)
        {
            if (cmBLokacija.Text != " ")
            {
                _listaLokacija = _listaLokacija.Where(x => x.Naziv == cmBLokacija.Text).ToList();

                var KOrisnikIDS = korisnicilist.Select(x => x.KorisnikId);

                listaKOrisnikDetails = listaKOrisnikDetails.Where(x => KOrisnikIDS.Contains(x.KorisnikId)).ToList();

                var LokacijaIDS = _listaLokacija.Select(x => x.LokacijaId);

                listaKOrisnikDetails = listaKOrisnikDetails.Where(x => x.Lokacija != null && LokacijaIDS.Contains(x.Lokacija.Value)).ToList();

                var korisnikDetilsIds = listaKOrisnikDetails.Select(x => x.KorisnikId);

                korisnicilist = korisnicilist.Where(x => korisnikDetilsIds.Contains(x.KorisnikId)).ToList();

                korisnicilist.Count();
                return korisnicilist;
            }

            return korisnicilist;
        }

        private async void frmBrojRegistrovanihKorisnikaReport_Load(object sender, EventArgs e)
        {
            reportViewer1.DocumentMapCollapsed = true;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.Clear();
            var listaLokacija = await _lokacija.Get<List<Lokacija>>(null);

            _listaLokacija = listaLokacija.ToList();

            listaLokacija = listaLokacija.Where(x => x.Naziv != null).ToList();
            List<string> ListaNazivaLokacije = listaLokacija.Select(x => x.Naziv).Distinct().ToList();


            List<string> comb1 = new List<string>();
            comb1.Add(" ");
            for (int i = 0; i < ListaNazivaLokacije.Count(); i++)
            {
                if(ListaNazivaLokacije[i]!=null)
                comb1.Add(ListaNazivaLokacije[i]);
            }
             cmBLokacija.DataSource = comb1;

            List<string> comb = new List<string>();
            comb.Add(" ");
            int godina = DateTime.Now.Date.Year - 5;
            for (int i = godina; i <= DateTime.Now.Date.Year; i++)
            {
                comb.Add(i.ToString());
            }
            comboBoxGodine.DataSource = comb;

            var korisnici = await _korisnik.Get<List<Model.Korisnik>>(null);
            var korisniciDetails = await _korisnikDetails.Get<List<Model.KorisnikDetails>>(null);

            if (!string.IsNullOrWhiteSpace(comboBoxGodine.SelectedItem.ToString()))
            {

                korisnicilist = korisnici.Where(x => x.CreatedAt.Value.Date.Year.ToString() == comboBoxGodine.SelectedItem.ToString()).ToList(); ;
            }
            else
                korisnicilist = korisnici;

            RegistrovaniKorisnici.tblRegistrovaniKorisniciDataTable tbl = new RegistrovaniKorisnici.tblRegistrovaniKorisniciDataTable();
            for (int i = 0; i < korisnicilist.Count; i++)
            {
                RegistrovaniKorisnici.tblRegistrovaniKorisniciRow red = tbl.NewtblRegistrovaniKorisniciRow();
                red.KorisnickoIme = korisnicilist[i].UserName;
                var detalji = korisniciDetails.FirstOrDefault(x => x.KorisnikId == korisnici[i].KorisnikId);
                if (detalji != null)
                {
                    red.Ime = korisniciDetails.Where(x => x.KorisnikId == korisnicilist[i].KorisnikId).Select(x => x.Ime).First();
                    red.Prezime = korisniciDetails.Where(x => x.KorisnikId == korisnicilist[i].KorisnikId).Select(x => x.Prezime).First();
                }
                else { red.Ime = ""; red.Prezime = ""; }
                red.DatumKreiranja = (DateTime)korisnicilist[i].CreatedAt;
                red.MjesecGodina = $"{red.DatumKreiranja.Month}. {red.DatumKreiranja.Year}";
                tbl.Rows.Add(red);
            }
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("Datum", DateTime.Now.Date.ToString()));

            reportViewer1.LocalReport.SetParameters(rpc);

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "RegistrovaniKorisnici";
            rds.Value = tbl;
            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var korisnici = await _korisnik.Get<List<Model.Korisnik>>(null);

            if (comboBoxGodine.SelectedItem.ToString() != " " || cmBLokacija.Text != " ")
            {
                reportViewer1.DocumentMapCollapsed = true;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.Clear();
                var korisniciDetails = await _korisnikDetails.Get<List<Model.KorisnikDetails>>(null);

                List<Model.Korisnik> korisnicilist = new List<Model.Korisnik>();
                List<Model.Korisnik> korisnicilistDetails = new List<Model.Korisnik>();
                if (!string.IsNullOrWhiteSpace(comboBoxGodine.SelectedItem.ToString()))
                {
                    korisnicilist = korisnici.Where(x => x.CreatedAt.Value.Date.Year.ToString() == comboBoxGodine.SelectedItem.ToString()).ToList();
                }
                if (cmBLokacija.SelectedItem != null)
                {
                    List<KorisnikDetails> listaKorisnikDetails = await _korisnikDetails.Get<List<Model.KorisnikDetails>>(null);

                    korisnicilist = SetListaKorisnikaPoLokaciji(listaKorisnikDetails);
                }
                else
                     korisnicilist = korisnici;

                RegistrovaniKorisnici.tblRegistrovaniKorisniciDataTable tbl = new RegistrovaniKorisnici.tblRegistrovaniKorisniciDataTable();
                for (int i = 0; i < korisnicilist.Count; i++)
                {
                    RegistrovaniKorisnici.tblRegistrovaniKorisniciRow red = tbl.NewtblRegistrovaniKorisniciRow();
                    red.KorisnickoIme = korisnicilist[i].UserName;
                    var detalji = korisniciDetails.FirstOrDefault(x => x.KorisnikId == korisnicilist[i].KorisnikId);
                    if (detalji != null)
                    {
                        red.Ime = korisniciDetails.Where(x => x.KorisnikId == korisnicilist[i].KorisnikId).Select(x => x.Ime).First();
                        red.Prezime = korisniciDetails.Where(x => x.KorisnikId == korisnicilist[i].KorisnikId).Select(x => x.Prezime).First();
                    }
                    else { red.Ime = ""; red.Prezime = ""; }
                    red.DatumKreiranja = (DateTime)korisnicilist[i].CreatedAt;
                    red.MjesecGodina = $"{red.DatumKreiranja.Month}. {red.DatumKreiranja.Year}";
                    tbl.Rows.Add(red);
                }
                ReportParameterCollection rpc = new ReportParameterCollection();
                rpc.Add(new ReportParameter("Datum", DateTime.Now.Date.ToString()));
                reportViewer1.LocalReport.SetParameters(rpc);

                ReportDataSource rds = new ReportDataSource();
                rds.Name = "RegistrovaniKorisnici";
                rds.Value = tbl;
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
                this.Refresh();
            }
            else 
            {
                frmBrojRegistrovanihKorisnikaReport_Load(sender, e);
            }
        }
    }
}
