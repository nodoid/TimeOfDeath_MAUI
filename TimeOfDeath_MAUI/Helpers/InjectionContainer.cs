using CommunityToolkit.Mvvm.Messaging;
using TimeOfDeath_MAUI.ViewModels;
using TimeOfDeath_MAUI.Interfaces;
using TimeOfDeath_MAUI.Services;

namespace TimeOfDeath_MAUI.Helpers
{
    public static class InjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var i = new ServiceCollection();

            i.AddSingleton<IMessenger>(WeakReferenceMessenger.Default).
                AddSingleton<ILocalize, Localize>().
                AddSingleton<ICalcTOD, CalcTOD>();

            services = i;

            return services;
        }

        [Obsolete]
        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<BaseViewModel>();
            services.AddTransient<BasicInfoViewModel>();
            services.AddTransient<ConditionsViewModel>();
            services.AddTransient<ResultsViewModel>();
            services.AddTransient<ErrorsViewModel>();

            return services;
        }
    }
}
