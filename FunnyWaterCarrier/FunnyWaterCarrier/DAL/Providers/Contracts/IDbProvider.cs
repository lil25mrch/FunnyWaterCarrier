using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FunnyWaterCarrier.DAL.Providers.Contracts {
    internal interface IDbProvider<TEntity> {
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> UpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> mutator);

        Task<int> InsertAsync(TEntity entity);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}