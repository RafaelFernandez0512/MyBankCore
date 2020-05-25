using CoreApp.Models;
using CoreApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
    public class RegisterClientPageViewModel:BaseViewModel
    {
        public ClsClient Client { get; set; } = new ClsClient();
        public ClsAccount Account { get; set; } = new ClsAccount();
        public List<AccountType> AccountTypes { get; set; }
        public List<Gender> Genders { get; set; }
        private Gender selectGender;

        public Gender SelectGender
        {
            get { return selectGender; }
            set { selectGender = value; }
        }
        private AccountType selectAccount;

        public AccountType SelectAccount
        {
            get { return selectAccount; }
            set { selectAccount = value; }
        }
        public DelegateCommand SaveCommand { get; set; }
        public RegisterClientPageViewModel(INavigationService inavigationServices, IPageDialogService dialogService, IApiCore apiCore) : base(inavigationServices, dialogService, apiCore)
        {
            Random ran = new Random();
            AccountTypes = new List<AccountType>()
            {
                new AccountType(){ 
                ID=1,
                Name="Corriente"
                }
            };
            Genders = new List<Gender>()
            {
             new Gender(){
             Name = "Masculino"
             },
              new Gender(){
             Name = "Femenino"
             },


            };

            SaveCommand = new DelegateCommand(async()=> {
             
                Account.IdCuenta = ran.Next(999999999);
                Client.Account = Account.IdCuenta;         
                Client.Gender = SelectGender.Name;
                Account.Cedula = Client.IdCard;
                Client.Account = Account.IdCuenta;
                Account.TipoCuenta = SelectAccount.Name;
                await InsertClient(Client,Account);
            });
        }
        async Task InsertClient(ClsClient client,ClsAccount account)
        {
            try
            {
               await apiCore.PostClient(client,account.IdCuenta,account.Balance,account.TipoCuenta);
            }
            catch (Exception ex)
            {

              await  dialogService.DisplayAlertAsync("Error",$"{ex.Message}","ok");
            }
     
        }
    }
}
