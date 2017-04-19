using System.Windows;
using CampusSystem.Data;

namespace CampusSystem.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Helper.InitDb();
            base.OnStartup(e);
        }
    }
}
