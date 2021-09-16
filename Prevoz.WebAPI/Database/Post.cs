using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Post
    {
        public int PostId { get; set; }
        public int KorisnikId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}
