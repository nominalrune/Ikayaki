using TaskModel = Ikayaki.Models.Task;

namespace Ikayaki.Page
{
    public partial class TaskIndex : ContentPage
    {
        public TaskIndex()
        {
            InitializeComponent();
            BindingContext=this;
            taskList.ItemsSource = App.Model.Tasks.List;
        }
        async void OnAddButtonClicked(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync($"tasks/new");
        }
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            TaskModel task = args.CurrentSelection.FirstOrDefault() as TaskModel;

            var navigationParameter = new Dictionary<string, object>
            {
                { "TheTask", task }
            };
            await Shell.Current.GoToAsync($"tasks/detail", navigationParameter);
        }
    }
}
