using System.ComponentModel;
using System.Runtime.CompilerServices;
using LinqToDB.Mapping;

namespace FunnyWaterCarrier.DAL.Entities {
    [Table(Name = "booking")]
    public class Booking : INotifyPropertyChanged {
        [Column("Id")]
        [Identity]
        [PrimaryKey]
        private int id;
        
        public int Id {
            get { return id; }
            set {
                id = value;
                OnPropertyChanged();
            }
        }

        [Column(Name = "ProductName", CanBeNull = false)]
        private string productName;
        public string ProductName {
            get { return productName; }
            set {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        [Column(Name = "EmployeeId", CanBeNull = false)]
        private int employeeId;
        public int EmployeeId {
            get { return employeeId; }
            set {
                employeeId = value;
                OnPropertyChanged("EmployeeId");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}