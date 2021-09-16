using Prevoz.Model;
using Prevoz.Model.Requests.Uplate;
using System.Collections.Generic;

namespace Prevoz.Model
{
    public interface IUplateService
    {
        List <Model.Uplate> Get(UplateSearchRequest request);
        Model.Uplate GetById(int id);
        Model.Uplate Insert(UplateUpsertRequest request);
    }
}