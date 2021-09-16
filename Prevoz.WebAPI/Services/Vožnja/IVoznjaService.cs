using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model.Requests.Vožnja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Vožnja
{
    public interface IVoznjaService
    {
        List<Model.Voznja> Get();

        Model.Voznja GetById(int Id);
        Model.Voznja FilterByStartId(int Id);
        List<Model.Voznja> Get(VoznjaSearchRequest request);
        Model.Voznja Insert(VoznjaUpsertRequest request);
    }
}
