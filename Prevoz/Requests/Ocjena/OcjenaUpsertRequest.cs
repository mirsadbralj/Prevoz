using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.Ocjena
{
    public class OcjenaUpsertRequest
    {
        public int? VoznjaId { get; set; }
        [Required]
        public int KorisnikId { get; set; }
        public int? RezervacijaId { get; set; }
        [Required]
        public int Ocjena1 { get; set; }
        [MinLength(5)]
        public string Komentar { get; set; }
    }
}
