
namespace Ikayaki.Page;


public partial class MainPage : ContentPage
{
    async void OnTaskIndexButtonClicked(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync("/tasks");
    }
    async void OnTaskCreateButtonClicked(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync("/tasks/new");
    }
    async void OnIndexButtonClicked(object sender, EventArgs args) {
        await Shell.Current.GoToAsync("/records");
    }
    async void OnCreateButtonClicked(object sender, EventArgs args) {
        await Shell.Current.GoToAsync("/records/new");
    }
    async void OnTodayPageButtonClicked(object sender, EventArgs args)
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { "ThisDay", DateTime.Now.Date }
            };
        await Shell.Current.GoToAsync($"/records/day", navigationParameter);
    }
    public MainPage()
	{
		InitializeComponent();
	}
}

