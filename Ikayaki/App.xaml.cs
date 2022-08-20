using Ikayaki.Repositories;
using Ikayaki.ViewModels;
namespace Ikayaki;


public partial class App : Application
{
	/// <summary>
	/// Control class works as the main state controlling class.
	/// It handles <code>Repository</code> and <code>ViewModel</code> class.
	/// </summary>
	public static class Control
	{
		public static class Repository
		{
			public static TaskRepository Task { get; set; }
		}
		public static class ViewModel
		{
			public static TaskViewModel Task { get; set; }
			public static TaskInputViewModel TaskInput { get; set; }
		}

	}

	public App(
		TaskRepository taskRepository,
		TaskViewModel taskViewModel,
		TaskInputViewModel taskInputViewModel
		)
	{
		InitializeComponent();
		Control.Repository.Task = taskRepository;
		Control.ViewModel.Task = taskViewModel;
		Control.ViewModel.TaskInput = taskInputViewModel;
		// gets initial Tasks
		Control.ViewModel.Task.TaskGetAllCommand.ExecuteAsync();

		MainPage = new AppShell();
	}
}
