using EA.Infrastructure.Entities;
using EA.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EA.Infrastructure.Repository.EFRepository
{
    public class EFRepository<TEntity, TPrimaryKey> : IReadWriteRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        readonly EFUnitOfWork unitOfWork;

        public EFRepository(EFUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

      

        public IQueryable<TEntity> All()
        {
            return this.unitOfWork.Context.Set<TEntity>().ToList().AsQueryable();
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
            throw new NotImplementedException();
        }

        public PagedResult<TEntity> GetPageFiltered(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            this.unitOfWork.BeginTransaction();
            this.unitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {

            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            this.unitOfWork.BeginTransaction();
            this.unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }

}
