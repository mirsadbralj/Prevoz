using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.Korisnik
{
    public class KorisnikDetailSearchRequest
    {
        public int KorisnikId { get; set; }
        [MinLength(2)]
        public string Ime { get; set; }
        [MinLength(2)]
        public string Prezime { get; set; }
    }
}
