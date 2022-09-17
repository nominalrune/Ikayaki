using SQLite;

namespace Ikayaki.Models
{
    [Table("record")]
    public class Record
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }
        public int? ParentRecordId { get; set; }
        public string Category { get; set; }
    }
}
