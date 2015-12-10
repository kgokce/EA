using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Infrastructure.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        DbContext context;
        DbContextTransaction transaction;
        public DbContext Context { get { return this.context; } }


        public EFUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (this.transaction != null)
                this.transaction.Dispose();

            if (this.transaction == null)               
                this.transaction = this.context.Database.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            try
            {
                this.context.SaveChanges();
                this.transaction.Commit();
            }
            catch
            {
                this.transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            this.transaction.Rollback();
        }

        public void Dispose()
        {
            if (this.transaction != null)
            {
                this.transaction.Dispose();
                this.transaction = null;
            }

            if (this.context != null)
            {
                this.context.Database.Connection.Close();
                this.context.Dispose();
                this.context = null;
            }
        }
    }

}
