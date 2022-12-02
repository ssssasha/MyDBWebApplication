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
    public class CellsController : Controller
    {
        private readonly DBDBContext _context;

        public CellsController(DBDBContext context)
        {
            _context = context;
        }

        /*
        // GET: Cells
        public async Task<IActionResult> Index()
        {
            var dBDBContext = _context.Cells.Include(c => c.Column).Include(c => c.Row);
            return View(await dBDBContext.ToListAsync());
        }

        // GET: Cells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cells == null)
            {
                return NotFound();
            }

            var cell = await _context.Cells
                .Include(c => c.Column)
                .Include(c => c.Row)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cell == null)
            {
                return NotFound();
            }

            return View(cell);
        }

        // GET: Cells/Create
        public IActionResult Create()
        {
            ViewData["ColumnId"] = new SelectList(_context.Columns, "Id", "Name");
            ViewData["RowId"] = new SelectList(_context.Rows, "Id", "Number");
            return View();
        }

        // POST: Cells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ColumnId,RowId,Value")] Cell cell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColumnId"] = new SelectList(_context.Columns, "Id", "Name", cell.ColumnId);
            ViewData["RowId"] = new SelectList(_context.Rows, "Id", "Number", cell.RowId);
            return View(cell);
        }

        // GET: Cells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cells == null)
            {
                return NotFound();
            }

            var cell = await _context.Cells.FindAsync(id);
            if (cell == null)
            {
                return NotFound();
            }
            ViewData["ColumnId"] = new SelectList(_context.Columns, "Id", "Name", cell.ColumnId);
            ViewData["RowId"] = new SelectList(_context.Rows, "Id", "Number", cell.RowId);
            return View(cell);
        }

        // POST: Cells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ColumnId,RowId,Value")] Cell cell)
        {
            if (id != cell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CellExists(cell.Id))
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
            ViewData["ColumnId"] = new SelectList(_context.Columns, "Id", "Name", cell.ColumnId);
            ViewData["RowId"] = new SelectList(_context.Rows, "Id", "Number", cell.RowId);
            return View(cell);
        }

        // GET: Cells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cells == null)
            {
                return NotFound();
            }

            var cell = await _context.Cells
                .Include(c => c.Column)
                .Include(c => c.Row)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cell == null)
            {
                return NotFound();
            }

            return View(cell);
        }

        // POST: Cells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cells == null)
            {
                return Problem("Entity set 'DBDBContext.Cells'  is null.");
            }
            var cell = await _context.Cells.FindAsync(id);
            if (cell != null)
            {
                _context.Cells.Remove(cell);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool CellExists(int id)
        {
          return _context.Cells.Any(e => e.Id == id);
        }


        // GET: api/Cells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cell>>> GetCells()
        {
            return await _context.Cells.ToListAsync();
        }

        // GET: api/Cells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cell>> GetCell(int id)
        {
            var cell = await _context.Cells.FindAsync(id);

            if (cell == null)
            {
                return NotFound();
            }

            return cell;
        }

        // PUT: api/Cells/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCell(int id, Cell cell)
        {
            if (id != cell.Id)
            {
                return BadRequest();
            }

            _context.Entry(cell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CellExists(id))
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

        // POST: api/Cells
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cell>> PostCell(Cell cell)
        {
            _context.Cells.Add(cell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCell", new { id = cell.Id }, cell);
        }

        // DELETE: api/Cells/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCell(int id)
        {
            var cell = await _context.Cells.FindAsync(id);
            if (cell == null)
            {
                return NotFound();
            }

            _context.Cells.Remove(cell);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
