
namespace Ikayaki.Page;


public partial class MainPage : ContentPage
{
    async void OnIndexButtonClicked(object sender, EventArgs args) {
        await Shell.Current.GoToAsync("/records");
    }
    async void OnCreateButtonClicked(object sender, EventArgs args) {
        await Shell.Current.GoToAsync("/records/new");
    }
	public MainPage()
	{
		InitializeComponent();
	}
}

