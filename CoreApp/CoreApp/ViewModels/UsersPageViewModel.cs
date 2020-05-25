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
    public class UsersPageViewModel : BaseViewModel
    {
        ClsUser selectedUser;
        public ObservableCollection<ClsUser> Users { get; set; }
        public DelegateCommand LoadUserList { get; set; }
        public DelegateCommand GoToRegisterUserPageCommand { get; set; }

        public ClsUser SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                if (selectedUser != null)
                    DisplaySelectedUser();
            }
        }


        public UsersPageViewModel(INavigationService navigationServices, IPageDialogService dialogService, IApiCore apiCore) : base(navigationServices, dialogService, apiCore)
        {
            LoadUserList = new DelegateCommand(async () =>
            {
                await LoadUsers();
            });
            LoadUserList.Execute();

            GoToRegisterUserPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(ConfigPage.RegisterUserPage);
            });
        }

        public async void DisplaySelectedUser()
        {
            string answer = await dialogService.DisplayActionSheetAsync($"{TextConstants.TitleText}", $"{TextConstants.SeeInfo}", $"{TextConstants.EditOptionText}");

            if (answer == TextConstants.SeeInfo)
            {
                await dialogService.DisplayAlertAsync("Usuario:", $"Nombre de usuario: {SelectedUser.Username} \nEmail: {SelectedUser.Email}", "OK");
            }

            else if (answer == TextConstants.EditOptionText)
            {
                await navigationService.NavigateAsync($"{ConfigPage.NavigationPage}{ConfigPage.RegisterUserPage}");
            }


        }

        async Task LoadUsers()
        {
            var user = await apiCore.GetUser();
            Users = new ObservableCollection<ClsUser>(user);
        }
    }
}
