using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyWaterCarrier.DAL.Context.Contracts {
    internal interface IDataConnection : IDisposable {
        IQueryable<TSource> From<TSource>() where TSource : class;

        Task<int> InsertWithInt32IdentityAsync<TSource>(TSource source) where TSource : class;
    }
}