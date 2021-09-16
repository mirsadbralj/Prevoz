using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Uplate
{
    public class UplateSearchRequest
    {
        public int KorisnikId { get; set; }

        public DateTime DatumUplate { get; set; }
    }
}
