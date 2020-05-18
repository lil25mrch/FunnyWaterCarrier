using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FunnyWaterCarrier.DAL.Context.Contracts;
using FunnyWaterCarrier.DAL.Factories.Contracts;
using FunnyWaterCarrier.DAL.Providers.Contracts;
using LinqToDB;

namespace FunnyWaterCarrier.DAL.Providers {
    internal class DbProvider<TEntity> : IDbProvider<TEntity> where TEntity : class {
        private readonly IDataConnectionFactory _connectionFactory;

        public DbProvider(IDataConnectionFactory connectionFactory) {
            _connectionFactory = connectionFactory;
        }


        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate) {
            using (IDataConnection connection = _connectionFactory.Create()) {
                return await connection.From<TEntity>().Where(predicate).ToListAsync();
            }
        }
        
        public async Task<int> UpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> mutator) {
            using (IDataConnection connection = _connectionFactory.Create()) {
                int count = await connection.From<TEntity>().Where(predicate).UpdateAsync(mutator);
                return count;
            }
        }

        public async Task<int> InsertAsync(TEntity entity) {
            using (IDataConnection connection = _connectionFactory.Create()) {
                int id = await connection.InsertWithInt32IdentityAsync(entity);
                return id;
            }
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) {
            using (IDataConnection connection = _connectionFactory.Create()) {
                return await connection.From<TEntity>().Where(predicate).SingleOrDefaultAsync();
            }
        }
    }
}