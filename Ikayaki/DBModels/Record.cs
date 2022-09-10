using SQLite;


namespace Ikayaki.DBModels
{
        [Table("record")]
    public class Record
    {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }
            public int? ParentTaskId { get; set; }
            public string Category { get; set; }
    }
}
