namespace TimeOfDeath_MAUI.Views;

public partial class BasicDetailsView : ContentPage
{
	public BasicDetailsView()
	{
		InitializeComponent();
	}

    private void DatePicker_OnDateSelected(object? sender, DateChangedEventArgs e)
    {
        ViewModel.DateChangedCommand.Execute(e.NewDate);
    }

    private void TimePicker_OnTimeSelected(object? sender, TimeChangedEventArgs e)
    {
        ViewModel.TimeChangedCommand.Execute(e.NewTime);
    }

    private void Picker_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        if (this.IsLoaded) 
            ViewModel.IsImperial = ((Picker)sender).SelectedIndex== 1;
    }

    private void InputView_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (this.IsLoaded)
            ViewModel.CalculateWeightCommand.Execute(null);
    }
}