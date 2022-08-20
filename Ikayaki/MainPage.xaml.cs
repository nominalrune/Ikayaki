
namespace Ikayaki.Page;


public partial class MainPage : ContentPage
{
    async void OnIndexButtonClicked(object sender, EventArgs args) {
        await Shell.Current.GoToAsync("/tasks");
    }
    async void OnCreateButtonClicked(object sender, EventArgs args) {
        await Shell.Current.GoToAsync("/tasks/new");
    }
	public MainPage()
	{
		InitializeComponent();
	}
}

