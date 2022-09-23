using Ikayaki.Page;
using Ikayaki.Repositories;
using Reactive.Bindings;
using System.ComponentModel;

namespace Ikayaki.Models
{
    public class Records : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ReactiveCollection<Record> List { get; }
        public ReactivePropertySlim<string> StatusMessage { get; }

        readonly RecordRepository repo;
        public async void GetAll()
        {
            StatusMessage.Value = "";
            var res = await repo.GetWhere();

            List.Clear();
            List.AddRangeOnScheduler(res);
            StatusMessage.Value = repo.StatusMessage;
        }
        public async Task<Record> Add(string title, DateTime? startedAt, DateTime? finishedAt, string memo)
        {
            StatusMessage.Value = "";
            var res = await repo.Add(title,startedAt, finishedAt, memo);
            List.AddOnScheduler(res);
            StatusMessage.Value = repo.StatusMessage;
            return res;
        }
        public async Task<Record> Update(Record task)
        {
            StatusMessage.Value = "";
            var res = await repo.Update(task);
            StatusMessage.Value = repo.StatusMessage;
            return res;
        }


        public Records(Connection connection)
        {
            StatusMessage=new ReactivePropertySlim<string> ("");
            repo = new RecordRepository(connection);
            List = new ReactiveCollection<Record>();
        }
    }
}
