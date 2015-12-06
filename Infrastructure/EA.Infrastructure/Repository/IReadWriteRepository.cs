using EA.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Infrastructure.Repository
{
    public interface IReadWriteRepository<TEntity, TPrimaryKey> : IReadRepository<TEntity, TPrimaryKey>,IWriteRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
    }
}
