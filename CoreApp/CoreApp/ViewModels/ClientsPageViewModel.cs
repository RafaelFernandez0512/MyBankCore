using CoreApp.Helpers;
using CoreApp.Models;
using CoreApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
    public class ClientsPageViewModel:BaseViewModel
    {
        public DelegateCommand AddClientCommand { get; set; }
        public ObservableCollection<ClsClient> Clients { get; set; }
        public DelegateCommand LoadList { get; set; }
        public ClientsPageViewModel(INavigationService navigationServices, IPageDialogService dialogService, IApiCore apiCore) : base(navigationServices, dialogService, apiCore) {
            LoadList = new DelegateCommand(async () =>
            {
                await LoadClients();
            });
            LoadList.Execute();
            AddClientCommand = new DelegateCommand(async () =>
            {
               await navigationService.NavigateAsync(new Uri(ConfigPage.RegisterClientPage, UriKind.Relative));
            });
        }
        async Task LoadClients() 
        {

           var client = await apiCore.GetClient();
            Clients = new ObservableCollection<ClsClient>(client);
        }
    }
}
