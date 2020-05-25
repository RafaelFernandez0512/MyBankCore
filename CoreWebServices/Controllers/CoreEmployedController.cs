using CoreWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreWebServices.Controllers
{
    public class CoreEmployedController : ApiController
    {
        private coredbEntities db = new coredbEntities();
        [HttpPost]
        [ActionName("AddEmployed")]
        public HttpResponseMessage AddEmployed(TLSEmpleado employed)
        {
            var transaction = db.Database.BeginTransaction();
            try
            { 
                var insert = db.InsertEmpleados(employed.Nombre, employed.Apellido, employed.Email,employed.Cedula,employed.Fecha,employed.IdDepartamento,employed.Puesto,employed.Horario,employed.Sueldo,employed.Perfil,employed.Sexo);
              
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"{insert} row affected", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the employed is saved");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $" Employed 0 row affected", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }


        [HttpPut]
        [ActionName("UpdateEmployed")]
        public HttpResponseMessage UpdateEmployed(TLSEmpleado employed)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                var update = db.UpdateEmpleados(employed.Nombre, employed.Apellido, employed.Email, employed.Cedula, employed.Fecha, employed.IdDepartamento,employed.Puesto,employed.Horario,employed.Sueldo,employed.Perfil);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"{update} row update", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the employed is update");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $" Employed 0 row update", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }
        [HttpDelete]
        [ActionName("DeleteEmployed")]
        public HttpResponseMessage DeleteEmployed(int cedula)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                var delete = db.DeleteEmpleado(cedula);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $" Employed {delete} row delete", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the employed is delete");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"Employed 0 row delete", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }
        [HttpGet]
        [ActionName("GetEmployedId")]
        public IHttpActionResult GetIDEmployed(int cedula)
        {
            TLSEmpleado cliente = null;
            try
            {
                cliente = db.TLSEmpleadoes.ToList().Find(e => e.Cedula == cedula);

            }
            catch (Exception)
            {

                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $" Employed not fount", $"{EnumLevelLogs.DEBUG}");
            }
            if (cliente != null)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(User);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $" Employed {cliente.Cedula} found", $"{EnumLevelLogs.DEBUG}");
                return Json(json);
            }
            return Ok("No employed found");
        }
        [HttpGet]
        [ActionName("GetEmployed")]
        public IEnumerable<TLSEmpleado> GetResult()
        {
            try
            {
                var employeds = db.TLSEmpleadoes.ToList();
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $" Employed select {employeds.Count} row", $"{EnumLevelLogs.DEBUG}");
                return employeds;
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $" Employed not select row", $"{ex.Message}");
                return null;
            }
        }
    }
}
