using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace ClientApp
{
    sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (Window.Current.Content == null)
            {
                Window.Current.Content = new Views.ShellPage();
            }
            Window.Current.Activate();
        }
    }
}
