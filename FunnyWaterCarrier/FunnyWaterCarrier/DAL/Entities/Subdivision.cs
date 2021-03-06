﻿using LinqToDB.Common;
using LinqToDB.Mapping;

namespace FunnyWaterCarrier.DAL.Entities {
    [Table(Name = "subdivision")]
    public class Subdivision : BaseEntity {
        public Subdivision() {
            Name = "Default";
        }
        
        [Column(Name = "Name", CanBeNull = false)]
        public string Name { get; set; }

        [Column(Name = "EmployeeId", CanBeNull = false)]
        public int? EmployeeId { get; set; }

        public override bool Verify() {
            if (!EmployeeId.HasValue || Name.IsNullOrEmpty()) {
                return false;
            }

            return true;
        }
    }
}