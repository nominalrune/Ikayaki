using Ikayaki.Page;
using Ikayaki.Repositories;
using Reactive.Bindings;
using System.ComponentModel;

namespace Ikayaki.Models
{
    public class Tasks : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ReactiveCollection<Task> List { get; }
        public ReactivePropertySlim<string> StatusMessage { get; }

        readonly TaskRepository repo;
        public async void GetAll()
        {
            StatusMessage.Value = "";
            var res = await repo.GetWhere();

            List.Clear();
            List.AddRangeOnScheduler(res);
            StatusMessage.Value = repo.StatusMessage;
        }
        public async Task<Task> Add(string Name, string Description)
        {
            StatusMessage.Value = "";
            var res = await repo.Add(Name, Description);
            List.AddOnScheduler(res);
            StatusMessage.Value = repo.StatusMessage;
            return res;
        }
        public async Task<Task> Update(Task task)
        {
            StatusMessage.Value = "";
            var res = await repo.Update(task);
            StatusMessage.Value = repo.StatusMessage;
            return res;
        }

        //public AsyncReactiveCommand GetAll { get; }
        //public async TaskModel<TaskModel> Add(string Name, string Description)
        //{
        //    var res = await repo.Add(Name, Description);
        //    List.AddOnScheduler(res);
        //    return res;
        //}
        //public AsyncReactiveCommand GetAll { get; }

        public Tasks(Connection connection)
        {
            StatusMessage=new ReactivePropertySlim<string> ("");
            repo = new TaskRepository(connection);
            List = new ReactiveCollection<Task>();
            //GetAll();
            //GetAll = new AsyncReactiveCommand()
            //    .WithSubscribe(async () => {
            //        var res = await repo.GetWhere();
            //        List.Clear();
            //        List.AddRangeOnScheduler(res);
            //    });
        }
    }
}
