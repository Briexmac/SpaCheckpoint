using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SpaCheckpoint.Models
{
    public class ServiceProvidersController : Controller
    {
        private readonly ServiceProvidersContext _context;

        public ServiceProvidersController(ServiceProvidersContext context)
        {
            _context = context;
        }

        // GET: ServiceProviders
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceProviders.ToListAsync());
        }

        // GET: ServiceProviders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceProviders = await _context.ServiceProviders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceProviders == null)
            {
                return NotFound();
            }

            return View(serviceProviders);
        }

        // GET: ServiceProviders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,newGuid,Name")] ServiceProviders serviceProviders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceProviders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceProviders);
        }

        // GET: ServiceProviders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceProviders = await _context.ServiceProviders.FindAsync(id);
            if (serviceProviders == null)
            {
                return NotFound();
            }
            return View(serviceProviders);
        }

        // POST: ServiceProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] ServiceProviders serviceProviders)
        {
            if (id != serviceProviders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceProviders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceProvidersExists(serviceProviders.Id))
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
            return View(serviceProviders);
        }

        // GET: ServiceProviders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceProviders = await _context.ServiceProviders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceProviders == null)
            {
                return NotFound();
            }

            return View(serviceProviders);
        }

        // POST: ServiceProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceProviders = await _context.ServiceProviders.FindAsync(id);
            _context.ServiceProviders.Remove(serviceProviders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceProvidersExists(int id)
        {
            return _context.ServiceProviders.Any(e => e.Id == id);
        }
    }
}
