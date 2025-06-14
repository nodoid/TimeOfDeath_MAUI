using CommunityToolkit.Mvvm.ComponentModel;

namespace TimeOfDeath_MAUI.ViewModels
{
    public partial class ResultsViewModel: BaseViewModel
    {
        [ObservableProperty]
        string dateDead;


        [ObservableProperty]
        string timeDead;

        public void Init()
        {
            DateDead = DateOfDeath.Date.ToString("dd/MM/yyyy");
            TimeDead = $"{TimeOfDeath.Hours}:{TimeOfDeath.Minutes}";
        }
    }
}
