using System.Threading;
using System.Windows;

namespace VRCNotification
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex _mutex;
        protected override void OnStartup(StartupEventArgs e)
        {
            bool CheckWindow;
            _mutex = new Mutex(true, "UniqueAppName_Mutex", out CheckWindow);

            if (!CheckWindow)
            {
                MessageBox.Show("このアプリケーションは起動済みです。");
                Application.Current.Shutdown();
            }

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _mutex?.ReleaseMutex();
            base.OnExit(e);
        }
    }

}
