using LinqToDB.Mapping;

namespace FunnyWaterCarrier.DAL.Entities {
    [Table(Name = "subdivision")]
    internal class Subdivision {
        [Column("Id")]
        [Identity]
        [PrimaryKey]
        public int Id { get; set; }

        [Column(Name = "Name", CanBeNull = false)]
        public string ProductName { get; set; }
        
        [Column(Name = "Leader", CanBeNull = false)]
        public int? Leader { get; set; }
    }
    
}