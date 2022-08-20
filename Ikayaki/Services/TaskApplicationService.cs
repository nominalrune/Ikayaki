using Reactive.Bindings;

using TaskModel =Ikayaki.Models.Task;
using System.ComponentModel;

namespace Ikayaki.Services
{
    public class TaskApplicationService : INotifyPropertyChanged
    {
            public event PropertyChangedEventHandler PropertyChanged;

            public ReactiveCollection<TaskModel> Tasks { get; }
            public bool Status { get; set; } = false;
            public string StatusMessage { get; set; } = "";
            public AsyncReactiveCommand TaskGetAllCommand { get; }

            public TaskApplicationService()
            {
                Tasks = new ReactiveCollection<TaskModel>();
                TaskGetAllCommand = new AsyncReactiveCommand()
                    .WithSubscribe(async () => {
                        var res = await App.Control.Repository.Task.GetWhere();
                        Tasks.Clear();
                        Tasks.AddRangeOnScheduler(res);
                    });
            }

        }
}
