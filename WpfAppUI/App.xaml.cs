using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppUI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static DialogCoordinator DialogCoordinator = new DialogCoordinator();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 设置默认主题颜色和字体
            ThemeManager.ChangeAppStyle(Application.Current,
                            ThemeManager.GetAccent("pink"),
                            ThemeManager.GetAppTheme("BaseLight"));
        }
    }
}
