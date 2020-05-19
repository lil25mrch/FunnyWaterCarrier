using System;
using FunnyWaterCarrier.Enums;
using LinqToDB.Common;
using LinqToDB.Mapping;

namespace FunnyWaterCarrier.DAL.Entities {
    [Table(Name = "employee")]
    public class Employee : BaseEntity {
        public Employee() {
            Surname = "Default";
            Name = "Default";
            Patronymic = "Default";
            Birthday = DateTime.Now;
            Gender = Gender.Man;
        }
        
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
        public int? SubdivisionId { get; set; }

        public override bool Verify() {
            if (Birthday >= DateTime.Now) {
                return false;
            }

            if (!SubdivisionId.HasValue) {
                return false;
            }

            if (Surname.IsNullOrEmpty() || Name.IsNullOrEmpty()) {
                return false;
            }

            return true;
        }
    }
}