using System.Collections.Generic;

namespace FunnyWaterCarrier.DAL.Providers.Contracts {
    public interface IDbProvider<TEntity> {
        List<TEntity> GetAll();

        int Update(TEntity entity);

        int Insert(TEntity entity);
    }
}