using Prevoz.Model.Requests.Poruka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Poruka
{
    public interface IPorukaService
    {
        List<Model.Poruka> Get(PorukaSearchRequest request);
        Model.Poruka GetById(int Id);
        Model.Poruka Insert(PorukaUpsertRequest request);
    }
}
