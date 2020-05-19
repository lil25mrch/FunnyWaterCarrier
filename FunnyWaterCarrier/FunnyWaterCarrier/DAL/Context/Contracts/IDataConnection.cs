using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyWaterCarrier.DAL.Context.Contracts {
    internal interface IDataConnection : IDisposable {
        IQueryable<TSource> From<TSource>() where TSource : class;

        int InsertWithInt32Identity<TSource>(TSource source) where TSource : class;
        int Update<TSource>(TSource source) where TSource : class;
    }
}