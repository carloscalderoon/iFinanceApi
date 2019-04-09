using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iFinanceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iFinanceAPI.Controllers
{
    [Route("api/[controller]")]
    public class MonthlyIncomesController : Controller
    {
        //connect
        DbModel db;

        public MonthlyIncomesController(DbModel db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<MonthlyIncome> Get()
        {
            return db.MonthlyIncomes.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var monthlyIncomes = db.MonthlyIncomes.SingleOrDefault(p => p.IncomeID == id);

            if (monthlyIncomes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(monthlyIncomes);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]MonthlyIncome monthlyIncome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.MonthlyIncomes.Add(monthlyIncome);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = monthlyIncome.IncomeID }, monthlyIncome);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]MonthlyIncome monthlyIncome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(monthlyIncome).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = monthlyIncome.IncomeID }, monthlyIncome);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var monthlyIncome = db.MonthlyIncomes.SingleOrDefault(p => p.IncomeID == id);
            if (monthlyIncome == null)
            {
                return NotFound();
            }
            else
            {
                db.MonthlyIncomes.Remove(monthlyIncome);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
