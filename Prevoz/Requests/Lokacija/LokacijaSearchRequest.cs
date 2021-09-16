using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Lokacija
{
    public class LokacijaSearchRequest
    {
        public int LokacijaId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Naziv { get; set; }
        public string PostalCode { get; set; }
    }
}
