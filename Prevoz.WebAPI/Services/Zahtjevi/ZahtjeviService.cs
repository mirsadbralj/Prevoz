using AutoMapper;
using Prevoz.Model.Requests.Zahtjevi;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Zahtjevi
{
    public class ZahtjeviService : BaseCRUDService<Model.Zahtjevi, ZahtjeviSearchRequest, Database.Zahtjevi, ZahtjeviUpsertRequest, ZahtjeviUpsertRequest>
    {
        public ZahtjeviService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Zahtjevi> Get(ZahtjeviSearchRequest search)
        {
            var query = _context.Set<Database.Zahtjevi>().AsQueryable();

            if (search?.VoznjaID != 0)
            {
                query = query.Where(x => x.VoznjaId == search.VoznjaID);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Zahtjevi>>(list);
        }
        public override Model.Zahtjevi Insert(ZahtjeviUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Zahtjevi>(request);
           
            _context.Zahtjevi.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Zahtjevi>(entity);
        }
    }
}
