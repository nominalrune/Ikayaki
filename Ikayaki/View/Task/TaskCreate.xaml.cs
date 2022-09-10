using Ikayaki.DBModels;
using Reactive.Bindings;
using TaskModel = Ikayaki.DBModels.Task;


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
        public AsyncReactiveCommand TaskAddCommand { get; } = new AsyncReactiveCommand();

        public TaskCreate()
        {
            InitializeComponent();

        }
        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            StatusMessage = "";
            var res = await App.Control.Repository.Task.Add(TaskTitle, TaskDetail);
            StatusMessage = App.Control.Repository.Task.StatusMessage;
            if (res != null)
            {
                TaskDetail = "";
                TaskTitle = "";
            }
        }

    }
}
