using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleGlossary.Models;
using Microsoft.EntityFrameworkCore;
using SimpleGlossary.Models.BindingTargets;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace SimpleGlossary.Controllers
{
    [Route("api/entries")]
    [Authorize(Roles="Admin")]
    [ValidateAntiForgeryToken]
    public class EntryValuesController : Controller
    {
        private DataContext context;

        public EntryValuesController(DataContext ctx)
        {
            context = ctx;
        }

        // GET: api/entries
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetEntries(string category,string search,
            bool sorted=false,bool metadata=false)
        {
            IQueryable<Entry> query = context.Entries;
            if (!string.IsNullOrWhiteSpace(category))
            {
                string catLower = category.ToLower();
                query = query.Where(p => p.Category.ToLower().Contains(catLower));
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(p => p.Term.ToLower().Contains(searchLower)
                || p.Definition.ToLower().Contains(searchLower));
            }

            if (sorted&&HttpContext.User.IsInRole("Admin"))
            {
                List<Entry> data = query.ToList();
                return metadata ? CreateMetadata(data) : Ok(data);
            }
            else
            {
                return metadata ? CreateMetadata(query) : Ok(query);
            }
        }

        private IActionResult CreateMetadata(IEnumerable<Entry> products)
        {
            return Ok(new
            {
                data = products.OrderBy(e=>e.Term),
                categories = context.Entries.Select(p => p.Category)
                .Distinct().OrderBy(c => c)
            });
        }

        // GET: api/entries/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public Entry GetProduct(long id)
        {
            //System.Threading.Thread.Sleep(5000);
            IQueryable<Entry> query = context.Entries;

            Entry result = query.First(e => e.Id == id);

            return result;
        }

        // POST: api/entries
        [HttpPost]
        public IActionResult CreateEntry([FromBody]EntryData pdata)
        {
            if (ModelState.IsValid)
            {
                Entry e = pdata.Entry;
                context.Add(e);
                context.SaveChanges();
                return Ok(e.Id);

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/entries/5
        [HttpPut("{id}")]
        public IActionResult ReplaceEntry(long id, [FromBody]EntryData pdata)
        {
            if (ModelState.IsValid)
            {
                Entry e = pdata.Entry;
                e.Id = id;
                context.Update(e);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/entries/5
        [HttpDelete("{id}")]
        public void DeleteEntry(long id)
        {
            context.Remove(new Entry { Id = id });
            context.SaveChanges();
        }
    }
}
