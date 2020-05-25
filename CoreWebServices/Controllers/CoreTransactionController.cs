using CoreWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreWebServices.Controllers
{
    public class CoreTransactionController : ApiController
    {
        private coredbEntities db = new coredbEntities();
        [HttpPost]
        [ActionName("AddTransaction")]
        public HttpResponseMessage AddTransaction(TLSTransaccion transaccion)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                db.InsertTransaccion(transaccion.MontoTransaccion,transaccion.IDCuentaEmisor,transaccion.IDCuentaReceptor,transaccion.TipoTransaccion,transaccion.Descripción);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"Transaccion 1 row affected", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the transaccion is saved");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"Transaccion 0 row affected", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }
        [HttpPost]
        [ActionName("CajaDeposito")]
        public HttpResponseMessage CajaDeposito(Int64 cedula,int cuentaReceptor,float monto,string tipoTransaction,string descripcion)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                var buscar = db.TLSClientes.ToList().Find(e => e.Cedula == cedula);
                var validar = db.TLSCuentas.ToList().Find(e => e.IDCuenta == cuentaReceptor);
                if (buscar==null||validar==null)
                {
                   
                    transaction.Rollback();
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"Not found");

                }
                db.InsertTransaccion(monto, buscar.Cuenta, validar.IDCuenta, tipoTransaction, descripcion);
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the transaccion is saved");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"Transaccion 0 row affected", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }
        [HttpPost]
        [ActionName("CajaRetiro")]
        public HttpResponseMessage CajaRetiro(int cuentaRetiro,float monto, string tipoTransaction)
        {   
            var transaction = db.Database.BeginTransaction();
            try
            {
                var buscar = db.TLSCuentas.ToList().Find(e => e.IDCuenta == cuentaRetiro);
                if (buscar==null)
                {
                    transaction.Rollback();
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"Not found");
                }
                db.RetiroTransaction(monto,buscar.IDCuenta, tipoTransaction);
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the transaccion is saved");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"Transaccion 0 row affected", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }

        [HttpGet]
        [ActionName("GetTransaction")]
        public IEnumerable<TLSTransaccion> GetTransaction()
        {
            try
            {
                var trans = db.TLSTransaccions.ToList();
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $" Transaction select {trans.Count} row", $"{EnumLevelLogs.DEBUG}");
                return trans;
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"not select Transaction row", $"{ex.Message}");
                return null;
            }
        }
    }
}
