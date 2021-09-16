using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Uloge
{
    public class KorisnikUlogeSearchRequest
    {
        public int KorisnikUlogaId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
    }
}
