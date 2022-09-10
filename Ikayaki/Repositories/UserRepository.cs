using SQLite;
using User=Ikayaki.DBModels.User;
using System.Threading.Tasks;

namespace Ikayaki.Repositories
{
    public class UserRepository
    {
        private Connection connection;
        public string StatusMessage { get; set; }

        public UserRepository(Connection _connection)
        {
            connection = _connection;
        }
        private async Task Init()
        {
            if (connection != null) { return; }
            await connection.db.CreateTableAsync<User>();
        }
        public async Task<User> Add(string name, string email)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Valid name required");
            }
            int result;
            User user = new() { Name = name, Email = email };
            try
            {
                await Init();
                result = await connection.db.InsertAsync(user);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
            return user;

        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                await Init();
                return await connection.db.Table<User>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<User>();
        }
        public async Task<User> Get(int Id)
        {
            try
            {
                await Init();
                return await connection.db.Table<User>().Where(x => x.Id == Id).FirstAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new User();
        }
    }
}
