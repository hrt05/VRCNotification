using Velopack;

namespace VRCNotification
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            // インストール／アンインストール時の処理（ショートカット作成など）を担当するため、一番最初に呼ぶ
            VelopackApp.Build().Run();

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
