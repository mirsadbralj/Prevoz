using Prevoz.Model;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Vožnja;
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
    public partial class frmZahtjevi : Form
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _voznje = new ApiService("voznja");
        private readonly ApiService _lokacija = new ApiService("lokacija");
        private readonly ApiService _korisnikRezervacija = new ApiService("korisnikrezervacija");
        private readonly ApiService _zahtjevi = new ApiService("zahtjevi");
        public frmZahtjevi()
        {
            InitializeComponent();
        }

        private async void frmZahtjevi_Load(object sender, EventArgs e)
        {
            var voznjeRequest = new VoznjaSearchRequest()
            {
                KorisnikId = Memorija.Korisnik.KorisnikId
            };
            var listaVoznji = await _voznje.Get<List<Model.Voznja>>(voznjeRequest);
            var VoznjeIDs = listaVoznji.Select(x => x.VoznjaId);
            var listazahtjeva = await _zahtjevi.Get<List<Zahtjevi>>(null);

            listazahtjeva = listazahtjeva.Where(x => VoznjeIDs.Contains(x.VoznjaID)).ToList();

            var listazahtjevaprihvaceni = listazahtjeva.Where(x => x.Status == "Odobreno").ToList();
            var listazahtjevaotkazani = listazahtjeva.Where(x => x.Status == "Otkazano").ToList();
            listazahtjeva = listazahtjeva.Where(x => x.Status != "Odobreno" && x.Status != "Otkazano").ToList();

            dataGridViewPrihvaceniZahtjevi.DataSource = listazahtjevaprihvaceni;
            dataGridViewOtkazaniZahtjevi.DataSource = listazahtjevaotkazani;
            dataGridViewAktivniZahtjevi.DataSource = listazahtjeva;

            if (dataGridViewAktivniZahtjevi.Columns.Contains("ZahtjevID"))
            {
                dataGridViewAktivniZahtjevi.Columns["ZahtjevID"].Visible = false;
                dataGridViewAktivniZahtjevi.Columns["KorisnikID"].Visible = false;
                dataGridViewAktivniZahtjevi.Columns["VoznjaID"].Visible = false;

                dataGridViewAktivniZahtjevi.Columns["Datum"].DisplayIndex = 1;
                dataGridViewAktivniZahtjevi.Columns["Status"].DisplayIndex = 2;
                dataGridViewAktivniZahtjevi.Columns["Prihvati"].DisplayIndex = 5;
                dataGridViewAktivniZahtjevi.Columns["Ponisti"].DisplayIndex = 6;
                dataGridViewAktivniZahtjevi.Columns["ViseInformacija"].DisplayIndex = 7;

            }
            if (dataGridViewPrihvaceniZahtjevi.Columns.Contains("ZahtjevID"))
            {
                dataGridViewPrihvaceniZahtjevi.Columns["ZahtjevID"].Visible = false;
                dataGridViewPrihvaceniZahtjevi.Columns["KorisnikID"].Visible = false;
                dataGridViewPrihvaceniZahtjevi.Columns["VoznjaID"].Visible = false;

                dataGridViewPrihvaceniZahtjevi.Columns["Datum"].DisplayIndex = 1;
                dataGridViewPrihvaceniZahtjevi.Columns["Status"].DisplayIndex = 2;
                dataGridViewPrihvaceniZahtjevi.Columns["ViseInfo"].DisplayIndex = 5;
            }
            if (dataGridViewOtkazaniZahtjevi.Columns.Contains("ZahtjevID"))
            {
                dataGridViewOtkazaniZahtjevi.Columns["ZahtjevID"].Visible = false;
                dataGridViewOtkazaniZahtjevi.Columns["KorisnikID"].Visible = false;
                dataGridViewOtkazaniZahtjevi.Columns["VoznjaID"].Visible = false;

                dataGridViewOtkazaniZahtjevi.Columns["Datum"].DisplayIndex = 1;
                dataGridViewOtkazaniZahtjevi.Columns["Status"].DisplayIndex = 2;
                dataGridViewOtkazaniZahtjevi.Columns["Vise"].DisplayIndex = 5;
            }
        }
        public async void PonistiZahtjev(int zahtjevID)
        {
            var zahtjev = await _zahtjevi.GetById<Zahtjevi>(zahtjevID);
            zahtjev.Status = "Otkazano";
            await _zahtjevi.Update<Model.Zahtjevi>(zahtjevID, zahtjev);
        }
        public async void OdobriZahtjev(int zahtjevID)
        {
            var voznjeRequest = new VoznjaSearchRequest()
            {
                KorisnikId = Memorija.Korisnik.KorisnikId
            };
            var listaVoznji = await _voznje.Get<List<Model.Voznja>>(voznjeRequest);
            var VoznjeIDs = listaVoznji.Select(x => x.VoznjaId);
            var zahtjev = await _zahtjevi.GetById<Model.Zahtjevi>(zahtjevID);
            var listazahtjeva = await _zahtjevi.Get<List<Zahtjevi>>(null);
            var voznja = await _voznje.GetById<Model.Voznja>(zahtjev.VoznjaID);

            if (voznja.KorisnikId != zahtjev.KorisnikID)
            {
                if (voznja.BrojSjedista > 0)
                {
                    var requestRezervacija = new KorisnikRezervacijaUpsertRequest()
                    {
                        KorisnikId = zahtjev.KorisnikID,
                        VoznjaId = zahtjev.VoznjaID,
                        BrojSjedista = +1,
                        UkupnoPlaceno = voznja.CijenaSjedista,
                        DatumRezervacije = DateTime.Now
                    };
                    await _korisnikRezervacija.Insert<Model.KorisnikRezervacija>(requestRezervacija);
                    --voznja.BrojSjedista;
                    var UpdateRequestVoznja = new VoznjaUpsertRequest()
                    {
                        KorisnikId = voznja.KorisnikId,
                        VoziloId = voznja.VoziloId,
                        BrojSjedista = voznja.BrojSjedista,
                        CijenaSjedista = voznja.CijenaSjedista,
                        DatumVoznje = voznja.DatumVoznje,
                        AutomatskoOdobrenje = voznja.AutomatskoOdobrenje,
                        Cigarete = voznja.Cigarete,
                        KucniLjubimci = voznja.KucniLJubimci,
                        Detaljnije = voznja.Detaljnije,
                        StartId = voznja.StartId,
                        EndId = voznja.EndId,
                        Status = voznja.Status
                    };
                    await _voznje.Update<Model.Voznja>(voznja.VoznjaId, UpdateRequestVoznja);

                    zahtjev.Status = "Odobreno";
                    await _zahtjevi.Update<Model.Zahtjevi>(zahtjev.ZahtjevID, zahtjev);
                }
                else
                {
                    zahtjev.Status = "Otkazano";
                    await _zahtjevi.Update<Model.Zahtjevi>(zahtjev.ZahtjevID, zahtjev);
                }
            }
        }

        private void dataGridViewAktivniZahtjevi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewAktivniZahtjevi.Columns["Prihvati"].Index && e.RowIndex >= 0)
            {
                if (dataGridViewAktivniZahtjevi.Columns.Contains("ZahtjevID"))
                {
                    int ZahtjevID = (int)dataGridViewAktivniZahtjevi.Rows[e.RowIndex].Cells["ZahtjevID"].Value;
                    OdobriZahtjev(ZahtjevID);
                }
            }
            if (e.ColumnIndex == dataGridViewAktivniZahtjevi.Columns["Ponisti"].Index && e.RowIndex >= 0)
            {
                if (dataGridViewAktivniZahtjevi.Columns.Contains("ZahtjevID"))
                {
                    int ZahtjevID = (int)dataGridViewAktivniZahtjevi.Rows[e.RowIndex].Cells["ZahtjevID"].Value;
                    PonistiZahtjev(ZahtjevID);
                }
            }

            if (e.ColumnIndex == dataGridViewAktivniZahtjevi.Columns["ViseInformacija"].Index && e.RowIndex >= 0)
            {
                if (dataGridViewAktivniZahtjevi.Columns.Contains("KorisnikID"))
                {
                    int KorisnikID = (int)dataGridViewAktivniZahtjevi.Rows[e.RowIndex].Cells["KorisnikID"].Value;
                    frm_KorisnikInfo frm = new frm_KorisnikInfo(KorisnikID);
                    frm.Show();
                }
            }
        }

        private void dataGridViewPrihvaceniZahtjevi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPrihvaceniZahtjevi.Columns["ViseInfo"].Index && e.RowIndex >= 0)
            {
                if (dataGridViewPrihvaceniZahtjevi.Columns.Contains("KorisnikID"))
                {
                    int KorisnikID = (int)dataGridViewPrihvaceniZahtjevi.Rows[e.RowIndex].Cells["KorisnikID"].Value;
                    frm_KorisnikInfo frm = new frm_KorisnikInfo(KorisnikID);
                    frm.Show();
                }
            }
        }

        private void dataGridViewOtkazaniZahtjevi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewOtkazaniZahtjevi.Columns["Vise"].Index && e.RowIndex >= 0)
            {
                if (dataGridViewOtkazaniZahtjevi.Columns.Contains("KorisnikID"))
                {
                    int KorisnikID = (int)dataGridViewOtkazaniZahtjevi.Rows[e.RowIndex].Cells["KorisnikID"].Value;
                    frm_KorisnikInfo frm = new frm_KorisnikInfo(KorisnikID);
                    frm.Show();
                }
            }
        }
    }
}
