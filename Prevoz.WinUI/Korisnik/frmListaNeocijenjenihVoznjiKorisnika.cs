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
    public partial class frmListaNeocijenjenihVoznjiKorisnika : Form
    {
        private readonly ApiService _korisnici = new ApiService("korisnik");

        private int KorisnikId;
        List<Model.Voznja> listaNeocijenjenihVoznji;
        public frmListaNeocijenjenihVoznjiKorisnika(int KorisnikID, List<Model.Voznja> listaVoznji)
        {
            InitializeComponent();
            KorisnikId = KorisnikID;
            listaNeocijenjenihVoznji = listaVoznji;
        }

        private void frmListaNeocijenjenihVoznjiKorisnika_Load(object sender, EventArgs e)
        {
            listaNeocijenjenihVoznji = listaNeocijenjenihVoznji.Where(x => x.KorisnikId == KorisnikId).ToList();

            dataGridViewListaNeocijenjenihVoznji.DataSource = listaNeocijenjenihVoznji;

            if(dataGridViewListaNeocijenjenihVoznji.Columns.Contains("VoznjaId"))
            {
                dataGridViewListaNeocijenjenihVoznji.Columns["VoznjaId"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["KorisnikId"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["StartId"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["EndId"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["VoziloId"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["CijenaSjedista"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["BrojSjedista"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["Status"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["AutomatskoOdobrenje"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["KucniLJubimci"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["Cigarete"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["Detaljnije"].Visible = false;
                dataGridViewListaNeocijenjenihVoznji.Columns["OcijeniVoznju"].DisplayIndex = 11;

            }

        }
        private void dataGridViewListaNeocijenjenihVoznji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridViewListaNeocijenjenihVoznji.Columns["OcijeniVoznju"].Index && e.RowIndex>=0)
            {

                if (dataGridViewListaNeocijenjenihVoznji.Columns.Contains("KorisnikId"))
                {
                    int korisnikID = (int)dataGridViewListaNeocijenjenihVoznji.Rows[e.RowIndex].Cells["KorisnikId"].Value;

                    int voznjaId = (int)dataGridViewListaNeocijenjenihVoznji.Rows[e.RowIndex].Cells["VoznjaId"].Value;

                    Model.Voznja voznja = new Model.Voznja();
                    foreach(var item in listaNeocijenjenihVoznji)
                    {
                        if(item.VoznjaId== voznjaId)
                        {
                            voznja = item;
                            continue;
                        }
                    }

                    frmOcijeniKorisnika frm = new frmOcijeniKorisnika(voznja, korisnikID);
                    frm.Show();


                    this.Close();
                }
            }
            else if(e.ColumnIndex == dataGridViewListaNeocijenjenihVoznji.Columns["DetaljiVoznje"].Index && e.RowIndex >= 0)
            {
                if (dataGridViewListaNeocijenjenihVoznji.Columns.Contains("KorisnikId"))
                {
                    int korisnikID = (int)dataGridViewListaNeocijenjenihVoznji.Rows[e.RowIndex].Cells["KorisnikId"].Value;

                    int voznjaId = (int)dataGridViewListaNeocijenjenihVoznji.Rows[e.RowIndex].Cells["VoznjaId"].Value;

                    frmHistorijaVoznjiDetails frm = new frmHistorijaVoznjiDetails(voznjaId, korisnikID);
                    frm.Show();


                    this.Close();
                }
            }
        }
    }
}
