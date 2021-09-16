using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests
{
    public class KorisniciUpsertRequests
    {
        [Required]
        public int KorisnikId { get; set; }
        [Required]
        [MinLength(2)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Slika { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
