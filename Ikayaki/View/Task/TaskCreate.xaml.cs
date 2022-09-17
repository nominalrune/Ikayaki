
using TaskModel = Ikayaki.Models.Task;


namespace Ikayaki.Page
{

    [QueryProperty(nameof(task), "TheTask")]
    public partial class TaskCreate : ContentPage
    {
        string StatusMessage { get; set; } = "";
        TaskModel task { get; set;}
        public TaskModel Task
        {
            get => task;
            set
            {
                task = value;
                OnPropertyChanged();
            }
        }
        internal string TaskTitle { get; set; } = "";
        public string TaskDetail { get; set; } = "";

        public TaskCreate()
        {
            InitializeComponent();
            StatusMessage = App.Model.Tasks.repo.StatusMessage;
            BindingContext =this;
        }
        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            StatusMessage = "";
            var res = await App.Model.Tasks.repo.Add(TaskTitle, TaskDetail);
            if (res != null)
            {
                TaskDetail = "";
                TaskTitle = "";
            }
        }

    }
}
