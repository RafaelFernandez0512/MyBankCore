using CoreWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace CoreWebServices.Controllers
{
    public class CoreClientController : ApiController
    {
      private coredbEntities db = new coredbEntities();
      [HttpPost]
      [ActionName("AddClient")]
      public HttpResponseMessage Add_Client(TLSCliente cliente,int idAccount,double balance,string tipoCuenta)
      {
            var transaction = db.Database.BeginTransaction();
            try
            {
                TLSCuenta cuenta = new TLSCuenta() {
                    IDCuenta = idAccount,
                    Cedula = cliente.Cedula,
                    Balance = balance,
                    TipoCuenta = tipoCuenta
                };

                var insert = db.InsertCliente(cliente.Nombre, cliente.Apellido, cliente.Email, cliente.Fecha, cliente.EmpresaTrabajo, cliente.PuestoTrabajo, cliente.Sueldo, cliente.Cuenta, cliente.Cedula, cliente.Sexo);
                var insertAccount = db.InsertCuenta(cuenta.IDCuenta, cuenta.Cedula, cuenta.Balance, cuenta.TipoCuenta, DateTime.Now);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"Client {insert} row affected",$"{EnumLevelLogs.DEBUG}");
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"Account {insertAccount} row affected", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, $"the client and account is saved {ok}");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"0 row affected", $"{ex.Message}");
                transaction.Rollback(); 
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
       }


        [HttpPut]
        [ActionName("GetUpdate")]
        public HttpResponseMessage UpdateClient(TLSCliente cliente)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                var update = db.UpdateCliente(cliente.Nombre, cliente.Apellido, cliente.Email, cliente.Fecha, cliente.EmpresaTrabajo, cliente.PuestoTrabajo, cliente.Sueldo, cliente.Cuenta, cliente.Cedula);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"{update} row update", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the client is update");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"0 row update", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }
        [HttpDelete]
        [ActionName("DeleteClient")]
        public HttpResponseMessage DeleteClient(int cedula)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                var delete = db.DeleteCliente(cedula);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"{delete} row delete", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the client is delete");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"0 row delete", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }
        [HttpGet]
        [ActionName("GetClientId")]
        public IHttpActionResult GetIDClient(int cedula)
        {
            TLSCliente cliente = null;
            try
            {
                cliente = db.TLSClientes.ToList().Find(e => e.Cedula == cedula);
               
            }
            catch (Exception)
            {

                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"not fount", $"{EnumLevelLogs.DEBUG}");
            }
            if (cliente!=null)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(User);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"{cliente.Cedula}found", $"{EnumLevelLogs.DEBUG}");
                return Json(json);
            }
            return Ok("No client found");
        }
        [HttpGet]
        [ActionName("GetClients")]
        public IEnumerable<TLSCliente> GetResult()
        {
            try
            {
                var clients = db.TLSClientes.ToList();
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"select {clients.Count} row", $"{EnumLevelLogs.DEBUG}");
                return clients;
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"select row", $"{ex.Message}");
                return null;
            }
        }
    }
}
