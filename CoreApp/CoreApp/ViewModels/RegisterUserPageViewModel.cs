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
    public class RegisterUserPageViewModel : BaseViewModel
    {
        public ClsUser User { get; set; } = new ClsUser();
        public DelegateCommand SaveUserCommand { get; set; }
        public List<UserAccountType> AccountTypes { get; set; }
        public UserAccountType selectAccountType;

        public UserAccountType SelectAccountType
        {
            get { return selectAccountType; }
            set { selectAccountType = value; }
        }

        public RegisterUserPageViewModel(INavigationService inavigationServices, IPageDialogService dialogService, IApiCore apiCore) : base(inavigationServices, dialogService, apiCore)
        {
            AccountTypes = new List<UserAccountType>()
            {
                new UserAccountType()
                {
                    ID = 1,
                    Name = "Admin"
                },

                new UserAccountType()
                {
                    ID = 2,
                    Name = "Empleado"
                },

                new UserAccountType()
                {
                    ID = 1,
                    Name = "Cliente"
                },
            };

            SaveUserCommand = new DelegateCommand(async () =>
            {
                User.TipoCuenta = SelectAccountType.Name;
                await InsertUser(User);
            });
        }
        
        async Task InsertUser(ClsUser user)
        {
            try
            {
                await apiCore.PostUser(user);
            }
            catch (Exception ex)
            {
                await dialogService.DisplayAlertAsync("There was an error", $"{ex.Message}", "Ok");
            }
        }
    
    }
}
