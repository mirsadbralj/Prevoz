using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Zahtjevi
{
    public class ZahtjeviUpsertRequest
    {
        public int KorisnikID { get; set; }
        public int VoznjaID { get; set; }
        public DateTime Datum { get; set; }
        public string Status { get; set; }
    }
}
