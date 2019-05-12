using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using RPG.Views;
using Unity;

namespace RPG
{
    public class ViewLauncher
    {
        public ViewLauncher(IContainerProvider container)
        {
            _container = container;
        }

        public void ShowMainWindow()
        {
            _container.Resolve<MainWindow>().Show();
            _container.Resolve<MainWindow>().Activate();
        }

        private readonly IContainerProvider _container;
    }
}
