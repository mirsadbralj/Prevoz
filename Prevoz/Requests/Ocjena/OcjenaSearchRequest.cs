using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Ocjena
{
    public class OcjenaSearchRequest
    {
        public int KorisnikId { get; set; }
        public int VoznjaId { get; set; }
        public int RezervacijaId { get; set; }
    }
}
