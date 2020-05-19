using System.Windows;
using FunnyWaterCarrier.DAL.Entities;
using FunnyWaterCarrier.Options;
using Ninject;

namespace FunnyWaterCarrier {
    public partial class SubdivisionWindow : Window {
        public SubdivisionWindow(ApplicationView<Subdivision> applicationView) {
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