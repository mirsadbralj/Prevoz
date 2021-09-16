using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests.Zahtjevi;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZahtjeviController : BaseCRUDController<Model.Zahtjevi, ZahtjeviSearchRequest, ZahtjeviUpsertRequest, ZahtjeviUpsertRequest>
    {
        public ZahtjeviController(ICRUDService<Model.Zahtjevi, ZahtjeviSearchRequest, ZahtjeviUpsertRequest, ZahtjeviUpsertRequest> service) : base(service)
        {
        }
    }
}
