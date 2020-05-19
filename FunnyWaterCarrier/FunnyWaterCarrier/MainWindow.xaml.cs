using System.Windows;
using Ninject;

namespace FunnyWaterCarrier {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Employee_Click(object sender, RoutedEventArgs e) {
            var employeeWindow = App.container.Get<EmployeeWindow>();
            employeeWindow.Show();
            Hide();
        }

        private void Booking_Click(object sender, RoutedEventArgs e) {
            var orderWindow = App.container.Get<OrderWindow>();
            orderWindow.Show();
            Hide();
        }

        private void Subdivision_Click(object sender, RoutedEventArgs e) {
            var subdivisionWindow = App.container.Get<SubdivisionWindow>();
            subdivisionWindow.Show();
            Hide();
        }
    }
}