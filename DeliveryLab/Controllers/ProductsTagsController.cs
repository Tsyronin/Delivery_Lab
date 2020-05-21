using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryLab.Models;

namespace DeliveryLab.Controllers
{
    public class ProductsTagsController : Controller
    {
        private readonly LabContext _context;

        public ProductsTagsController(LabContext context)
        {
            _context = context;
        }

        // GET: ProductsTags
        public async Task<IActionResult> Index()
        {
            var labContext = _context.ProductsTags.Include(p => p.Product).Include(p => p.Tag);
            return View(await labContext.ToListAsync());
        }

        // GET: ProductsTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductsTags
                .Include(p => p.Product)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productTag == null)
            {
                return NotFound();
            }

            return View(productTag);
        }

        // GET: ProductsTags/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name");
            return View();
        }

        // POST: ProductsTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,TagId")] ProductTag productTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", productTag.ProductId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", productTag.TagId);
            return View(productTag);
        }

        // GET: ProductsTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductsTags.FindAsync(id);
            if (productTag == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", productTag.ProductId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", productTag.TagId);
            return View(productTag);
        }

        // POST: ProductsTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,TagId")] ProductTag productTag)
        {
            if (id != productTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTagExists(productTag.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", productTag.ProductId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", productTag.TagId);
            return View(productTag);
        }

        // GET: ProductsTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductsTags
                .Include(p => p.Product)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productTag == null)
            {
                return NotFound();
            }

            return View(productTag);
        }

        // POST: ProductsTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTag = await _context.ProductsTags.FindAsync(id);
            _context.ProductsTags.Remove(productTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTagExists(int id)
        {
            return _context.ProductsTags.Any(e => e.Id == id);
        }
    }
}
