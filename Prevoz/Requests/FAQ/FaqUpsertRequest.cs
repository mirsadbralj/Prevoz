using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.FAQ
{
    public class FaqUpsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        [MinLength(10)]
        public string Pitanje { get; set; }
        public string Odgovor { get; set; }
    }
}
