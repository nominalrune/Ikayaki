using SQLite;
namespace Ikayaki.Models
{
    [Table("task")]
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(5000)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public int? ParentTaskId { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
    }
}
