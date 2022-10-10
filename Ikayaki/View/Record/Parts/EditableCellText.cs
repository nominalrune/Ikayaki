using Microsoft.Maui.Controls;
using Reactive.Bindings;
namespace Ikayaki.View.Record.Parts;

public class EditableCellText : ContentView
{
    public Label LabelView=new();
    public Entry EditView=new();
    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value),
        typeof(string),
        typeof(EditableCellText),
        string.Empty
        );
    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public static readonly BindableProperty IsEditProperty = BindableProperty.Create(
        nameof(IsEdit),
        typeof(bool),
        typeof(EditableCellText),
        false
        );
    public bool IsEdit
    {
        get => (bool)GetValue(IsEditProperty);
        set
        {
            SetValue(IsEditProperty, value);
            OnPropertyChanged();
            OnSwitch();
        }
    }
    private void OnSwitch()
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
    public EditableCellText()
    {
        LabelView.BindingContext = this;
        EditView.BindingContext = this;
        LabelView.SetBinding(Label.TextProperty, "Value");
        EditView.SetBinding(Entry.TextProperty, "Value");
        Content = LabelView;
    }
}