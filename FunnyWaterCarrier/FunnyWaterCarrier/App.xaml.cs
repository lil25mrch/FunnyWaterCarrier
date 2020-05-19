using System.Configuration;
using System.Windows;
using FunnyWaterCarrier.DAL.Entities;
using FunnyWaterCarrier.DAL.Factories;
using FunnyWaterCarrier.DAL.Factories.Contracts;
using FunnyWaterCarrier.DAL.Providers;
using FunnyWaterCarrier.DAL.Providers.Contracts;
using FunnyWaterCarrier.Options;
using Ninject;

namespace FunnyWaterCarrier {
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application {
        public static IKernel container;

        protected override void OnStartup(StartupEventArgs e) {
            ConfigureContainer();
            var window = container.Get<MainWindow>();
            window.Show();
        }

        private void ConfigureContainer() {
            container = new StandardKernel();
            container.Bind<IDataConnectionFactory>().ToMethod(e => new DataConnectionFactory(ConfigurationManager.AppSettings["connectionString"]));
            container.Bind<IDbProvider<Order>>().To<DbProvider<Order>>().InSingletonScope();
            container.Bind<IDbProvider<Employee>>().To<DbProvider<Employee>>().InSingletonScope();
            container.Bind<IDbProvider<Subdivision>>().To<DbProvider<Subdivision>>().InSingletonScope();
            container.Bind<ApplicationView<Order>>().ToSelf().InSingletonScope();
            container.Bind<ApplicationView<Employee>>().ToSelf().InSingletonScope();
            container.Bind<ApplicationView<Subdivision>>().ToSelf().InSingletonScope();
            container.Bind<MainWindow>().ToSelf().InSingletonScope();
            container.Bind<OrderWindow>().ToSelf().InSingletonScope();
            container.Bind<EmployeeWindow>().ToSelf().InSingletonScope();
            container.Bind<SubdivisionWindow>().ToSelf().InSingletonScope();
        }
    }
}