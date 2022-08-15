using Reactive.Bindings;

using TaskModel =Ikayaki.Models.Task;
using Ikayaki;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reactive.Linq;
using System.Collections.ObjectModel;

namespace Ikayaki.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ReactiveCollection<TaskModel> Tasks { get; }
        public ObservableCollection<TaskModel> _Tasks { get; }

        public string TaskTitle { get; set; } = "";
        public string TaskDetail { get; set; } = "";
        public string StatusMessage { get; set; } = "";
        public AsyncReactiveCommand TaskGetAllCommand { get; }
        public AsyncReactiveCommand TaskAddCommand { get; }

        public async void RenewTasks()
        {
            if (App.TaskRepo != null)
            {
                var res = await App.TaskRepo.GetWhere();
                if (res != null)
                {
                    _Tasks.Clear();
                    foreach (var item in res)
                    {
                        _Tasks.Add(item);
                    }
                }
                else
                {
                    throw new Exception("App.TaskRepo.GetWhere().Result is null");
                }
            }
            else
            {
                throw new Exception("App.TaskRepo is null");
            }
        }
        public TaskViewModel()
        {
            Console.WriteLine("TaskViewModel のコンストラクタが呼ばれたよ。");
            _Tasks = new ObservableCollection<TaskModel>();
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
