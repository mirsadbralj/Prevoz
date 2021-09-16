using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.WebAPI.Services;
using Prevoz.WebAPI.Services.Lokacija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LokacijaController : BaseCRUDController<Model.Lokacija, LokacijaSearchRequest, LokacijaUpsertRequest, LokacijaUpsertRequest>
    {
        public LokacijaController(ICRUDService<Lokacija, LokacijaSearchRequest, LokacijaUpsertRequest, LokacijaUpsertRequest> service) : base(service)
        {


        }
    }
}
