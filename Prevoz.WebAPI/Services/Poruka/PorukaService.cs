using AutoMapper;
using Prevoz.Model.Requests.Poruka;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Poruka
{
    public class PorukaService : BaseCRUDService<Model.Poruka, PorukaSearchRequest, Database.Poruka, PorukaUpsertRequest, PorukaUpsertRequest>
    {
        public PorukaService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Poruka> Get(PorukaSearchRequest search)
        {
            var query = _context.Set<Database.Poruka>().AsQueryable();

            if (search?.PosiljaocID != 0)
            {
                query = query.Where(x => (x.PosiljaocId == search.PosiljaocID && x.PrimaocId == search.PrimaocID)|| (x.PosiljaocId==search.PrimaocID && x.PrimaocId==search.PosiljaocID));
            }
            query = query.OrderBy(x => x.DatumVrijeme);
            var list = query.ToList();

            return _mapper.Map<List<Model.Poruka>>(list);
        }
    }
}
