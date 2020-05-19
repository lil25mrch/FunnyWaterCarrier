using System.ComponentModel;
using LinqToDB.Mapping;

namespace FunnyWaterCarrier.DAL.Entities {
    public abstract class BaseEntity {
        [Column("Id")]
        [Identity]
        [PrimaryKey]
        public int Id { get; set; }

        public abstract bool Verify();
    }
}