using TaskModel = Ikayaki.Models.Task;
using Ikayaki.ViewModel;

namespace Ikayaki;

public partial class TaskIndex : ContentPage
{
	public TaskIndex()
	{
		InitializeComponent();
        taskList.ItemsSource = App.TaskVM.Tasks;
        App.TaskVM._Tasks.CollectionChanged += (param,e) => { 
            taskList02.ItemsSource = App.TaskVM._Tasks;
        };
        taskList02.ItemsSource = App.TaskVM._Tasks;
    }
    
    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        Console.WriteLine("OnGetButtonClicked ‚ªŒÄ‚Î‚ê‚½‚æB");

        App.TaskVM.TaskGetAllCommand.ExecuteAsync();
        //taskList.ItemsSource = App.TaskVM.Tasks;
        App.TaskVM.RenewTasks();
        //taskList2.ItemsSource = App.TaskVM._Tasks;

    }
}