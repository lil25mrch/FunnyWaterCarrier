using System;
using System.Configuration;
using System.Windows;
using FunnyWaterCarrier.DAL.Entities;
using FunnyWaterCarrier.DAL.Factories;
using FunnyWaterCarrier.DAL.Factories.Contracts;
using FunnyWaterCarrier.DAL.Providers;

namespace FunnyWaterCarrier {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            try {
                IDataConnectionFactory dataConnection = new DataConnectionFactory(ConfigurationManager.AppSettings["connectionString"]);
                DbProvider<Employee> dbEmployee = new DbProvider<Employee>(dataConnection);
                DbProvider<Subdivision> dbSubdivision = new DbProvider<Subdivision>(dataConnection);
                DbProvider<Booking> dbBooking = new DbProvider<Booking>(dataConnection);

                //dbSubdivision.UpdateAsync(subdivision => subdivision.Id == 1, subdivision => new Subdivision() {ProductName = subdivision.ProductName + "ee"}).Wait();
                
            } catch (Exception exception) {
                Console.WriteLine(exception);
                throw;
            }

            InitializeComponent();
        }

        private void Employee_Click(object sender, RoutedEventArgs e) {
            EmployeeWindow employeeWindowWindow = new EmployeeWindow();
            employeeWindowWindow.Show();
        }

        private void Booking_Click(object sender, RoutedEventArgs e) {
            BookingWindow bookingWindowWindow = new BookingWindow();
            bookingWindowWindow.Show();
            this.Hide();
        }

        private void Subdivision_Click(object sender, RoutedEventArgs e) {
            SubdivisionInfo subdivisionInfoWindow = new SubdivisionInfo();
            subdivisionInfoWindow.Show();
        }
    }
}