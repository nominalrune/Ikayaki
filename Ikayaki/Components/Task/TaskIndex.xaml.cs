using TaskModel = Ikayaki.Models.Task;
using Ikayaki.ViewModel;

namespace Ikayaki;

public partial class TaskIndex : ContentPage
{
	public TaskIndex()
	{
		InitializeComponent();
        taskList.ItemsSource = App.TaskVM.Tasks;
    }
    
    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        Console.WriteLine("OnGetButtonClicked が呼ばれたよ。");
        App.TaskVM.TaskGetAllCommand.ExecuteAsync();
    }
}