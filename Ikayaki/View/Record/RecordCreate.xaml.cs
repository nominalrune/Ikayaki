using Ikayaki.Models;
namespace Ikayaki.Page
{
    [QueryProperty(nameof(Record), "TheRecord")]
    public partial class RecordCreate : ContentPage
    {

        Record record;
        public Record Record
        {
            get => record;
            set
            {
                record = value;
                OnPropertyChanged();
            }
        }

        public DateTime BaseDate { get; set; }= DateTime.Today;
        public TimeSpan StartedAtPick { get; set; }
        public TimeSpan FinishedAtPick { get; set; }

        public string StatusMessage { get; set; } = "";
        public async void OnNewButtonClicked(object sender, EventArgs args)
        {

            StatusMessage = "";
            Record res;
            if (Record.Id != null)
            {
                res = await App.Model.Records.Update(Record);
            }
            else
            {
                res = await App.Model.Records.Add(Record.Title, BaseDate.Add(StartedAtPick), BaseDate.Add(FinishedAtPick), Record.Memo);
            }
            if (res != null)
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "TheRecord", res }
                };
                await Shell.Current.GoToAsync($"records/detail", navigationParameter);
            }
        }


        public RecordCreate()
        {
            InitializeComponent();
            BindingContext = this;
            Record ??= new Record() { Id = null };
            StatusMessage = App.Model.Tasks.StatusMessage.Value;
            
            if (Record.StartedAt != null)
            {
                BaseDate = ((DateTime)Record.StartedAt).Date;
                StartedAtPick = Record.StartedAt.GetValueOrDefault(DateTime.Now) - BaseDate;
            }
            if (Record.FinishedAt != null)
            {
                BaseDate = Record.StartedAt == null ? ((DateTime)Record.FinishedAt).Date : BaseDate;
                FinishedAtPick = (DateTime)Record.FinishedAt - BaseDate;
            }
        }


    }
}
