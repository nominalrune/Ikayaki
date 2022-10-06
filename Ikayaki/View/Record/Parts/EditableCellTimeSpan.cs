using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using Reactive.Bindings;
namespace Ikayaki.View.Record.Parts;

public class EditableCellTimeSpan : Microsoft.Maui.Controls.ContentView
{
    public Label LabelView = new();
    public TimePicker EditView = new();
    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value),
        typeof(DateTime),
        typeof(EditableCellTimeSpan),
        new DateTime()
        );
    public DateTime Value
    {
        get => (DateTime)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    private DateTime BaseDate;
    public TimeSpan ValueInTimeSpan { 
        get => (Value - BaseDate);
    }
    public static readonly BindableProperty IsEditProperty = BindableProperty.Create(
        nameof(IsEdit),
        typeof(bool),
        typeof(EditableCellTimeSpan),
        false
        );
    public bool IsEdit
    {
        get => (bool)GetValue(IsEditProperty);
        set
        {
            SetValue(IsEditProperty, value);
            OnSwitch(new(), new());
         }
    }
    private void OnSwitch(object sender, System.EventArgs e)
    {
        if (IsEdit)
        {
            Content = EditView;
        }
        else
        {
            Content = LabelView;
        }
    }
    public EditableCellTimeSpan()
    {
        BaseDate = Value.Date;
        LabelView.BindingContext = this;
        EditView.BindingContext = this;
        LabelView.SetBinding(Label.TextProperty, "Value");
        EditView.SetBinding(TimePicker.TimeProperty, "ValueInTimeSpan");
        Content = LabelView;
    }
}