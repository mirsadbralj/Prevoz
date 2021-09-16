using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model
{
    public partial class KorisnikDetails
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? Lokacija { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime? DatumRođenja { get; set; }
    }
}
