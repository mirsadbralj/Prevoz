using AutoMapper;
using Prevoz.Model.Requests.Feedback;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Feedback
{
    public class FeedbackService : BaseCRUDService<Model.Feedback, FeedbackSearchRequest, Database.Feedback, FeedbackUpsertRequest,FeedbackUpsertRequest >
    {
        public FeedbackService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Feedback> Get(FeedbackSearchRequest search)
        {
            var query = _context.Set<Database.Feedback>().AsQueryable();

            if(search?.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Feedback>>(list);
        }
        public override Model.Feedback GetById(int Id)
        {
            var entity = _context.Feedback.Find(Id);

            return _mapper.Map<Model.Feedback>(entity);
        }
        public override Model.Feedback Insert(FeedbackUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Feedback>(request);

            _context.Feedback.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Feedback>(entity);
        }

        public override Model.Feedback Delete(int Id)
        {
            var entity = _context.Feedback.Find(Id);
            _context.Feedback.Remove(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Feedback>(entity);
        }
    }
}
