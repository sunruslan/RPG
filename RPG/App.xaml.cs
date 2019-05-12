using RPG.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace RPG
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(typeof(ViewLauncher), new ViewLauncher(Container));
        }

        protected override void OnInitialized()
        {
            Container.Resolve<ViewLauncher>().ShowMainWindow();
        }
    }
}
