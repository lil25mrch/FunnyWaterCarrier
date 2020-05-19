using LinqToDB.Common;
using LinqToDB.Mapping;

namespace FunnyWaterCarrier.DAL.Entities {
    [Table(Name = "order")]
    public class Order : BaseEntity{
        public Order() {
            ProductName = "Default";
        }
        
        [Column(Name = "ProductName", CanBeNull = false)]
        public string ProductName { get; set; }

        [Column(Name = "EmployeeId", CanBeNull = false)]
        public int? EmployeeId { get; set; }

        public override bool Verify() {
            if (!EmployeeId.HasValue || ProductName.IsNullOrEmpty()) {
                return false;
            }

            return true;
        }
    }
}