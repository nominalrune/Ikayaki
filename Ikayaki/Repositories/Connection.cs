using SQLite;

namespace Ikayaki.Repositories
{
    public class Connection
    {
        string dbPath { get; }
        SQLiteAsyncConnection connection;

        public Connection(string _dbPath)
        {
            dbPath = _dbPath;
        }

        public SQLiteAsyncConnection db
        {
            get
            {
                connection ??= new SQLiteAsyncConnection(dbPath); // when null the right hand side is evaluated. (only when the `connection` is null, is it?)
                return connection;
            }

        }
    }
}