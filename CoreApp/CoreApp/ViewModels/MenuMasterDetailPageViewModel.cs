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
    public class MenuMasterDetailPageViewModel:BaseViewModel
    {
        public ObservableCollection<PageMaster> Pages { get; set; }
        private PageMaster selectPage;

        public PageMaster SelectPage
        {
            get { return selectPage; }
            set { 
                selectPage = value;
                if (selectPage!=null)
                {
                    NavigateCommand = new DelegateCommand(async () => {
                        await NavigateTo(selectPage.UrlPage);
                    });
                    NavigateCommand.Execute();
                }
            }
        }

        public DelegateCommand NavigateCommand { get; set; }
        public ClsUser User { get; set; }
        public MenuMasterDetailPageViewModel(INavigationService inavigationServices, IPageDialogService dialogService, ApiCore apiCore) : base(inavigationServices, dialogService, apiCore)
        {
            Pages = new ObservableCollection<PageMaster>
            {
                new PageMaster(){
                NamePage = "Home",
                UrlPage = $"{ConfigPage.NavigationPage}{ConfigPage.HomePage}"
                },
                new PageMaster(){
                NamePage = "Clientes",
                UrlPage = $"{ConfigPage.NavigationPage}{ConfigPage.ClientsPage}"
                },
                new PageMaster(){
                NamePage = "Empleados",
                },
                  new PageMaster(){
                NamePage ="Registrar Empleados" ,
                UrlPage = $"{ConfigPage.NavigationPage}{ConfigPage.RegisterEmployeePage}"

                },new PageMaster(){
                NamePage = "Usuarios",
                },
                new PageMaster(){
                  NamePage = "Registrar usuarios",
                UrlPage = $"{ConfigPage.NavigationPage}{ConfigPage.RegisterUserPage}"
                },new PageMaster(){
                NamePage = "Logs",
                },
            };
            

        } 
        async Task NavigateTo(string page)
        {
            await navigationService.NavigateAsync(new Uri($"{page}",UriKind.Relative));
        }
    }
}
