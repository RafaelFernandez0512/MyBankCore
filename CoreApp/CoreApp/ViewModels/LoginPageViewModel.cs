using CoreApp.Helpers;
using CoreApp.Models;
using CoreApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
    public class LoginPageViewModel:BaseViewModel
    {
        public ClsUser User { get; set; } = new ClsUser();
        public DelegateCommand SignOutCommand { get; set; }
        const string Admin = "Admin";
        public LoginPageViewModel(INavigationService inavigationServices, IPageDialogService dialogService, ApiCore apiCore) : base(inavigationServices, dialogService, apiCore) {

            SignOutCommand = new DelegateCommand(async () =>
            {
                if (string.IsNullOrEmpty(User.Username)||string.IsNullOrEmpty(User.Contraseña)||User.TipoCuenta== Admin)
                {
                    await NavigateHome();
                }
                else
                {
                   await dialogService.DisplayAlertAsync("Incorrect","Username or Password is invalid","Ok");
                }
               
            });
        }
        async Task NavigateHome()
        {
            await navigationService.NavigateAsync($"{ConfigPage.MenuMasterDetailPage}{ConfigPage.HomePage}");
        }
    }
}
