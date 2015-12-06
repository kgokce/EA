using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //IReadWriteRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        //isolation level attribute olarak alınabilir
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
    }
}
