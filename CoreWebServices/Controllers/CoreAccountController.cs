using CoreWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreWebServices.Controllers
{
    public class CoreAccountController : ApiController
    {
        private coredbEntities db = new coredbEntities();
        [HttpPost]
        [ActionName("AddAccount")]
        public HttpResponseMessage AddCuenta(TLSCuenta cuenta)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {

                var insert = db.InsertCuenta(cuenta.IDCuenta, cuenta.Cedula, cuenta.Balance, cuenta.TipoCuenta, DateTime.Now);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"Account {insert} row affected", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the account is saved");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"Account 0 row affected", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }


        [HttpPut]
        [ActionName("UpdateAccount")]
        public HttpResponseMessage UpdateAccount(TLSCuenta cuenta)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                var update = db.UpdateCuenta(cuenta.IDCuenta, cuenta.Cedula, cuenta.Balance, cuenta.TipoCuenta, cuenta.FechaActualizacion);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"Account {update} row update", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the Account is update");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"Account0 row update", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }
        [HttpDelete]
        [ActionName("DeleteAccount")]
        public HttpResponseMessage DeleteAccount(int idAccount)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                var delete = db.DeleteCuenta(idAccount);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"Account {delete} row delete", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the Account is delete");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"0 row delete", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }
        [HttpGet]
        [ActionName("GetAccountId")]
        public IHttpActionResult GetAccountId(int idAccount)
        {
            TLSCuenta cuenta = null;
            try
            {
                cuenta = db.TLSCuentas.ToList().Find(e => e.IDCuenta == idAccount);

            }
            catch (Exception)
            {

                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"not fount", $"{EnumLevelLogs.DEBUG}");
            }
            if (cuenta != null)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(User);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"{cuenta.IDCuenta} found", $"{EnumLevelLogs.DEBUG}");
                return Json(json);
            }
            return Ok("No Account found");
        }
        [HttpGet]
        [ActionName("GetAccount")]
        public IEnumerable<TLSCuenta> GetAccount()
        {
            try
            {
                var accounts = db.TLSCuentas.ToList();
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"select Account {accounts.Count} row", $"{EnumLevelLogs.DEBUG}");
                return accounts;
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"not select Account row", $"{ex.Message}");
                return null;
            }
        }
    }
}
