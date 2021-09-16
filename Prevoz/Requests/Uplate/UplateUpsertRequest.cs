using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Uplate
{
    public class UplateUpsertRequest
    {
        public int KorisnikId { get; set; }
        public decimal Iznos { get; set; }
        public DateTime DatumUplate { get; set; }
    }
}
