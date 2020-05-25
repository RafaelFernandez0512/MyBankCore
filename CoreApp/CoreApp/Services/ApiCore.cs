using CoreApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class ApiCore: IApiCore
    {

        public async Task PutClient(ClsClient client)
        {
            var postRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await postRequest.PutClient(client);
        }
        public async Task DeleteClient(int cedula)
        {
            var deleteRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await deleteRequest.DeleteClient(cedula);
        }
        public async Task<ClsClient> FindClient(int cedula)
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            var client = await getRequest.FindClient(cedula);
            return client;
        }

        public async Task PostAccount(ClsAccount account)
        {
            var postRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await postRequest.PostAccount(account);
        }
        public async Task PutAccount(ClsAccount account)
        {
            var postRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await postRequest.PutAccount(account);
        }
        public async Task DeleteAccount(int idAccount)
        {
            var deleteRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await deleteRequest.DeleteAccount(idAccount);
        }
        public async Task<ClsAccount> FindAccount(int idAccount)
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            var account = await getRequest.FindAccount(idAccount);
            return account;
        }

        public async Task PostEmployee(ClsEmployee employee)
        {
            var postRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await postRequest.PostEmployee(employee);
        }
        public async Task PutEmployee(ClsEmployee employee)
        {
            var postRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await postRequest.PutEmployee(employee);
        }
        public async Task DeleteEmployee(int cedula)
        {
            var deleteRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await deleteRequest.DeleteEmployee(cedula);
        }
        public async Task<ClsEmployee> FindEmployee(int cedula)
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            var employee = await getRequest.FindEmployee(cedula);
            return employee;
        }
        public async Task PostUser(ClsUser user)
        {
            var postRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await postRequest.PostUser(user);
        }
        public async Task PutUser(ClsUser user)
        {
            var postRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await postRequest.PutUser(user);
        }
        public async Task DeleteUser(int cedula)
        {
            var deleteRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await deleteRequest.DeleteUser(cedula);
        }
        public async Task<ClsUser> FindUser(int cedula)
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            var User = await getRequest.FindUser(cedula);
            return User;
        }

        public async Task PostClient([Body] ClsClient clsClient, int idAccount, double balance, string tipoCuenta)
        {
            var postRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await postRequest.PostClient(clsClient, idAccount, balance, tipoCuenta);
        }

        public async Task<List<ClsClient>> GetClient()
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            var client = await getRequest.GetClient();
            return client;
        }

        public async Task<List<ClsEmployee>> GetEmployee()
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            var employee = await getRequest.GetEmployee();
            return employee;
        }

        public async Task<List<ClsUser>> GetUser()
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            var User = await getRequest.GetUser();
            return User;
        }

        public async Task<List<ClsAccount>> GetAccount()
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            var account = await getRequest.GetAccount();
            return account;
        }

        public async Task<List<ClsLog4Core>> GetLogs()
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            var logs = await getRequest.GetLogs();
            return logs;
        }

        public async Task PostTransaction([Body] ClsTransaction transaction)
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await getRequest.PostTransaction(transaction);
        }

        public async Task PostWithdrawal(int cuentaRetiro, float monto, string tipoTransaction)
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await getRequest.PostWithdrawal(cuentaRetiro, monto, tipoTransaction);
        }

        public async Task PostDeposit(long cedula, int cuentaReceptor, float monto, string tipoTransaction, string descripcion)
        {
            var getRequest = RestService.For<IApiCore>(ConfigApi.ApiUrl);
            await getRequest.PostDeposit(cedula,cuentaReceptor,monto,tipoTransaction,descripcion);
        }
    }
}
