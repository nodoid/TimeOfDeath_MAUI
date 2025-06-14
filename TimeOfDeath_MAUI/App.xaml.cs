using System.Globalization;
using TimeOfDeath_MAUI.Interfaces;

namespace TimeOfDeath_MAUI
{
    public partial class App : Application
    {
        public static IServiceProvider Service { get; set; }
        public static App Self { get; private set; }
        public static Size ScreenSize { get; private set; }

        public App()
        {
            App.Self = this;

            Service = Startup.Init();

            ScreenSize = new Size(DeviceDisplay.Current.MainDisplayInfo.Width, DeviceDisplay.Current.MainDisplayInfo.Height);

            InitializeComponent();

            var netLanguage = Service.GetService<ILocalize>().GetCurrent();
            Languages.Resources.Culture = new CultureInfo(netLanguage);
            Service.GetService<ILocalize>().SetLocale();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.TabbedPage());
        }
    }
}