using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests
{
    public class VoziloUpsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        public string MarkaVozila { get; set; }
        public string Boja { get; set; }

        public byte[] Slika { get; set; }
        public string Naziv { get; set; }
    }
}
