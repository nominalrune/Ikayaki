using Ikayaki.Repositories;

namespace Ikayaki.Models
{
    public class Tasks
    {
        public List<Task> list { get; internal set; }
        public TaskRepository repo;
        public Tasks(Connection connection)
        {
            repo = new TaskRepository(connection);
        }
    }
}
