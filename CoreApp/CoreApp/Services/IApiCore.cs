using CoreApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public interface IApiCore
    {
        [Post("/api/CoreClient?idAccount={idAccount}&balance={balance}&tipoCuenta={tipoCuenta}")]
        Task PostClient([Body]ClsClient clsClient,int idAccount, double balance, string tipoCuenta);
        [Put("/api/CoreClient")]
        Task PutClient([Body]ClsClient clsClient);
        [Delete("/api/CoreEmployed?cedula={cedula}")]
        Task DeleteClient(int cedula);
        [Get("/api/CoreClient")]
        Task<List<ClsClient>> GetClient();
        [Get("/api/CoreClient?cedula={cedula}")]
        Task<ClsClient> FindClient(int cedula);

        [Post("/api/CoreEmployed")]
        Task PostEmployee([Body]ClsEmployee  clsEmployee);
        [Put("/api/CoreEmployed")]
        Task PutEmployee([Body]ClsEmployee clsEmployee);
        [Delete("/api/CoreEmployed?cedula={cedula}")]
        Task DeleteEmployee(int cedula);
        [Get("/api/CoreEmployed")]
        Task<List<ClsEmployee>> GetEmployee();
        [Get("/api/CoreEmployed?cedula={cedula}")]
        Task<ClsEmployee> FindEmployee(int cedula);

        [Post("/api/CoreUser")]
        Task PostUser([Body]ClsUser clsUser);
        [Put("/api/CoreUser")]
        Task PutUser([Body]ClsUser clsUser);
        [Delete("/api/CoreUser?cedula={cedula}")]
        Task DeleteUser(int cedula);
        [Get("/api/CoreUser")]
        Task<List<ClsUser>> GetUser();
        [Get("/api/CoreUser?cedula={cedula}")]
        Task<ClsUser> FindUser(int cedula);

        [Post("/api/CoreAccount")]
        Task PostAccount([Body]ClsAccount account);
        [Put("/api/CoreAccount")]
        Task PutAccount([Body]ClsAccount account);

        [Delete("/api/CoreAccount?idAccount={idAccount}")]
        Task DeleteAccount(int idAccount);
        [Get("/api/CoreAccount")]
        Task<List<ClsAccount>> GetAccount();
        [Get("/api/CoreAccount?idAccount={idAccount}")]
        Task<ClsAccount> FindAccount(int idAccount);

        [Get("/api/CoreLogs")]
        Task<List<ClsLog4Core>> GetLogs();

        [Post("/api/CoreTransaction")]
        Task PostTransaction([Body]ClsTransaction transaction);
        [Post("/api/CoreTransaction?cuentaRetiro={cuentaRetiro}&monto={monto}&tipoTransaction={tipoTransaction}")]
        Task PostWithdrawal(int cuentaRetiro, float monto, string tipoTransaction);
        [Post("/api/CoreTransaction?cedula={cedula}&cuentaReceptor={cuentaReceptor}&monto={monto}&tipoTransaction={tipoTransaction}&descripcion={descripcion}")]
        Task PostDeposit(Int64 cedula, int cuentaReceptor, float monto, string tipoTransaction, string descripcion);
    }
}
