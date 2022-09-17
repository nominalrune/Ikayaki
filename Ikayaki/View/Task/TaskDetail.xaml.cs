
using TaskModel = Ikayaki.Models.Task;
namespace Ikayaki.Element
{ 
        public class PlusButton : IDrawable
        {
            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
            canvas.StrokeColor = Colors.Azure;
            canvas.StrokeSize = 4;
            canvas.DrawEllipse(10, 10, 100, 100);
        }
        }
}

namespace Ikayaki.Page
{
    [QueryProperty(nameof(task), "TheTask")]
    public partial class TaskDetail : ContentPage
    {
        TaskModel _task;
        public TaskModel task
        {
            get => _task;
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }
        async void OnEditButtonClicked(object sender, EventArgs args)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "TheTask", _task }
            };
            await Shell.Current.GoToAsync($"tasks/new", navigationParameter);
        }
        public TaskDetail()
        {
            InitializeComponent();
            BindingContext = this;

        }
    }

}
