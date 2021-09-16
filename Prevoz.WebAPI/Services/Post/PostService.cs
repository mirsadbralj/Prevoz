using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests.Post;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Post
{
    public class PostService: BaseCRUDService<Model.Post, PostSearchRequest, Database.Post, PostUpsertRequest, PostUpsertRequest>
    {
        public PostService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Post> Get([FromQuery] PostSearchRequest request)
        {
            var query = _context.Post.AsQueryable();

            if (request?.KorisnikId != 0 )
            {
                query = query.Where(x => x.KorisnikId.Equals(request.KorisnikId));
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Post>>(list);
        }
        public override Model.Post GetById(int Id)
        {
            var entity = _context.Post.Find(Id);

            return _mapper.Map<Model.Post>(entity);
        }
        public override Model.Post Insert(PostUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Post>(request);

            _context.Post.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Post>(entity);
        }
        public override Model.Post Update(int Id, PostUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Post>(request);

            _context.Post.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Post>(entity);
        }
    }
}
