using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyJewelryStore.Data;
using MyJewelryStore.Models;

namespace MyJewelryStore.Controllers
{
    public class NewProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewProducts
        public async Task<IActionResult> Index()
        {
              return View(await _context.NewProduct.ToListAsync());
        }

        // GET: NewProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NewProduct == null)
            {
                return NotFound();
            }

            var newProduct = await _context.NewProduct
                .FirstOrDefaultAsync(m => m.ID == id);
            if (newProduct == null)
            {
                return NotFound();
            }

            return View(newProduct);
        }

        // GET: NewProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price,Description")] NewProduct newProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newProduct);
        }

        // GET: NewProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NewProduct == null)
            {
                return NotFound();
            }

            var newProduct = await _context.NewProduct.FindAsync(id);
            if (newProduct == null)
            {
                return NotFound();
            }
            return View(newProduct);
        }

        // POST: NewProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,Description")] NewProduct newProduct)
        {
            if (id != newProduct.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewProductExists(newProduct.ID))
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
            return View(newProduct);
        }

        // GET: NewProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NewProduct == null)
            {
                return NotFound();
            }

            var newProduct = await _context.NewProduct
                .FirstOrDefaultAsync(m => m.ID == id);
            if (newProduct == null)
            {
                return NotFound();
            }

            return View(newProduct);
        }

        // POST: NewProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NewProduct == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NewProduct'  is null.");
            }
            var newProduct = await _context.NewProduct.FindAsync(id);
            if (newProduct != null)
            {
                _context.NewProduct.Remove(newProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewProductExists(int id)
        {
          return _context.NewProduct.Any(e => e.ID == id);
        }
    }
}
