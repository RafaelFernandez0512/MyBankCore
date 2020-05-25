using CoreWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreWebServices.Controllers
{
    public class CoreUserController : ApiController
    {
        // GET: api/CoreUser
        private coredbEntities db = new coredbEntities();
        [HttpPost]
        [ActionName("CreateUser")]
        public HttpResponseMessage CreateUser(TLSUsuario usuario)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {

                var user = db.InsertUsuario(usuario.Username,usuario.Contraseña,usuario.Email,usuario.Cedula,usuario.TipoCuenta,usuario.Fecha);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"{user} row affected", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the user is saved");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"0 row affected", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }


        [HttpPut]
        [ActionName("UpdateEmployed")]
        public HttpResponseMessage UpdateUser(TLSUsuario usuario)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                var update = db.UpdateUsuario(usuario.Username, usuario.Contraseña, usuario.Email, usuario.Cedula, usuario.TipoCuenta, usuario.Fecha);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"{update} row update", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the user is update");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"0 row update", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }
        [HttpDelete]
        [ActionName("DeleteUser")]
        public HttpResponseMessage DeleteUser(int cedula)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                var delete = db.DeleteUsuario(cedula);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"{delete} row delete", $"{EnumLevelLogs.DEBUG}");
                var ok = db.SaveChanges();
                transaction.Commit();
                return Request.CreateResponse(HttpStatusCode.Accepted, "the user is delete");
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"0 row delete", $"{ex.Message}");
                transaction.Rollback();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, $"{ex.Message}");
            }
        }
        [HttpGet]
        [ActionName("GetUserId")]
        public IHttpActionResult GetUserId(int cedula)
        {
            TLSUsuario user = null;
            try
            {
                user = db.TLSUsuarios.ToList().Find(e => e.Cedula == cedula);

            }
            catch (Exception)
            {

                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"not fount", $"{EnumLevelLogs.DEBUG}");
            }
            if (user != null)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(User);
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"{user.Cedula}found", $"{EnumLevelLogs.DEBUG}");
                return Json(json);
            }
            return Ok("No user found");
        }
        [HttpGet]
        [ActionName("GetUser")]
        public IEnumerable<TLSUsuario> GetUser()
        {
            try
            {
                var users = db.TLSUsuarios.ToList();
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $"select {users.Count} row", $"{EnumLevelLogs.DEBUG}");
                return users;
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"select row", $"{ex.Message}");
                return null;
            }
        }
    }
}
