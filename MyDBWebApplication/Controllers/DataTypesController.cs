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
    [Route("api/controller")]
    [ApiController]
    public class DataTypesController : Controller
    {
        private readonly DBDBContext _context;

        public DataTypesController(DBDBContext context)
        {
            _context = context;
        }
        /*
        // GET: DataTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.DataTypes.ToListAsync());
        }

        // GET: DataTypes/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DataTypes == null)
            {
                return NotFound();
            }

            var dataType = await _context.DataTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataType == null)
            {
                return NotFound();
            }

            return View(dataType);
        }

        // GET: DataTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DataType dataType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataType);
        }

        // GET: DataTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DataTypes == null)
            {
                return NotFound();
            }

            var dataType = await _context.DataTypes.FindAsync(id);
            if (dataType == null)
            {
                return NotFound();
            }
            return View(dataType);
        }

        // POST: DataTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DataType dataType)
        {
            if (id != dataType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataTypeExists(dataType.Id))
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
            return View(dataType);
        }

        // GET: DataTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DataTypes == null)
            {
                return NotFound();
            }

            var dataType = await _context.DataTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataType == null)
            {
                return NotFound();
            }

            return View(dataType);
        }

        // POST: DataTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataTypes == null)
            {
                return Problem("Entity set 'DBDBContext.DataTypes'  is null.");
            }
            var dataType = await _context.DataTypes.FindAsync(id);
            if (dataType != null)
            {
                _context.DataTypes.Remove(dataType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */
        private bool DataTypeExists(int id)
        {
          return _context.DataTypes.Any(e => e.Id == id);
        }

        
        // GET: api/DataTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataType>>> GetDataTypes()
        {
            return await _context.DataTypes.ToListAsync();
        }

        // GET: api/DataTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataType>> GetDataType(int id)
        {
            var dataType = await _context.DataTypes.FindAsync(id);

            if (dataType == null)
            {
                return NotFound();
            }

            return dataType;
        }

        // PUT: api/DataTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataType(int id, DataType dataType)
        {
            if (id != dataType.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataTypeExists(id))
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

        // POST: api/DataTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataType>> PostDataType(DataType dataType)
        {
            _context.DataTypes.Add(dataType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataType", new { id = dataType.Id }, dataType);
        }

        // DELETE: api/DataTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataType(int id)
        {
            var dataType = await _context.DataTypes.FindAsync(id);
            if (dataType == null)
            {
                return NotFound();
            }

            _context.DataTypes.Remove(dataType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
