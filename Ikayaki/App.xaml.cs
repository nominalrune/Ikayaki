using Ikayaki.Repositories;
using TaskList =Ikayaki.Models.Tasks;
namespace Ikayaki;


public partial class App : Application
{
    public static class Model
    {
        public static TaskList Tasks { get; internal set; }
    }
    public App(
		Connection connection
		)
	{
		InitializeComponent();
		Model.Tasks = new TaskList(connection);
		// gets initial Tasks
		//Control.ViewModel.Task.TaskGetAllCommand.ExecuteAsync();

		MainPage = new AppShell();
	}
}
