using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Vožnja
{
    public class VoznjaSearchRequest
    {
        public int VoznjaId { get; set; }
        public int KorisnikId { get; set; }
        public int? StartId{ get; set; }
        public int? EndId{ get; set; }
        public DateTime DatumVoznje { get; set; }
    }
}
