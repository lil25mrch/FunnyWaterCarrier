using System.Windows;
using FunnyWaterCarrier.DAL.Entities;
using FunnyWaterCarrier.Options;
using Ninject;

namespace FunnyWaterCarrier {
    public partial class EmployeeWindow : Window {
        public EmployeeWindow(ApplicationView<Employee> applicationView) {
            InitializeComponent();
            DataContext = applicationView;
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            var orderWindow = App.container.Get<MainWindow>();
            orderWindow.Show();
            Hide();
        }
    }
}