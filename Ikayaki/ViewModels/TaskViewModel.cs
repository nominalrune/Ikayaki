using Reactive.Bindings;

using TaskModel =Ikayaki.Models.Task;
using System.ComponentModel;

namespace Ikayaki.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ReactiveCollection<TaskModel> Tasks { get; }

        public string TaskTitle { get; set; } = "";
        public string TaskDetail { get; set; } = "";
        public string StatusMessage { get; set; } = "";
        public AsyncReactiveCommand TaskGetAllCommand { get; }
        public AsyncReactiveCommand TaskAddCommand { get; }

        public TaskViewModel()
        {
            Console.WriteLine("TaskViewModel のコンストラクタが呼ばれたよ。");
            Tasks = new ReactiveCollection<TaskModel>();
            TaskGetAllCommand = new AsyncReactiveCommand()
                .WithSubscribe(async () => {
                    Console.WriteLine("TaskGetAllCommand が呼ばれたよ。");
                    var res = await App.TaskRepo.GetWhere();
                    Tasks.Clear();
                    Tasks.AddRangeOnScheduler(res);
                });
            TaskAddCommand = new AsyncReactiveCommand()
                .WithSubscribe(async () => {
                    Console.WriteLine("TaskAddCommand が呼ばれたよ。");
                    var res = await App.TaskRepo.Add(TaskTitle, TaskDetail);
                    Tasks.AddOnScheduler(res);
                    StatusMessage = App.TaskRepo.StatusMessage;
                    if (res != null)
                    {
                        TaskDetail = "";
                        TaskTitle = "";
                    }
                });


        }

    }
}
