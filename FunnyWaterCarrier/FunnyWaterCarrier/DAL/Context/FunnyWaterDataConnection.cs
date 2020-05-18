using System;
using System.Linq;
using System.Threading.Tasks;
using FunnyWaterCarrier.DAL.Context.Contracts;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.MySql;

namespace FunnyWaterCarrier.DAL.Context {
    internal class FunnyWaterDataConnection : DataConnection, IDataConnection {
        public FunnyWaterDataConnection(string connectionString)
            : base(new MySqlDataProvider(), connectionString) {
            TurnTraceSwitchOn();
            WriteTraceLine = (message, displayName) => { Console.WriteLine($"{message} {displayName}"); };
        }

        public IQueryable<TSource> From<TSource>() where TSource : class {
            return GetTable<TSource>();
        }

        public async Task<int> InsertWithInt32IdentityAsync<TSource>(TSource source) where TSource : class {
            return await DataExtensions.InsertWithInt32IdentityAsync(this, source);
        }
    }
}