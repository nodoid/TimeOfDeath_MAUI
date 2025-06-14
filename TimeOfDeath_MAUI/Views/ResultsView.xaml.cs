namespace TimeOfDeath_MAUI.Views;

public partial class ResultsView : ContentPage
{
	public ResultsView()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.Init();
    }
}