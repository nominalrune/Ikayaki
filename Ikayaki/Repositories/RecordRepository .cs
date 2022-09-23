using SQLite;
using Ikayaki.Models;
using Task = System.Threading.Tasks.Task;

namespace Ikayaki.Repositories
{
	public class RecordRepository
	{
		Connection connection;
		bool IsAvailable = false;
		public string StatusMessage { get; set; }

		public RecordRepository(Connection _connection)
		{
            connection = _connection;
			if (connection == null)
			{
				throw new ArgumentNullException(nameof(connection));
			}
        }
        
		private async Task Init()
		{
			if (IsAvailable) { return; }
			await connection.db.CreateTableAsync<Record>();
			IsAvailable = true;
        }

		public async Task<Record> Get(int Id)
		{
			try
			{
				await Init();
				return await connection.db.Table<Record>().Where(x => x.Id == Id).FirstAsync();
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
			}
            StatusMessage = "success";
            return new Record();
		}
		public async Task<List<Record>> GetWhere()
		{
			try
			{
				await Init();
				StatusMessage = "success";
				return await connection.db.Table<Record>().ToListAsync();
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
				throw new Exception(StatusMessage);
			}
		}
        public async Task<List<Record>> GetWhere(Func<Record, bool> param)
        {
            try
            {
                await Init();
				var res = await connection.db.Table<Record>().ToListAsync();
            StatusMessage = "success";
				return res.ToList().Where(param).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
			}
            return new List<Record>();
        }
        public async Task<Record> Add(string title, DateTime? startedAt, DateTime? finishedAt, string memo)
		{
			if (string.IsNullOrEmpty(title))
			{
				throw new Exception("Valid title required");
			}
			int result;
			Record record = new() { 
				Title=title, 
				StartedAt=startedAt, 
				FinishedAt=finishedAt,
				Memo=memo
			};

            try
			{
				await Init();
				result = await connection.db.InsertAsync(record);

				StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, title);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", title, ex.Message);
			}
			return record;
		}
        public async Task<Record> Update(int id, string title, DateTime? startedAt, DateTime? finishedAt, string memo)
        {
			if (string.IsNullOrEmpty(title))
			{
				throw new Exception("Valid title required");
			}
			int result;
			Record record = new() {
				Id=id,
				Title = title,
				StartedAt=startedAt,
				FinishedAt=finishedAt,
				Memo = memo
			};
			try
			{
				await Init();
				result = await connection.db.UpdateAsync(record);
				StatusMessage = $"{result} record(s) updated (Title: {title})";

			}
			catch (Exception ex)
			{
				StatusMessage = $"Failed to add {title}. Error: {ex.Message}";
			}
			return record;
		}
        public async Task<Record> Update(Record record)
        {
            if (string.IsNullOrEmpty(record.Title))
            {
                throw new Exception("Valid name required");
            }
            int result;
            try
            {
                await Init();
                result = await connection.db.UpdateAsync(record);
                StatusMessage = $"{result} record(s) updated (Title: {record.Title})";

            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to add {record.Title}. Error: {ex.Message}";
            }
            return record;
        }


    }
}
