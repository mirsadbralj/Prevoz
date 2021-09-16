using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests.Post;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseCRUDController<Model.Post, PostSearchRequest, PostUpsertRequest, PostUpsertRequest>
    {
        public PostController(ICRUDService<Post, PostSearchRequest, PostUpsertRequest, PostUpsertRequest> service) : base(service)
        {
        }
    }
}
