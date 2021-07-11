using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.DataAccess
{
    public interface IHContext
    {
        void DetachAllEntities();
    }
}
