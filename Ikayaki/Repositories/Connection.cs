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
            connection = new SQLiteAsyncConnection(dbPath);
        }

        public SQLiteAsyncConnection db
        {
            get
            {
                //if (connection != null)
                //    return connection; 

                connection ??= new SQLiteAsyncConnection(dbPath); // when null the right hand side is evaluated. (only when the `connection` is null, is it?)
                return connection;
            }

        }
    }
}