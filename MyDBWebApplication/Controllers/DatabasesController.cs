using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyDBWebApplication;
using MyDBWebApplication.Models;

namespace MyDBWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabasesController : Controller
    {
        private readonly DBDBContext _context;

        public DatabasesController(DBDBContext context)
        {
            _context = context;
        }

        /*
        // GET: Databases
        public async Task<IActionResult> Index()
        {
              return View(await _context.Databases.ToListAsync());
        }

        // GET: Databases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Databases == null)
            {
                return NotFound();
            }

            var database = await _context.Databases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (database == null)
            {
                return NotFound();
            }

            return View(database);
           // return RedirectToAction("IndexDB", "Tables", new { id = database.Id, name = database.Name });
        }

        // GET: Databases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Databases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Database database)
        {
            if (ModelState.IsValid)
            {
                _context.Add(database);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(database);
        }

        // GET: Databases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Databases == null)
            {
                return NotFound();
            }

            var database = await _context.Databases.FindAsync(id);
            if (database == null)
            {
                return NotFound();
            }
            return View(database);
        }

        // POST: Databases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Database database)
        {
            if (id != database.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(database);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatabaseExists(database.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(database);
        }

        // GET: Databases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Databases == null)
            {
                return NotFound();
            }

            var database = await _context.Databases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (database == null)
            {
                return NotFound();
            }

            return View(database);
        }

        // POST: Databases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Databases == null)
            {
                return Problem("Entity set 'DBDBContext.Databases'  is null.");
            }
            var database = await _context.Databases.FindAsync(id);
            if (database != null)
            {
                _context.Databases.Remove(database);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
*/
       
        private bool DatabaseExists(int id)
        {
          return _context.Databases.Any(e => e.Id == id);
        }



        // GET: api/databases
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Database>>> GetDatabases()
        {
            return await _context.Databases.ToListAsync();
        }

        // GET: api/Databases/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Database>> GetDatabase(int id)
        {
            var database = await _context.Databases.FindAsync(id);

            if (database == null)
            {
                return NotFound();
            }

            return database;
        }

        // PUT: api/Databases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDatabase(int id, Database database)
        {
            if (id != database.Id)
            {
                return BadRequest();
            }

            _context.Entry(database).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatabaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Databases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Database>> PostDatabase(Database database)
        {
            _context.Databases.Add(database);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatabase", new { id = database.Id }, database);
        }

        // DELETE: api/Databases/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDatabase(int id)
        {
            var database = await _context.Databases.FindAsync(id);
            if (database == null)
            {
                return NotFound();
            }

            _context.Databases.Remove(database);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
