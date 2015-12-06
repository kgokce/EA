using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Infrastructure.Repository
{
    public interface IWriteRepository<TEntity,TPrimaryKey> where TEntity : class
    {
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
    }
}
