using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests.Uplate;
using Prevoz.WebAPI.Services;
using System.Collections.Generic;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UplateController : BaseCRUDController<Model.Uplate, UplateSearchRequest, UplateUpsertRequest, UplateUpsertRequest>
    {
        public UplateController(ICRUDService<Uplate, UplateSearchRequest, UplateUpsertRequest, UplateUpsertRequest> service) : base(service)
        {
        }
    }
}