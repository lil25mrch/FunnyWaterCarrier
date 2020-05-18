using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using FunnyWaterCarrier.DAL.Entities;
using FunnyWaterCarrier.DAL.Factories;
using FunnyWaterCarrier.DAL.Factories.Contracts;
using FunnyWaterCarrier.DAL.Providers;

namespace FunnyWaterCarrier.Options {
    public class ApplicationView : INotifyPropertyChanged {
        static readonly IDataConnectionFactory dataConnection = new DataConnectionFactory(ConfigurationManager.AppSettings["connectionString"]);
        
        private Booking selectedTable;
        
        public ApplicationView() {
            Orders = new ObservableCollection<Booking> {
             
                new Booking {ProductName = "Газированная вода", EmployeeId = 1},
                new Booking {ProductName = "Негазированная вода", EmployeeId = 1},
                new Booking {ProductName = "Вода", EmployeeId = 2},
                new Booking {ProductName = "Сок", EmployeeId = 2},
                new Booking {ProductName = "Йогурт", EmployeeId = 4},
                new Booking {ProductName = "Хлеб", EmployeeId = 4},
            };
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj =>
                       {
                           Booking order = new Booking(){ProductName = "Новый товар", EmployeeId = 0};
                           Orders.Insert(0, order);
                           selectedTable = order;
                       }));
            }
        }
        public ObservableCollection<Booking> Orders { get; set; }

        public Booking SelectedTable {
            get { return selectedTable; }
            set {
                selectedTable = value;
                OnPropertyChanged("SelectedTable");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}