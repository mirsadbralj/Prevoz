using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests.FAQ;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : BaseCRUDController<Model.Faq,FaqSearchRequest,FaqUpsertRequest,FaqUpsertRequest>
    {
        public FAQController(ICRUDService<Faq, FaqSearchRequest, FaqUpsertRequest, FaqUpsertRequest> service) : base(service)
        {
        }
    }
}
