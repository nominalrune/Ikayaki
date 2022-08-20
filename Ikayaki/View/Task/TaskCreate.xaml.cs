using TaskModel = Ikayaki.Models.Task;
using Ikayaki.Repository;

namespace Ikayaki.Page
{

    [QueryProperty(nameof(task), "TheTask")]
    public partial class TaskCreate : ContentPage
    {
        TaskModel _task;
        public TaskModel task
        {
            get => _task;
            set
            {
                _task = value;
                newTask.Text = value.Name;
                newTaskDetail.Text = value.Description;
                OnPropertyChanged();

            }
        }
        public TaskCreate()
        {
            InitializeComponent();
            BindingContext = this;

        }
        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            Console.WriteLine("OnNewButtonClicked Ç™åƒÇŒÇÍÇΩÇÊÅB");
            statusMessage.Text = "";
            App.Control.ViewModel.TaskInput.TaskTitle = newTask.Text;
            App.Control.ViewModel.TaskInput.TaskDetail = newTaskDetail.Text;

            await App.Control.ViewModel.TaskInput.TaskAddCommand.ExecuteAsync();
            statusMessage.Text = App.Control.ViewModel.TaskInput.StatusMessage;
            newTask.Text = App.Control.ViewModel.TaskInput.TaskTitle;
            newTaskDetail.Text = App.Control.ViewModel.TaskInput.TaskDetail;
        }

    }
}
