using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Faqs = new HashSet<Faq>();
            Feedbacks = new HashSet<Feedback>();
            KorisnikRezervacijas = new HashSet<KorisnikRezervacija>();
            KorisnikUlogas = new HashSet<KorisnikUloga>();
            Ocjenas = new HashSet<Ocjena>();
            PorukaPosiljaocs = new HashSet<Poruka>();
            PorukaPrimaocs = new HashSet<Poruka>();
            Posts = new HashSet<Post>();
            Uplates = new HashSet<Uplate>();
            Vozilos = new HashSet<Vozilo>();
            Voznjas = new HashSet<Voznja>();
            Zahtjevis = new HashSet<Zahtjevi>();
        }

        public int KorisnikId { get; set; }
        public string UserName { get; set; }
        public byte[] Slika { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public virtual KorisnikDetails KorisnikDetail { get; set; }
        public virtual ICollection<Faq> Faqs { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<KorisnikRezervacija> KorisnikRezervacijas { get; set; }
        public virtual ICollection<KorisnikUloga> KorisnikUlogas { get; set; }
        public virtual ICollection<Ocjena> Ocjenas { get; set; }
        public virtual ICollection<Poruka> PorukaPosiljaocs { get; set; }
        public virtual ICollection<Poruka> PorukaPrimaocs { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Uplate> Uplates { get; set; }
        public virtual ICollection<Vozilo> Vozilos { get; set; }
        public virtual ICollection<Voznja> Voznjas { get; set; }
        public virtual ICollection<Zahtjevi> Zahtjevis { get; set; }
    }
}
