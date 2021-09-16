using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Uloge
{
    public class UlogeSearchRequest
    {
        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}
