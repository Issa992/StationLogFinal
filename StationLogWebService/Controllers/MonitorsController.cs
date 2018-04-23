using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StationLogWebService;

namespace StationLogWebService.Controllers
{
    public class MonitorsController : ApiController
    {
        private Model1DBContext db = new Model1DBContext();

        // GET: api/Monitors
        public IQueryable<Monitor> GetMonitors()
        {
            return db.Monitors;
        }

        // GET: api/Monitors/5
        [ResponseType(typeof(Monitor))]
        public IHttpActionResult GetMonitor(int id)
        {
            Monitor monitor = db.Monitors.Find(id);
            if (monitor == null)
            {
                return NotFound();
            }

            return Ok(monitor);
        }

        // PUT: api/Monitors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonitor(int id, Monitor monitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monitor.MonitorId)
            {
                return BadRequest();
            }

            db.Entry(monitor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Monitors
        [ResponseType(typeof(Monitor))]
        public IHttpActionResult PostMonitor(Monitor monitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monitors.Add(monitor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MonitorExists(monitor.MonitorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = monitor.MonitorId }, monitor);
        }

        // DELETE: api/Monitors/5
        [ResponseType(typeof(Monitor))]
        public IHttpActionResult DeleteMonitor(int id)
        {
            Monitor monitor = db.Monitors.Find(id);
            if (monitor == null)
            {
                return NotFound();
            }

            db.Monitors.Remove(monitor);
            db.SaveChanges();

            return Ok(monitor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonitorExists(int id)
        {
            return db.Monitors.Count(e => e.MonitorId == id) > 0;
        }
    }
}