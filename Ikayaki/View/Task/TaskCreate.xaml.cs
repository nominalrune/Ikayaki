using TaskModel = Ikayaki.Models.Task;
namespace Ikayaki.Page
{
    [QueryProperty(nameof(Task), "TheTask")]
    public partial class TaskCreate : ContentPage
    {

        TaskModel task;
        public TaskModel Task
        {
            get => task;
            set
            {
                task = value;
                OnPropertyChanged();
            }
        }
        public string StatusMessage { get; set; } = "";
        public async void OnNewButtonClicked(object sender, EventArgs args)
        {

            StatusMessage = "";
            TaskModel res;
            if (Task.Id != null)
            {
                res = await App.Model.Tasks.Update(Task);
            }
            else
            {
                res = await App.Model.Tasks.Add(f_Name.Text, f_Description.Text);
            }
            if (res != null)
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "TheTask", res }
                };
                await Shell.Current.GoToAsync($"tasks/detail", navigationParameter);
            }
        }


        public TaskCreate()
        {
            InitializeComponent();
            BindingContext = this;
            if (Task == null)
            {
                Task=new TaskModel();
            }
            StatusMessage = App.Model.Tasks.StatusMessage.Value;
            
        }


    }
}
