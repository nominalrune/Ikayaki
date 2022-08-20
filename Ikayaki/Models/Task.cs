using SQLite;

namespace Ikayaki.Models
{
    [Table("task")]
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? ParentTaskId { get; set; }
        public string Category { get; set; }
    }
    public class TaskData
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? ParentTaskId { get; set; }
        public string Category { get; set; }
    }
}
