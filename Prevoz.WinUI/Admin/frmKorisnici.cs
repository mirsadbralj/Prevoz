using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Uloge;
using Prevoz.Model;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmKorisnici : Form
    {

        private readonly ApiService _korisnici = new ApiService("korisnik");
        private readonly ApiService _KorisnikUloge = new ApiService("korisnikuloge");
        public frmKorisnici()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new KorisniciSearchRequest()
            {
                UserName = txtPretraga.Text 
            };
            var result = await _korisnici.Get<List<Model.Korisnik>>(search);
            result = result.Where(x => x.KorisnikId != Memorija.Korisnik.KorisnikId).ToList();

            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = result;
        }
        private void dgvKorisnici_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;
            frmKorisniciDetail frm = new frmKorisniciDetail(int.Parse(id.ToString()));
            frm.Show();
        }
        private async void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvKorisnici.Columns["btnAddAdmin"].Index && e.RowIndex >= 0)
            {
                int KorisnikID = (int)dgvKorisnici.Rows[e.RowIndex].Cells["KorisnikID"].Value;

                var korisnik = await _korisnici.GetById<Model.Korisnik>(KorisnikID);

                var KorisnikUlogaRequest = new KorisnikUlogeUpsertRequest()
                {
                    KorisnikId=KorisnikID,
                    UlogaId = 1
                };

                var Ulogakorisnika = await _KorisnikUloge.Get<List<Model.KorisnikUloge>>(null);

                KorisnikUloge kU = null;
                kU = Ulogakorisnika.Where(x => x.KorisnikId == KorisnikID).First();

                if (kU.KorisnikId <= 0 || kU==null)
                    await _KorisnikUloge.Insert<Model.KorisnikUloge>(KorisnikUlogaRequest);
                else
                  await _KorisnikUloge.Update<Model.KorisnikUloge>(KorisnikID, KorisnikUlogaRequest);
            }
        }
    }
}
