using CoreWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreWebServices.Controllers
{
    public class CoreMoveTransactionController : ApiController
    {
        private coredbEntities db = new coredbEntities();
        [HttpGet]
        [ActionName("GetMoving")]
        public IEnumerable<TLSMovimiento> GetTransaction()
        {
            try
            {
                var moves = db.TLSMovimientos.ToList();
                db.InsertLogs(EnumLevelLogs.DEBUG.ToString(), $" Transaction select {moves.Count} row", $"{EnumLevelLogs.DEBUG}");
                return moves;
            }
            catch (Exception ex)
            {
                db.InsertLogs(EnumLevelLogs.ERROR.ToString(), $"not select moves row", $"{ex.Message}");
                return null;
            }
        }
        
    }
}
