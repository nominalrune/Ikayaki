
using Record = Ikayaki.Models.Record;
using Ikayaki.Element;

namespace Ikayaki.Page
{
    [QueryProperty(nameof(Record), "TheRecord")]
    public partial class RecordDetail : ContentPage
    {
        Record record;
        public Record Record
        {
            get => record;
            set
            {
                record = value;
                OnPropertyChanged();
            }
        }
        async void OnEditButtonClicked(object sender, EventArgs args)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "TheRecord", Record }
            };
            await Shell.Current.GoToAsync($"records/new", navigationParameter);
        }
        public RecordDetail()
        {
            InitializeComponent();
            BindingContext = this;

        }
    }

}
