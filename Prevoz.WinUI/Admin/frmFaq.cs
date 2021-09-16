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
    public partial class frmFaq : Form
    {
        ApiService _faq = new ApiService("faq");
        public frmFaq()
        {
            InitializeComponent();
        }

        private async void frmFaq_Load(object sender, EventArgs e)
        {
            var listFaq = await _faq.Get<List<Model.Faq>>(null);

            List<Model.Faq> _listFaq = new List<Model.Faq>();

            _listFaq = listFaq.Where(x => x.Odgovor == null).ToList();
           
            dgvFaq.DataSource = _listFaq;

            dgvFaq.Columns["FaqId"].Visible = false;
            dgvFaq.Columns["Odgovori"].DisplayIndex = 4;
        }

        private void dgvFaq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvFaq.Columns["Odgovori"].Index==e.ColumnIndex && e.RowIndex >= 0)
            {
                string tekstPitanja = dgvFaq.Rows[e.RowIndex].Cells["Pitanje"].Value.ToString();
                int FaqId = (int)dgvFaq.Rows[e.RowIndex].Cells["FaqId"].Value;
                frmOdgovorAdd frm = new frmOdgovorAdd(tekstPitanja, FaqId);
                frm.Show();
            }
        }
    }
}
