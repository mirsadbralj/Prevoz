using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests.Poruka;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorukaController : BaseCRUDController<Model.Poruka, PorukaSearchRequest, PorukaUpsertRequest, PorukaUpsertRequest>
    {
        public PorukaController(ICRUDService<Model.Poruka, PorukaSearchRequest, PorukaUpsertRequest, PorukaUpsertRequest> service) : base(service)
        {
        }
    }
}
