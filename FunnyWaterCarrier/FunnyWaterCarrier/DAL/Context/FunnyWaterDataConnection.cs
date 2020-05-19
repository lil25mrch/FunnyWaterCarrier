using System;
using System.Linq;
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

        public int InsertWithInt32Identity<TSource>(TSource source) where TSource : class {
            return DataExtensions.InsertWithInt32Identity(this, source);
        }

        public int Update<TSource>(TSource source) where TSource : class {
            return DataExtensions.Update(this, source);
        }
    }
}