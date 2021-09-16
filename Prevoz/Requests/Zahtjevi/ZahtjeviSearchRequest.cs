using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Zahtjevi
{
    public class ZahtjeviSearchRequest
    {
        public int ZahtjevID { get; set; }
        public int KorisnikID { get; set; }
        public int VoznjaID { get; set; }
    }
}
