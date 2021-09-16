using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.Vožnja
{
    public class VoznjaUpsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        [Required]
        public int StartId { get; set; }
        [Required]
        public int EndId { get; set; }
        public int? VoziloId { get; set; }
        [Required]
        public decimal? CijenaSjedista { get; set; }
        [Required]
        public int? BrojSjedista { get; set; }
        [Required]
        public bool? Status { get; set; }
        public string AutomatskoOdobrenje { get; set; }
        public string Cigarete { get; set; }
        public string Detaljnije { get; set; }
        public string KucniLjubimci { get; set; }
        [Required]
        public DateTime DatumVoznje { get; set; }

    }
}
