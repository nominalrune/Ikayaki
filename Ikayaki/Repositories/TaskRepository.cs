using SQLite;
using TaskData=Ikayaki.DBModels.TaskData;
using TaskModel = Ikayaki.DBModels.Task;

namespace Ikayaki.Repositories
{
	public class TaskRepository
	{
		Connection connection;
		public string StatusMessage { get; set; }

		public TaskRepository(Connection _connection)
		{
            connection = _connection;
		}
        
		private async Task Init()
		{
			if (connection != null) { return; }
			await connection.db.CreateTableAsync<TaskModel>();
		}

		public async Task<TaskModel> Get(int Id)
		{
			try
			{
				await Init();
				return await connection.db.Table<TaskModel>().Where(x => x.Id == Id).FirstAsync();
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
			}

			return new TaskModel();
		}
		public async Task<List<TaskModel>> GetWhere()
		{
			try
			{
				await Init();
				return await connection.db.Table<TaskModel>().ToListAsync();
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
			}

			return new List<TaskModel>();
		}

		public async Task<TaskModel> Add(string name, string description)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("Valid name required");
			}
			int result;
			TaskModel task = new() { Name = name, Description = description };
			try
			{
				await Init();
				result = await connection.db.InsertAsync(task);

				StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
			}
			return task;
		}
        public async Task<TaskModel> Update(int id, string name, string description)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("Valid name required");
			}
			int result;
			TaskModel task = new() { Name = name, Description = description };
			try
			{
				await Init();
				result = await connection.db.UpdateAsync(task);

				StatusMessage = $"{result} record(s) updated (Name: {name})";
			}
			catch (Exception ex)
			{
				StatusMessage = $"Failed to add {name}. Error: {ex.Message}";
			}
			return task;
		}


	}
}
