using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests.Uloge;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UlogeController : BaseCRUDController<Model.Uloge, UlogeSearchRequest, UlogeUpsertRequest, UlogeUpsertRequest>
    {
        public UlogeController(ICRUDService<Uloge, UlogeSearchRequest, UlogeUpsertRequest, UlogeUpsertRequest> service) : base(service)
        {
        }

    }
}
