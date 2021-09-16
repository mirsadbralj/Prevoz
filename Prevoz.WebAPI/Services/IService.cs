using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services
{
    public interface IService<T, Tsearch>
    {
        List<T> Get(Tsearch search);

        T GetById(int id);

    }
}
