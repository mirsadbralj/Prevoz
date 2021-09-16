using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model
{
        public partial class Korisnik
        {        
            public int KorisnikId { get; set; }
            public string UserName { get; set; }
            public byte[] Slika { get; set; } 
            public string PasswordSalt { get; set; }
            public string PasswordHash { get; set; }
            public DateTime? CreatedAt { get; set; }
            public DateTime? ModifiedAt { get; set; }
        }
}
