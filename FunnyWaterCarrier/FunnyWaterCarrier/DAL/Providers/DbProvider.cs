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


        public List<TEntity> GetAll() {
            using (IDataConnection connection = _connectionFactory.Create()) {
                return connection.From<TEntity>().ToList();
            }
        }
        
        public int Update(TEntity entity) {
            using (IDataConnection connection = _connectionFactory.Create()) {
                int count = connection.Update(entity);
                return count;
            }
        }

        public int Insert(TEntity entity) {
            using (IDataConnection connection = _connectionFactory.Create()) {
                int id = connection.InsertWithInt32Identity(entity);
                return id;
            }
        }
    }
}