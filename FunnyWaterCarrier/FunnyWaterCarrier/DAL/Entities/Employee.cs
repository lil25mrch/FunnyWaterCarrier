using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FunnyWaterCarrier.Enums;
using LinqToDB.Mapping;

namespace FunnyWaterCarrier.DAL.Entities {
    [Table(Name = "employee")]
    
    internal class Employee : INotifyPropertyChanged{
        [Column("Id")]
        [Identity]
        [PrimaryKey]
        public int Id {
            get { return Id; }
            set {
                Id = value;
                OnPropertyChanged("Id");
            } }

        [Column(Name = "Surname", CanBeNull = false)]
        public string Surname { get; set; }

        [Column(Name = "Name", CanBeNull = false)]
        public string Name { get; set; }

        [Column(Name = "Patronymic", CanBeNull = false)]
        public string Patronymic { get; set; }

        [Column(Name = "Birthday", CanBeNull = false)]
        public DateTime Birthday { get; set; }

        [Column(Name = "Gender", CanBeNull = false)]
        public Gender Gender { get; set; }

        [Column(Name = "SubdivisionId", CanBeNull = false)]
        public int SubdivisionId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}