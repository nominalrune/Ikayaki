using TaskModel = Ikayaki.Models.Task;
using Ikayaki.Repository;

namespace Ikayaki;

public partial class TaskCreate : ContentPage
{
	public TaskCreate()
	{
		InitializeComponent();
    }
    public async void OnNewButtonClicked(object sender, EventArgs args)
    {
        Console.WriteLine("OnNewButtonClicked が呼ばれたよ。");
        statusMessage.Text = "";
        App.TaskVM.TaskTitle = newTask.Text;
        App.TaskVM.TaskDetail = newTaskDetail.Text;

        await App.TaskVM.TaskAddCommand.ExecuteAsync();
        statusMessage.Text = App.TaskVM.StatusMessage;
         newTask.Text= App.TaskVM.TaskTitle;
         newTaskDetail.Text= App.TaskVM.TaskDetail;
    }

    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        Console.WriteLine("OnGetButtonClicked が呼ばれたよ。");
        statusMessage.Text = "";

        App.TaskVM.TaskGetAllCommand.ExecuteAsync();
        App.TaskVM.RenewTasks();

    }
}