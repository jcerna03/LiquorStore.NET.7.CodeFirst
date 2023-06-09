﻿using LiquorStore.NET._7.MVC.Data;
using LiquorStore.NET._7.MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.NET._7.MVC.Controllers;

public class BrandsController : Controller
{
    private readonly LiquorStoreContext _context;

    public BrandsController(LiquorStoreContext context)
    {
        _context = context;
    }

    // GET: Brands
    public async Task<IActionResult> Index()
    {
        return _context.Brands != null ?
                    View(await _context.Brands.ToListAsync()) :
                    Problem("Entity set 'LiquorStoreContext.Brands'  is null.");
    }

    // GET: Brands/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Brands == null)
        {
            return NotFound();
        }

        Brand? brand = await _context.Brands
            .FirstOrDefaultAsync(m => m.Id == id);
        if (brand == null)
        {
            return NotFound();
        }

        return View(brand);
    }

    // GET: Brands/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Brands/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description")] Brand brand)
    {
        if (ModelState.IsValid)
        {
            _context.Add(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(brand);
    }

    // GET: Brands/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Brands == null)
        {
            return NotFound();
        }

        Brand? brand = await _context.Brands.FindAsync(id);
        if (brand == null)
        {
            return NotFound();
        }
        return View(brand);
    }

    // POST: Brands/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Brand brand)
    {
        if (id != brand.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(brand);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(brand.Id))
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
        return View(brand);
    }

    // GET: Brands/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Brands == null)
        {
            return NotFound();
        }

        Brand? brand = await _context.Brands
            .FirstOrDefaultAsync(m => m.Id == id);
        if (brand == null)
        {
            return NotFound();
        }

        return View(brand);
    }

    // POST: Brands/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Brands == null)
        {
            return Problem("Entity set 'LiquorStoreContext.Brands'  is null.");
        }
        Brand? brand = await _context.Brands.FindAsync(id);
        if (brand != null)
        {
            _context.Brands.Remove(brand);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BrandExists(int id)
    {
        return (_context.Brands?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}