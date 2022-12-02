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

    public class ColumnsController : Controller
    {
        private readonly DBDBContext _context;

        public ColumnsController(DBDBContext context)
        {
            _context = context;
        }

        /*
        // GET: Columns
        public async Task<IActionResult> Index()
        {
            var dBDBContext = _context.Columns.Include(c => c.DataType).Include(c => c.Table);
            return View(await dBDBContext.ToListAsync());
        }

        // GET: Columns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Columns == null)
            {
                return NotFound();
            }

            var column = await _context.Columns
                .Include(c => c.DataType)
                .Include(c => c.Table)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (column == null)
            {
                return NotFound();
            }

            return View(column);
        }

        // GET: Columns/Create
        public IActionResult Create()
        {
            ViewData["DataTypeId"] = new SelectList(_context.DataTypes, "Id", "Name");
            ViewData["TableId"] = new SelectList(_context.Tables, "Id", "Name");
            return View();
        }

        // POST: Columns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TableId,DataTypeId,Name")] Column column)
        {
            if (ModelState.IsValid)
            {
                _context.Add(column);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DataTypeId"] = new SelectList(_context.DataTypes, "Id", "Name", column.DataTypeId);
            ViewData["TableId"] = new SelectList(_context.Tables, "Id", "Name", column.TableId);
            return View(column);
        }

        // GET: Columns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Columns == null)
            {
                return NotFound();
            }

            var column = await _context.Columns.FindAsync(id);
            if (column == null)
            {
                return NotFound();
            }
            ViewData["DataTypeId"] = new SelectList(_context.DataTypes, "Id", "Name", column.DataTypeId);
            ViewData["TableId"] = new SelectList(_context.Tables, "Id", "Name", column.TableId);
            return View(column);
        }

        // POST: Columns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TableId,DataTypeId,Name")] Column column)
        {
            if (id != column.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(column);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColumnExists(column.Id))
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
            ViewData["DataTypeId"] = new SelectList(_context.DataTypes, "Id", "Name", column.DataTypeId);
            ViewData["TableId"] = new SelectList(_context.Tables, "Id", "Name", column.TableId);
            return View(column);
        }

        // GET: Columns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Columns == null)
            {
                return NotFound();
            }

            var column = await _context.Columns
                .Include(c => c.DataType)
                .Include(c => c.Table)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (column == null)
            {
                return NotFound();
            }

            return View(column);
        }

        // POST: Columns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Columns == null)
            {
                return Problem("Entity set 'DBDBContext.Columns'  is null.");
            }
            var column = await _context.Columns.FindAsync(id);
            if (column != null)
            {
                _context.Columns.Remove(column);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool ColumnExists(int id)
        {
          return _context.Columns.Any(e => e.Id == id);
        }

        
        // GET: api/Columns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Column>>> GetColumns()
        {
            return await _context.Columns.ToListAsync();
        }

        // GET: api/Columns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> GetColumn(int id)
        {
            var column = await _context.Columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }

        // PUT: api/Columns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColumn(int id, Column column)
        {
            if (id != column.Id)
            {
                return BadRequest();
            }

            _context.Entry(column).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnExists(id))
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

        // POST: api/Columns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Column>> PostColumn(Column column)
        {
            _context.Columns.Add(column);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColumn", new { id = column.Id }, column);
        }

        // DELETE: api/Columns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColumn(int id)
        {
            var column = await _context.Columns.FindAsync(id);
            if (column == null)
            {
                return NotFound();
            }

            _context.Columns.Remove(column);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
