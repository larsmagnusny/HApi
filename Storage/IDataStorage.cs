using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.Storage
{
    public interface IDataStorage<TEntity>
    {
        void SaveToDisk();
        void Add(TEntity entity);
        TEntity Find(Func<TEntity, bool> predicate);
        bool Contains(TEntity entity);
        HashSet<TEntity> ReadData();
    }
}
