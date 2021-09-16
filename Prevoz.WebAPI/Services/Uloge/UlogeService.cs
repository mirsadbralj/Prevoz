using AutoMapper;
using Prevoz.Model.Requests.Uloge;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Uloge
{
    public class UlogeService:BaseCRUDService<Model.Uloge, UlogeSearchRequest, Database.Uloge, UlogeUpsertRequest, UlogeUpsertRequest>
    {
        public UlogeService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Uloge> Get(UlogeSearchRequest request)
        {
            var query = _context.Uloge.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(x => x.UlogaId.Equals(request.UlogaId));
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Uloge>>(list);
        }
        public override Model.Uloge GetById(int Id)
        {
            var entity = _context.Uloge.Find(Id);

            return _mapper.Map<Model.Uloge>(entity);
        }

        public override Model.Uloge Insert(UlogeUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Uloge>(request);

            _context.Uloge.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Uloge>(entity);
        }
    }
}
