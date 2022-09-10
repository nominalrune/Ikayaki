

namespace Ikayaki.Models
{
    public class ITask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? ParentTaskId { get; set; }
        public string Category { get; set; }
    }
}
