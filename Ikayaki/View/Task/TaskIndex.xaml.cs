using TaskModel = Ikayaki.Models.Task;
using Ikayaki.ViewModel;
using System.Windows.Input;

namespace Ikayaki.Page
{

    public partial class TaskIndex : ContentPage
    {
        //public bool isRefreshing=false;// reflesh‚ÍVM‚É‘‚­‚×‚µI
        //public  ICommand refreshCommand;
        public TaskIndex()
        {
            InitializeComponent();
            taskList.ItemsSource = App.TaskVM.Tasks;
            BindingContext=this;

            //refleshView.IsRefreshing = isRefleshing;
            //refleshCommand=new ICommand(()=>)
            refleshView.Command = App.TaskVM.TaskGetAllCommand;
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