using _Record = Ikayaki.Models.Record;

namespace Ikayaki.View.Record;

[QueryProperty(nameof(ThisDay), "ThisDay")]
public partial class TodaysRecord : ContentPage
{
    private DateTime _ThisDay;
    public DateTime ThisDay {
        get
        {
            return _ThisDay;
        }
        set
        {
            _ThisDay = value;
            OnPropertyChanged();
        }
    }
    public async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs args)
    {
        _Record record = args.CurrentSelection.FirstOrDefault() as _Record;

        var navigationParameter = new Dictionary<string, object>
            {
                { "TheRecord", record }
            };
        await Shell.Current.GoToAsync($"records/detail", navigationParameter);
    }

    public void OnToggle(object sender, EventArgs args)
    {

    }
    public async void OnAddButtonClicked(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync($"records/new");
    }

    public async void OnPrevButtonClicked(object sender, EventArgs args)
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { "ThisDay", ThisDay - new TimeSpan(1,0,0,0) }
            };
        await Shell.Current.GoToAsync($"records/day", navigationParameter);
    }
    public async void OnNextButtonClicked(object sender, EventArgs args)
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { "ThisDay", ThisDay + new TimeSpan(1,0,0,0) }
            };
        await Shell.Current.GoToAsync($"records/day", navigationParameter);
    }
   

    public TodaysRecord()
    {
        InitializeComponent();
        BindingContext = this;
        ThisDay = ThisDay.Year == 1 ? DateTime.Now.Date : ThisDay;
        RecordList.ItemsSource = App.Model.Records.List.Where(
            item => (
        item.StartedAt?.Date == ThisDay || item.FinishedAt?.Date == ThisDay
        )
        );
    }

}