using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model
{
    public class Lokacija
    {
        public int LokacijaId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Naziv { get; set; }
        public string PostalCode { get; set; }

    }
}
