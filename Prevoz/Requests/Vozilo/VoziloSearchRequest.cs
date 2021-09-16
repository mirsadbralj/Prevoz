using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.Vozilo
{
    public class VoziloSearchRequest
    {
        public int KorisnikId { get; set; }
        public string MarkaVozila { get; set; }
        public string Boja { get; set; }
    }
}
