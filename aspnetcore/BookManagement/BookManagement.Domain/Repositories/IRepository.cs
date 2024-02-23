using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Repositories
{
    public interface IRepository
    {

    }
    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        #region Select/Get/Query
        IQueryable<TEntity> GetAll();

        #endregion

        #region Insert

        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);

        #endregion

        #region Update
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        #endregion

        #region Delete
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);

        #endregion
    }
}
