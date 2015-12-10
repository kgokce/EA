using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Infrastructure.UnitOfWork
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private ISession session;
        private ITransaction transaction;
        public ISession Session { get { return this.session; } }
        private readonly ISessionFactory sessionFactory;

        public NHUnitOfWork(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public void OpenSession()
        {
            if (this.session == null || !this.session.IsConnected)
            {
                if (this.session != null)
                    this.session.Dispose();

                this.session = sessionFactory.OpenSession();
            }
        }
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (this.transaction != null)
                this.transaction.Dispose();
            if (this.transaction == null || !this.transaction.IsActive)
            {
                this.transaction = this.session.BeginTransaction(isolationLevel);
            }
        }

        public void Commit()
        {
            try
            {
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

            if (this.session != null)
            {
                this.session.Dispose();
                session = null;
            }
        }
    }

}
