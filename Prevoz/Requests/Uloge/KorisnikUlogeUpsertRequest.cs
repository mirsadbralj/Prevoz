using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.Uloge
{
    public class KorisnikUlogeUpsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        [Required]
        public int UlogaId { get; set; }
    }
}
