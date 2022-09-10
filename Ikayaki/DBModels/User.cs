using SQLite;

namespace Ikayaki.DBModels
{
    [Table("user")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
    }
}
