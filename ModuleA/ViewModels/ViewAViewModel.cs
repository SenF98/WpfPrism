using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase, IConfirmNavigationRequest
    {
        public ViewAViewModel()
        {
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("Title"))
                Title = navigationContext.Parameters.GetValue<string>("Title");
        }

        /// <summary>
        /// 每次重新导航时，该实例是否重新创建，是否重用原来的实例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 拦截导航请求 比如从当前页切换到B页面
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            var result = MessageBox.Show("确认导航？","温馨提示",MessageBoxButton.YesNo) == MessageBoxResult.Yes;
            continuationCallback(result);
        }
    }
}