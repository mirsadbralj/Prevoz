using Prevoz.Model.Requests.Uloge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI.Admin
{
    public partial class frmUpraviteljUloga : Form
    {
        ApiService _korisnik = new ApiService("korisnik");
        ApiService _uloga = new ApiService("uloge");
        ApiService _KorisnikUloga = new ApiService("korisnikuloge");

        List<Model.KorisnikUloge> listaUloga = new List<Model.KorisnikUloge>();
        public frmUpraviteljUloga()
        {
            InitializeComponent();
        }

        private async void frmUpraviteljUloga_Load(object sender, EventArgs e)
        {
            var _korisnici = await _korisnik.Get<List<Model.Korisnik>>(null);

            var _uloge = await _uloga.Get<List<Model.Uloge>>(null);
            var _korisnikuloge = await _KorisnikUloga.Get<List<Model.KorisnikUloge>>(null);

            listaUloga = _korisnikuloge;
            List<Model.KorisnikUloge> listKorisnikUloge = new List<Model.KorisnikUloge>();
            List<Model.Korisnik> listKorisnici = new List<Model.Korisnik>();

            for (int i = 0; i < _korisnici.Count(); i++)
            {
                for (int j = 0; j < _korisnikuloge.Count(); j++)
                {
                    if (_korisnici[i].KorisnikId == _korisnikuloge[j].KorisnikId &&
                        Memorija.Korisnik.KorisnikId != _korisnici[i].KorisnikId  &&
                        _korisnikuloge[j].UlogaId == 1)
                        listKorisnikUloge.Add(_korisnikuloge[j]);
                }
            }
            for (int i = 0; i < listKorisnikUloge.Count(); i++)
            {
                int Id = listKorisnikUloge[i].UlogaId;
                Model.Uloge person = await _uloga.GetById<Model.Uloge>(Id);
                string admin = person.Naziv;

                if (admin.Equals("admin/editor"))
                    listKorisnici.Add(await _korisnik.GetById<Model.Korisnik>(listKorisnikUloge[i].KorisnikId));
            }
            dgvUpraviteljUloga.DataSource = listKorisnici;
            dgvUpraviteljUloga.Columns[1].Visible = false;
            dgvUpraviteljUloga.Columns[3].Visible = false;
            dgvUpraviteljUloga.Columns[4].Visible = false;
            dgvUpraviteljUloga.Columns[5].Visible = false;

            dgvUpraviteljUloga.Columns["btnPostaviAdmin"].DisplayIndex = 8;
            dgvUpraviteljUloga.Columns["btnPostaviAdmin"].Width = 200;
            dgvUpraviteljUloga.Columns["btnRemoveRole"].DisplayIndex = 7;
        }
        private async void SetHeadAdminRole(int korisnikId)
        {
            var request = new KorisnikUlogeUpsertRequest()
            {
                KorisnikId = korisnikId,
                UlogaId = 3
            };
            for (int i = 0; i < listaUloga.Count(); i++)
            {
                if (listaUloga[i].KorisnikId == korisnikId)
                    await _KorisnikUloga.Update<Model.KorisnikUloge>(listaUloga[i].KorisnikUlogaId, request);
            }
        }
        private async void RemoveRoles(int korisnikId)
        {
            int korisnikUlogaId = -1;
            for (int i = 0; i < listaUloga.Count(); i++)
            {
                if (listaUloga[i].KorisnikId == korisnikId)
                    korisnikUlogaId = listaUloga[i].KorisnikUlogaId;
            }
            await _KorisnikUloga.Delete<Model.KorisnikUloge>(korisnikUlogaId);
        }
        private void dgvUpraviteljUloga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==dgvUpraviteljUloga.Columns["btnPostaviAdmin"].Index && e.RowIndex >= 0)
            {
                int KorisnikId = (int)dgvUpraviteljUloga.Rows[e.RowIndex].Cells["KorisnikId"].Value;
                SetHeadAdminRole(KorisnikId);
            }
            else if(e.ColumnIndex == dgvUpraviteljUloga.Columns["btnRemoveRole"].Index && e.RowIndex >= 0)
            {
                int KorisnikId = (int)dgvUpraviteljUloga.Rows[e.RowIndex].Cells["KorisnikId"].Value;
                RemoveRoles(KorisnikId);
            }
        }
    }
}
