namespace TimeOfDeath_MAUI.Views;

public partial class ConditionsView : ContentPage
{
	public ConditionsView()
	{
		InitializeComponent();
	}

    private void Bodycondition_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        if (this.IsLoaded)
        {
            var picker = (Picker)sender;
            switch (picker.ClassId)
            {
                case "bodycondition":
                    ViewModel.Body = picker.SelectedIndex;
                    break;
                case "inair":
                    ViewModel.Air = picker.SelectedIndex;
                    break;
                case "inwater":
                    ViewModel.Water = picker.SelectedIndex;
                    break;
                case "pulled":
                    ViewModel.WaterMove = picker.SelectedIndex;
                    break;
            }

            ViewModel.CanDoProgress();
        }
    }
}