using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests.Lokacija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Lokacija
{
    public interface ILokacijaService
    {
        List<Model.Lokacija> Get(LokacijaSearchRequest request);
        Model.Lokacija GetById(int Id);
        Model.Lokacija Insert(LokacijaUpsertRequest request);
    }
}
