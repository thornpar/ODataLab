using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ODataLab.Models;
using System.Web.Http.OData;

namespace ODataLab.Controllers
{
    public class EmploymentsController : ODataController
    {
        public EmploymentsController()
        {
            
        }
        private EmploymentContext db = new EmploymentContext();

        // GET: api/Employments
        [EnableQuery]
        public IQueryable<Employment> GetEmployments()
        {
            return db.Employments;
        }

        // GET: api/Employments/5
        [ResponseType(typeof(Employment))]
        [EnableQuery]
        public async Task<IHttpActionResult> GetEmployment(int id)
        {
            Employment employment = await db.Employments.FindAsync(id);
            if (employment == null)
            {
                return NotFound();
            }

            return Ok(employment);
        }

        // PUT: api/Employments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployment(Guid id, Employment employment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employment.Id)
            {
                return BadRequest();
            }

            db.Entry(employment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentExists(id))
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

        // POST: api/Employments
        [ResponseType(typeof(Employment))]
        public async Task<IHttpActionResult> PostEmployment(Employment employment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employments.Add(employment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", null, employment);
        }

        // DELETE: api/Employments/5
        [ResponseType(typeof(Employment))]
        public async Task<IHttpActionResult> DeleteEmployment(int id)
        {
            Employment employment = await db.Employments.FindAsync(id);
            if (employment == null)
            {
                return NotFound();
            }

            db.Employments.Remove(employment);
            await db.SaveChangesAsync();

            return Ok(employment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmploymentExists(Guid id)
        {
            return db.Employments.Count(e => e.Id == id) > 0;
        }
    }
}