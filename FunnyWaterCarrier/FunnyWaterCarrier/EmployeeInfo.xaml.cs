using System.Windows;
using System.Windows.Controls;
using FunnyWaterCarrier.Options;

namespace FunnyWaterCarrier {
    public partial class EmployeeWindow : Window {
        public EmployeeWindow() {
            InitializeComponent();
            DataContext = new ApplicationView();
        }

        private void AddInfo_Click(object sender, RoutedEventArgs e) { }

        private void Clean_Click(object sender, RoutedEventArgs e) { }

        private void Back_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ComboBox_Selected(object sender, SelectionChangedEventArgs e) { }
    }
}