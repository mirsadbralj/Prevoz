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
    public partial class frmListaNeocijenjenihRezervacijaKorisnika : Form
    {
        int KorisnikId;
        List<Model.KorisnikRezervacija> _rezervacije = new List<Model.KorisnikRezervacija>();
        public frmListaNeocijenjenihRezervacijaKorisnika(int KorisnikID, List<Model.KorisnikRezervacija> rezervacije)
        {
            KorisnikId = KorisnikID;
            _rezervacije = rezervacije;
            InitializeComponent();
        }
        private void frmListaNeocijenjenihRezervacijaKorisnika_Load(object sender, EventArgs e)
        {
            dataGridViewListaNeocijenjenihRezervacija.DataSource = _rezervacije;

            if (dataGridViewListaNeocijenjenihRezervacija.Columns.Contains("KorisnikId"))
            {
                dataGridViewListaNeocijenjenihRezervacija.Columns["RezervacijaId"].Visible = false;
                dataGridViewListaNeocijenjenihRezervacija.Columns["KorisnikId"].Visible = false;
                dataGridViewListaNeocijenjenihRezervacija.Columns["VoznjaId"].Visible = false;
                dataGridViewListaNeocijenjenihRezervacija.Columns["BrojSjedista"].Visible = false;
                dataGridViewListaNeocijenjenihRezervacija.Columns["UkupnoPlaceno"].Visible = false;

                dataGridViewListaNeocijenjenihRezervacija.Columns["DatumRezervacije"].DisplayIndex = 1;
                dataGridViewListaNeocijenjenihRezervacija.Columns["Ocijeni"].DisplayIndex = 2;
                dataGridViewListaNeocijenjenihRezervacija.Columns["DetaljiVoznje"].DisplayIndex = 3;
            }
        }

        private void dataGridViewListaNeocijenjenihRezervacija_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridViewListaNeocijenjenihRezervacija.Columns["Ocijeni"].Index && e.RowIndex >= 0)
            {
                if (dataGridViewListaNeocijenjenihRezervacija.Columns.Contains("KorisnikId"))
                {
                    int korisnikID = (int)dataGridViewListaNeocijenjenihRezervacija.Rows[e.RowIndex].Cells["KorisnikId"].Value;
                    int rezervacijaID = (int)dataGridViewListaNeocijenjenihRezervacija.Rows[e.RowIndex].Cells["RezervacijaId"].Value;
                    Model.KorisnikRezervacija rezervacija = new Model.KorisnikRezervacija();

                    rezervacija = _rezervacije.Where(x => x.RezervacijaId == rezervacijaID).FirstOrDefault();

                    frmOcijeniKorisnika frm = new frmOcijeniKorisnika(rezervacija, korisnikID);
                    frm.Show();


                    this.Close();
                }
            }
            else if (e.ColumnIndex == dataGridViewListaNeocijenjenihRezervacija.Columns["DetaljiVoznje"].Index && e.RowIndex >= 0)
            {
                if (dataGridViewListaNeocijenjenihRezervacija.Columns.Contains("KorisnikId"))
                {
                    int korisnikID = (int)dataGridViewListaNeocijenjenihRezervacija.Rows[e.RowIndex].Cells["KorisnikId"].Value;

                    int voznjaId = (int)dataGridViewListaNeocijenjenihRezervacija.Rows[e.RowIndex].Cells["VoznjaId"].Value;
                    
                    frmHistorijaVoznjiDetails frm = new frmHistorijaVoznjiDetails(voznjaId, korisnikID);
                    frm.Show();

                    this.Close();
                }
            }
        }
    }
}
