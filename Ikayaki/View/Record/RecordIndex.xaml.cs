using Ikayaki.Models;
namespace Ikayaki.Page;

public partial class RecordIndex : ContentPage
{
	public RecordIndex()
	{
		InitializeComponent();
        BindingContext = this;
        RecordList.ItemsSource = App.Model.Records.List;
    }
    async void OnAddButtonClicked(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync($"records/new");
    }
    async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs args)
    {
        Record record = args.CurrentSelection.FirstOrDefault() as Record;

        var navigationParameter = new Dictionary<string, object>
            {
                { "TheRecord", record }
            };
        await Shell.Current.GoToAsync($"records/detail", navigationParameter);
    }
}