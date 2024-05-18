using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using WpfPrism.Views;

namespace WpfPrism.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        public DelegateCommand<string> OpenCommand { get; private set; }

        public DelegateCommand BackCommand { get; private set; }

        public DelegateCommand<string> OpenDialogCommand {get; private set; }

        private IRegionNavigationJournal _journal;

        public MainViewModel(IRegionManager regionManager,IDialogService dialogService)
        {
            OpenCommand = new DelegateCommand<string>(Open);
            BackCommand = new DelegateCommand(Back);
            OpenDialogCommand = new DelegateCommand<string>(OpenDialog);
            this._regionManager = regionManager;
            this._dialogService = dialogService;
        }

        private void OpenDialog(string obj)
        {
            var keys = new DialogParameters();
            keys.Add("Title","测试弹窗");
            _dialogService.ShowDialog(obj,keys,callback=>
            {
                if(callback.Result == ButtonResult.OK)
                {
                    var result = callback.Parameters.GetValue<string>("Value");
                }
            });
        }

        private void Back()
        {
            if (_journal != null && _journal.CanGoBack)
                _journal.GoBack();
        }

        private void Open(string obj)
        {
            var keys = new NavigationParameters();
            keys.Add("Title", "Hello");
            _regionManager.Regions["ContentRegion"].RequestNavigate(obj, callBack =>
            {
                if ((bool)callBack.Result)
                {
                    _journal = callBack.Context.NavigationService.Journal;
                }
            }, keys);
        }
    }
}