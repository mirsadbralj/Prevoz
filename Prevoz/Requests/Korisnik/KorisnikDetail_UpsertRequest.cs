using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests
{
    public class KorisnikDetail_UpsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        [MinLength(2)]
        public string Ime { get; set; }
        [MinLength(2)]
        public string Prezime { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int? Lokacija { get; set; }

        public string Telefon { get; set; }
        public DateTime? DatumRođenja { get; set; }
    }
}
