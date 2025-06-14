using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TimeOfDeath_MAUI.ViewModels;

public partial class BasicInfoViewModel : BaseViewModel
{
    [ObservableProperty] 
    DateTime death = DateTime.Now;

    [ObservableProperty] 
    TimeSpan timeDeath = DateTime.Now.TimeOfDay;

    [ObservableProperty] 
    double bodyTemp;

    [ObservableProperty] 
    double surroundTemp;

    [ObservableProperty]
    double bodyWgt;

    [ObservableProperty] 
    bool isImperial;

    public DateTime MaxDate { get; set; } = DateTime.Now;
    public ObservableCollection<string> Units { get; set; } = ["in Kg", "in lbs"];

    [RelayCommand]
    public void CalculateWeight()
    {
        var weight = BodyWgt != 0d ? BodyWgt : 0;
        weight *= !IsImperial ? 6.35029318 : 1;
        BodyWeight = weight;
    }

    [RelayCommand]
    public void DateChanged(DateTime date)
    {
        DateOfDeath = Death = date;
    }

    [RelayCommand]
    public void TimeChanged(TimeSpan time)
    {
        TimeOfDeath = TimeDeath = time;
    }



}