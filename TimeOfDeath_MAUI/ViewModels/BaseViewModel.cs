using CommunityToolkit.Mvvm.ComponentModel;

namespace TimeOfDeath_MAUI.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        static int partClothed;

        [ObservableProperty]
        static double airTemp;

        [ObservableProperty]
        static double waterTemp;

        [ObservableProperty] 
        int water;

        [ObservableProperty]
        static int partInAir;

        [ObservableProperty]
        static double bodyWeight;

        [ObservableProperty]
        static double bodyTemperature;
        
        [ObservableProperty]
        static double surroundTemp;

        [ObservableProperty]
        static DateTime dateOfDeath;

        [ObservableProperty]  
        static TimeSpan timeOfDeath;

        [ObservableProperty] 
        bool calcDone;
    }
}
