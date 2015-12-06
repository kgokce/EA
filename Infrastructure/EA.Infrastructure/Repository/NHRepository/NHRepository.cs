using EA.Infrastructure.Entities;
using EA.Infrastructure.Enumerations;
using EA.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EA.Infrastructure.Repository
{
    public abstract class NHRepository<TEntity, TPrimaryKey> : IReadWriteRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        readonly NHUnitOfWork nhUnitOfWork;

        public NHRepository(NHUnitOfWork nhUnitOfWork)
        {
            this.nhUnitOfWork = nhUnitOfWork;
        }

        public IQueryable<TEntity> All()
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransaction();
            return this.nhUnitOfWork.Session.QueryOver<TEntity>().List().AsQueryable();
        }

        public TEntity FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public TEntity FindBy(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FilterBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public PagedResult<TEntity> GetPage(int pageNumber, int pageSize)
        {
            var query = this.nhUnitOfWork.Session.QueryOver<TEntity>().Where(x => x.Status != StatusType.Deleted).List().AsQueryable();
            return GetPagedResultForQuery(query, pageNumber, pageSize);
        }

        private PagedResult<TEntity> GetPagedResultForQuery(IQueryable<TEntity> query, int pageNumber, int pageSize)
        {
            var result = new PagedResult<TEntity>();
            result.CurrentPage = pageNumber;
            result.PageSize = pageSize;
            result.RowCount = query.Count();
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (pageNumber - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();
            return result;
        }
        public PagedResult<TEntity> GetPageFiltered(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }


        public void Add(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransaction();
            this.nhUnitOfWork.Session.Save(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransaction();
            this.nhUnitOfWork.Session.Save(entities);
        }

        public void Update(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransaction();
            this.nhUnitOfWork.Session.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransaction();
            this.nhUnitOfWork.Session.Update(entities);
        }

        public void Delete(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransaction();
            this.nhUnitOfWork.Session.Delete(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransaction();
            this.nhUnitOfWork.Session.Delete(entities);
        }
    }

}
