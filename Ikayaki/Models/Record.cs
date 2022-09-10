


namespace Ikayaki.Models
{
    public interface IRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }
        public int? ParentRecordId { get; set; }
        public string Category { get; set; }
    }
}
