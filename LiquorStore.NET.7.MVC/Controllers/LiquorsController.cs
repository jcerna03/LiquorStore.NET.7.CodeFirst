using LiquorStore.NET._7.MVC.Data;
using LiquorStore.NET._7.MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.NET._7.MVC.Controllers;

public class LiquorsController : Controller
{
    private readonly LiquorStoreContext _context;

    public LiquorsController(LiquorStoreContext context)
    {
        _context = context;
    }

    // GET: Liquors
    public async Task<IActionResult> Index()
    {
        Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Liquor, Category?> liquorStoreContext = _context.Liquors.Include(l => l.Brand).Include(l => l.Category);
        return View(await liquorStoreContext.ToListAsync());
    }

    // GET: Liquors/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Liquors == null)
        {
            return NotFound();
        }

        Liquor? liquor = await _context.Liquors
                .Include(l => l.Brand)
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
        if (liquor == null)
        {
            return NotFound();
        }

        return View(liquor);
    }

    // GET: Liquors/Create
    public IActionResult Create()
    {
        ViewData["BrandItems"] = new SelectList(_context.Brands, "Id", "Name");
        ViewData["CategoryItems"] = new SelectList(_context.Categories, "Id", "Name");
        return View();
    }

    // POST: Liquors/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,Alcohol,Price,Image,BrandId,CategoryId")] Liquor liquor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(liquor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Description", liquor.BrandId);
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description", liquor.CategoryId);
        return View(liquor);
    }

    // GET: Liquors/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Liquors == null)
        {
            return NotFound();
        }

        Liquor? liquor = await _context.Liquors.FindAsync(id);
        if (liquor == null)
        {
            return NotFound();
        }
        ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Description", liquor.BrandId);
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description", liquor.CategoryId);
        return View(liquor);
    }

    // POST: Liquors/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Alcohol,Price,Image,BrandId,CategoryId")] Liquor liquor)
    {
        if (id != liquor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(liquor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiquorExists(liquor.Id))
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
        ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Description", liquor.BrandId);
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description", liquor.CategoryId);
        return View(liquor);
    }

    // GET: Liquors/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Liquors == null)
        {
            return NotFound();
        }

        Liquor? liquor = await _context.Liquors
                .Include(l => l.Brand)
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
        if (liquor == null)
        {
            return NotFound();
        }

        return View(liquor);
    }

    // POST: Liquors/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Liquors == null)
        {
            return Problem("Entity set 'LiquorStoreContext.Liquors'  is null.");
        }
        Liquor? liquor = await _context.Liquors.FindAsync(id);
        if (liquor != null)
        {
            _context.Liquors.Remove(liquor);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LiquorExists(int id)
    {
        return (_context.Liquors?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}