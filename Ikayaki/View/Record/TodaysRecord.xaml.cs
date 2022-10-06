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
    public void OnCollectionViewSelectionChanged(object sender, EventArgs args)
    {

    }
    public void OnAddButtonClicked(object sender, EventArgs args)
    {

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