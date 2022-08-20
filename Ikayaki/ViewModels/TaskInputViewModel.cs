using Reactive.Bindings;

using Ikayaki.Models;
using TaskModel = Ikayaki.Models.Task;
using System.ComponentModel;

namespace Ikayaki.ViewModels
{
    public class TaskInputViewModel : TaskViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ReactiveCollection<TaskModel> Tasks { get; }
        
        public bool Status { get; set; } = false;
        public string TaskTitle { get; set; } = "";
        public string TaskDetail { get; set; } = "";
        public string StatusMessage { get; set; } = "";
        public AsyncReactiveCommand TaskGetAllCommand { get; }
        public AsyncReactiveCommand TaskAddCommand { get; }

        public TaskInputViewModel()
        {
            Tasks = new ReactiveCollection<TaskModel>();
            var taskData=new TaskData(){Name="",Description=""};
            TaskGetAllCommand = new AsyncReactiveCommand()
                .WithSubscribe(async () => {
                    var res = await App.Control.Repository.Task.GetWhere();
                    Tasks.Clear();
                    Tasks.AddRangeOnScheduler(res);
                });
            TaskAddCommand = new AsyncReactiveCommand()
                .WithSubscribe(async () => {
                    Console.WriteLine("TaskAddCommand が呼ばれたよ。");
                    var res = await App.Control.Repository.Task.Add(TaskTitle, TaskDetail);
                    Tasks.AddOnScheduler(res);
                    StatusMessage = App.Control.Repository.Task.StatusMessage;
                    if (res != null)
                    {
                        TaskDetail = "";
                        TaskTitle = "";
                    }
                });


        }

    }
}
