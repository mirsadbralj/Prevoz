using Prevoz.Model.Requests.Uloge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Uloge
{
    public interface IUlogeService
    {
        public List<Model.Uloge> Get(UlogeSearchRequest request);
        public Model.Uloge GetById(int Id);
        public Model.Uloge Insert(UlogeUpsertRequest request);
    }
}
