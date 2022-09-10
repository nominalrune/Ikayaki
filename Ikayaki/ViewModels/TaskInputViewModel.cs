using Reactive.Bindings;

using Ikayaki.DBModels;
using TaskModel = Ikayaki.DBModels.Task;
using System.ComponentModel;

namespace Ikayaki.ViewModels
{
    public class TaskInputViewModel : TaskViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        internal string TaskTitle { get; set; } = "";
        public string TaskDetail { get; set; } = "";
        public AsyncReactiveCommand TaskAddCommand { get; }

        public TaskInputViewModel()
        {
            var taskData=new TaskData(){Name="",Description=""};
            TaskAddCommand = new AsyncReactiveCommand()
                .WithSubscribe(async () => {
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
