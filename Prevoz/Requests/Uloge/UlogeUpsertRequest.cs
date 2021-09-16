using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.Uloge
{
    public class UlogeUpsertRequest
    {
        [Required]
        [MinLength(2)]
        public string Naziv { get; set; }
        [MinLength(10)]
        public string Opis { get; set; }
    }
}
