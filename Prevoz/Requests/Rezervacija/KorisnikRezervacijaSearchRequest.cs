using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Rezervacija
{
    public class KorisnikRezervacijaSearchRequest
    {
        public int KorisnikId { get; set; }
        public int VoznjaId { get; set; }
    }
}
