using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.Rezervacija
{
    public class KorisnikRezervacijaUpsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        [Required]
        public int VoznjaId { get; set; }
        public int? KreditnaKarticaId { get; set; }
        [Required]
        public int? BrojSjedista { get; set; }
        public decimal? UkupnoPlaceno { get; set; }
        [Required]
        public DateTime DatumRezervacije { get; set; }
    }
}
