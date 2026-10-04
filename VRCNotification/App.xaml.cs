using System.Threading;
using System.Windows;

namespace VRCNotification
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex? _mutex;
        bool CheckWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            _mutex = new Mutex(true, "UniqueAppName_Mutex", out CheckWindow);

            if (!CheckWindow)
            {
                MessageBox.Show("このアプリケーションは起動済みです。");
                Application.Current.Shutdown();
                return;
            }

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (CheckWindow)
            {
                _mutex?.ReleaseMutex();
            }
            base.OnExit(e);
        }
    }

}
