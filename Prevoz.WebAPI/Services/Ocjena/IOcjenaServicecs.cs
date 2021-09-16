using Prevoz.Model.Requests.Ocjena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Ocjena
{
    public interface IOcjenaServicecs
    {
        List<Model.Ocjena> Get();

        Model.Ocjena GetById();

        Model.Ocjena Insert(OcjenaSearchRequest request);

        Model.Ocjena Delete(int id);
    }
}
