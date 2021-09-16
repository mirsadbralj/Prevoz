using Microsoft.Reporting.WinForms;
using Prevoz.Model;
using Prevoz.Model.Requests.Uplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI.Reports.ReportUplateKorisnici
{
    public partial class frmUplateKorisnikaReport : Form
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _korisnikDetails = new ApiService("korisnikdetail");
        private readonly ApiService _uplate = new ApiService("uplate");
        private readonly ApiService _lokacije = new ApiService("lokacija");

        List<Model.Korisnik> korisnicilist = new List<Model.Korisnik>(); 
        List<Lokacija> _listaLokacija = new List<Lokacija>();
        public frmUplateKorisnikaReport()
        {
            InitializeComponent();
        }
        public List<Model.Korisnik> SetListaKorisnikaPoLokaciji(List<KorisnikDetails> listaKOrisnikDetails)
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
        private async void frmUplateKorisnikaReport_Load(object sender, EventArgs e)
        {
            reportViewer1.DocumentMapCollapsed = true;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.Clear();
            var listaLokacija = await _lokacije.Get<List<Lokacija>>(null);

            _listaLokacija = listaLokacija.ToList();

            listaLokacija = listaLokacija.Where(x => x.Naziv != null).ToList();
            List<string> ListaNazivaLokacije = listaLokacija.Select(x => x.Naziv).Distinct().ToList();

            List<string> comb1 = new List<string>();
            comb1.Add(" ");
            for (int i = 0; i < ListaNazivaLokacije.Count(); i++)
            {
                if (ListaNazivaLokacije[i] != null)
                    comb1.Add(ListaNazivaLokacije[i]);
            }
            cmBLokacija.DataSource = comb1;

            var korisnici = await _korisnik.Get<List<Model.Korisnik>>(null);
            var korisniciDetails = await _korisnikDetails.Get<List<Model.KorisnikDetails>>(null);
            var uplate = await _uplate.Get<List<Model.Uplate>>(null);

            List<Model.Korisnik> korisnicilistDetails = new List<Model.Korisnik>();

            UplateKorisnici.tblUplateKorisniciDataTable tbl = new UplateKorisnici.tblUplateKorisniciDataTable();
            for (int i = 0; i < korisnici.Count; i++)
            { 
                UplateKorisnici.tblUplateKorisniciRow red = tbl.NewtblUplateKorisniciRow();

                var UR = new UplateSearchRequest()
                {
                    KorisnikId = korisnici[i].KorisnikId
                };
                var uplateListaSvih = await _uplate.Get<List<Model.Uplate>>(UR);

                uplateListaSvih = uplateListaSvih.Where(x => x.KorisnikId == korisnici[i].KorisnikId).ToList();
                red.KorisnickoIme = korisnici[i].UserName;
                var detalji = korisniciDetails.FirstOrDefault(x => x.KorisnikId == korisnici[i].KorisnikId);
                if (detalji != null)
                {
                    red.Ime = detalji.Ime;
                    red.Prezime = detalji.Prezime;
                    if(detalji.DatumRođenja!=null)
                    red.DatumRođenja = detalji.DatumRođenja.Value;
                }
                else { red.Ime = ""; red.Prezime = ""; }
                red.Uplaceno = uplate.Where(x => x.KorisnikId == korisnici[i].KorisnikId).Select(x => x.Iznos).Sum();
                tbl.Rows.Add(red);
            }
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("Datum", DateTime.Now.Date.ToString()));

            reportViewer1.LocalReport.SetParameters(rpc);

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "UplateKorisnici";
            rds.Value = tbl;
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            if (cmBLokacija.Text != " ")
            {
                reportViewer1.DocumentMapCollapsed = true;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.Clear();

                var korisnici = await _korisnik.Get<List<Model.Korisnik>>(null);
                var korisniciDetails = await _korisnikDetails.Get<List<Model.KorisnikDetails>>(null);
                var uplate = await _uplate.Get<List<Model.Uplate>>(null);

                List<Model.Korisnik> korisnicilistDetails = new List<Model.Korisnik>();

                korisnici = SetListaKorisnikaPoLokaciji(korisniciDetails);
                
                UplateKorisnici.tblUplateKorisniciDataTable tbl = new UplateKorisnici.tblUplateKorisniciDataTable();
                for (int i = 0; i < korisnici.Count; i++)
                {
                    UplateKorisnici.tblUplateKorisniciRow red = tbl.NewtblUplateKorisniciRow();

                    var UR = new UplateSearchRequest()
                    {
                        KorisnikId = korisnici[i].KorisnikId
                    };
                    var uplateListaSvih = await _uplate.Get<List<Model.Uplate>>(UR);

                    uplateListaSvih = uplateListaSvih.Where(x => x.KorisnikId == korisnici[i].KorisnikId).ToList();
                    red.KorisnickoIme = korisnici[i].UserName;
                    var detalji = korisniciDetails.FirstOrDefault(x => x.KorisnikId == korisnici[i].KorisnikId);
                    if (detalji != null)
                    {
                        red.Ime = detalji.Ime;
                        red.Prezime = detalji.Prezime;
                        if (detalji.DatumRođenja != null)
                            red.DatumRođenja = detalji.DatumRođenja.Value;
                    }
                    else { red.Ime = ""; red.Prezime = ""; }
                    red.Uplaceno = uplate.Where(x => x.KorisnikId == korisnici[i].KorisnikId).Select(x => x.Iznos).Sum();
                    tbl.Rows.Add(red);
                }
                ReportParameterCollection rpc = new ReportParameterCollection();
                rpc.Add(new ReportParameter("Datum", DateTime.Now.Date.ToString()));

                reportViewer1.LocalReport.SetParameters(rpc);

                ReportDataSource rds = new ReportDataSource();
                rds.Name = "UplateKorisnici";
                rds.Value = tbl;
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
            else
                frmUplateKorisnikaReport_Load(sender, e);
        }
    }
}
