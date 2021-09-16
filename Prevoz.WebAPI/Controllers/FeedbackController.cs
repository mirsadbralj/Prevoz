using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests.Feedback;
using Prevoz.WebAPI.Database;
using Prevoz.WebAPI.Services;
using Prevoz.WebAPI.Services.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : BaseCRUDController<Model.Feedback, FeedbackSearchRequest, FeedbackUpsertRequest, FeedbackUpsertRequest>
    {
        public FeedbackController(ICRUDService<Model.Feedback, FeedbackSearchRequest, FeedbackUpsertRequest, FeedbackUpsertRequest> service) : base(service)
        {
        }


    }
}
