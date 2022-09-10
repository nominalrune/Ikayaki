using TaskModel = Ikayaki.DBModels.Task;
using static Ikayaki.App.Control;
using System.Windows.Input;

namespace Ikayaki.Page
{

    public partial class TaskIndex : ContentPage
    {
        //public bool isRefreshing=false;// refresh‚ÍVM‚É‘‚­‚×‚µI
        //public  ICommand refreshCommand;
        public TaskIndex()
        {
            InitializeComponent();
            taskList.ItemsSource = ViewModel.Task.Tasks;
            BindingContext=this;

            //refreshView.IsRefreshing = isRefreshing;
            //refreshCommand=new ICommand(()=>)
            refreshView.Command =ViewModel.Task.TaskGetAllCommand;
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
