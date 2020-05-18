using FunnyWaterCarrier.DAL.Context;
using FunnyWaterCarrier.DAL.Context.Contracts;
using FunnyWaterCarrier.DAL.Factories.Contracts;

namespace FunnyWaterCarrier.DAL.Factories {
    /// <summary>
    /// Фабрика подключений к данным
    /// </summary>
    internal class DataConnectionFactory : IDataConnectionFactory {
        private readonly string _connectionString;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectionString">конфиг</param>
        public DataConnectionFactory(string connectionString) {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Создает подключение к данным
        /// </summary>
        /// <returns>подключение к данным</returns>
        public IDataConnection Create() {
            return new FunnyWaterDataConnection(_connectionString);
        }
    }
}