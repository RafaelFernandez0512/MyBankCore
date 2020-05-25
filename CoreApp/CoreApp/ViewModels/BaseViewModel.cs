using CoreApp.Services;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoreApp.ViewModels
{
    public class BaseViewModel:INotifyPropertyChanged
    {
       protected INavigationService navigationService;
        protected IPageDialogService dialogService;
       protected IApiCore apiCore;
        public BaseViewModel(INavigationService inavigationServices, IPageDialogService dialogService, IApiCore apiCore)
        {
            this.navigationService = inavigationServices;
            this.dialogService = dialogService;
            this.apiCore = apiCore;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
