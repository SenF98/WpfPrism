using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleB
{
    public class ModuleBProfile : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewB>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
    }
}
