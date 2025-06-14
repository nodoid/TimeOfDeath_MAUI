using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using TimeOfDeath_MAUI.Interfaces;
using TimeOfDeath_MAUI.Views;
using TimeOfDeath_MAUI.Views.Popups;

namespace TimeOfDeath_MAUI.ViewModels
{
    public partial class ConditionsViewModel : BaseViewModel
    {
        ICalcTOD? CalcTod => Startup.ServiceProvider.GetService<ICalcTOD>();

        public ObservableCollection<string> BodyCondition { get; set; } =
        [
            Languages.Resources.Cond_DryNaked,
            Languages.Resources.Cond_Dry12Thin,
            Languages.Resources.Cond_Dry23Thin,
            Languages.Resources.Cond_Dry34Thin,
            Languages.Resources.Cond_Dry12Thick,
            Languages.Resources.Cond_Dry_More,
            Languages.Resources.Cond_WetNaked,
            Languages.Resources.Cond_Wet12Thin,
            Languages.Resources.Cond_Wet2Thick,
            Languages.Resources.Cond_Wet2More
        ];

        public ObservableCollection<string> AirConditions { get; set; } = [
            Languages.Resources.Cond_Still,
            Languages.Resources.Cond_Move,
            Languages.Resources.Cond_Unknown];

        public ObservableCollection<string> WetConditions { get; set; }= [
            Languages.Resources.Cond_Still,
            Languages.Resources.Cond_Move,
            Languages.Resources.Cond_WaterPull,
            Languages.Resources.Cond_Unknown
        ];

        public ObservableCollection<string> PulledWater { get; set; }= [
            Languages.Resources.Cond_Still,
            Languages.Resources.Cond_Move
        ];

        [ObservableProperty]
        int body = -1;

        [ObservableProperty]
        int air = -1;

        [ObservableProperty]
        int water = -1;

        [ObservableProperty]
        int waterMove = -1;

        [ObservableProperty] 
        bool canProgress;

        public void CanDoProgress()
        {
            CanProgress = Body != 1 && Air !=-1 && Water != -1 && WaterMove != -1;
        }

        [RelayCommand(CanExecute = nameof(CanProgress))]
        public async Task CalculateTOD()
        {
            if (AirTemp == -1)
            {
                await Mopups.Services.MopupService.Instance.PushAsync(new ErrorMessagePopupPage(
                    Languages.Resources.Error_CalcTitle,
                    Languages.Resources.Error_CalcTempNull));
                return;
            }

            if (BodyTemperature == -1)
            {
                await Mopups.Services.MopupService.Instance.PushAsync(new ErrorMessagePopupPage(
                    Languages.Resources.Error_CalcTitle,
                    Languages.Resources.Error_TempBodyNull));
                return;
            }

            if (BodyTemperature < SurroundTemp)
            {
                await Mopups.Services.MopupService.Instance.PushAsync(new ErrorMessagePopupPage(
                    Languages.Resources.Error_CalcTitle,
                    Languages.Resources.Error_TempDifference));
                return;
            }

            if (BodyWeight <= 0)
            {
                await Mopups.Services.MopupService.Instance.PushAsync(new ErrorMessagePopupPage(
                    Languages.Resources.Error_CalcTitle,
                    Languages.Resources.Error_TempBodyNull));
                return;
            }

            if (CalcTod.CalcTimeOfDeath(DateOfDeath) <= DateTime.Now) // you can't die after today
            {
                var tab = App.Self.MainPage.FindByName("tabpage") as Microsoft.Maui.Controls.TabbedPage;
                if (tab != null)
                {
                    tab.Dispatcher.Dispatch(() =>
                    {
                        tab.Children[2].IsEnabled = true;
                        tab.SelectedItem = tab.Children[2];
                        tab.InvalidateMeasure();
                    });
                }
            }
                
        }
    }
}
