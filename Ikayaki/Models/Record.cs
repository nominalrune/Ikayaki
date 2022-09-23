using SQLite;

namespace Ikayaki.Models
{
    [Table("record")]
    public class Record
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public string Title { get; set; }
        public int? RelevantTaskId { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public string? Memo { get; set; }
    }
}
