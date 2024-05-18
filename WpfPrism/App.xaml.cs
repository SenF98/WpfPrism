using Prism.DryIoc;
using System.Configuration;
using System.Data;
using System.Windows;
using ModuleA;
using ModuleB;
using Prism.Ioc;
using Prism.Modularity;
using WpfPrism.Views;

namespace WpfPrism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterSingleton<>();  //注册一些页面
            // containerRegistry.RegisterForNavigation<ViewA>();
            // containerRegistry.RegisterForNavigation<ViewB>();
            // containerRegistry.RegisterForNavigation<ViewC>();
            containerRegistry.RegisterForNavigation<ViewC>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog()
        //    {
        //        ModulePath = @".\Modules"
        //    };
        //}
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleAProfile>();
            moduleCatalog.AddModule<ModuleBProfile>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }

}
