using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Post
{
    public interface IPostService
    {
        public List<Model.Post> Get([FromQuery] PostSearchRequest request);
        public Model.Post GetById(int Id);
        public Model.Post Insert(PostSearchRequest request);
        public Model.Post Update(int Id, PostSearchRequest request);
    }
}
