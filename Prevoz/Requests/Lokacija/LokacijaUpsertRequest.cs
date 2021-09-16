using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.Lokacija
{
    public class LokacijaUpsertRequest
    { 
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Naziv { get; set; }
        public string PostalCode { get; set; }
    }
}
