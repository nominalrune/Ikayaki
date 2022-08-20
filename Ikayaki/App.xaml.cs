using Ikayaki.Repository;
using Ikayaki.ViewModel;
namespace Ikayaki;

public partial class App : Application
{
	static Dictionary<string, Dictionary<string, object>> _Control { get; private set; }
	public static TaskRepository TaskRepo { get; private set; }
	public static TaskViewModel TaskVM { get; private set; }
    
	public static class Control{
        public static class Repository { 
            public static TaskRepository Task {get; set;}
        }
        public static class ViewModel {
            public static TaskViewModel Task {get; set;}
            public static TaskInputViewModel TaskInput {get; set;}
        }
        
    }

	public App(
        TaskRepository taskRepository, 
        TaskViewModel taskViewModel,TaskInputViewModel taskInputViewModel
        )
	{
		InitializeComponent();
		Control.Repository.Task = taskRepository;
		Control.ViewModel.Task = taskViewModel;
		Control.ViewModel.TaskInput = taskInputViewModel;
		TaskRepo = taskRepository;
		TaskVM = taskViewModel;
		// gets initial Tasks
		TaskVM.TaskGetAllCommand.ExecuteAsync();

		MainPage = new AppShell();
	}
}
