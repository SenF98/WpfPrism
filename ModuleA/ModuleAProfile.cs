using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleA
{
    public class ModuleAProfile :IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA,ViewAViewModel>();
            containerRegistry.RegisterDialog<ViewD,ViewDViewModel>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
    }
}
