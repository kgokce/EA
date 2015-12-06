using EA.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EA.Infrastructure.Repository
{
    public interface IReadRepository<TEntity,TPrimaryKey> where TEntity : class
    {
        IQueryable<TEntity> All();
        TEntity FindBy(Expression<Func<TEntity, bool>> expression);
        TEntity FindBy(object id);
        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
        PagedResult<TEntity> GetPage(int pageNumber, int pageSize);
        PagedResult<TEntity> GetPageFiltered(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> expression);
    }
}
