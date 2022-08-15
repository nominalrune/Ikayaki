using Ikayaki.Repository;
using Ikayaki.ViewModel;
namespace Ikayaki;

public partial class App : Application
{
    public static TaskRepository TaskRepo { get; private set; }
    public static TaskViewModel TaskVM { get; private set; }


    public App(TaskRepository repo, TaskViewModel vm)
	{
		InitializeComponent();
        TaskRepo = repo;
        TaskVM = vm;
        // gets initial Tasks
        TaskVM.TaskGetAllCommand.ExecuteAsync();
        
        MainPage = new AppShell();
    }
}
