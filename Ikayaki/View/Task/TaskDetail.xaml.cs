
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
    [QueryProperty(nameof(Task), "TheTask")]
    public partial class TaskDetail : ContentPage
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
        async void OnEditButtonClicked(object sender, EventArgs args)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "TheTask", Task }
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
