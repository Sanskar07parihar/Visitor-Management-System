using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Visitor_Management_System.Data;
using Visitor_Management_System.Models;

namespace Visitor_Management_System.Controllers
{
    [Authorize]
    public class RidesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RidesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rides
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rides.Include(r => r.Customer).Include(r => r.Park);
            return View(await applicationDbContext.ToListAsync());
        }
        [AllowAnonymous]
        // GET: Rides/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ride = await _context.Rides
                .Include(r => r.Customer)
                .Include(r => r.Park)
                .FirstOrDefaultAsync(m => m.RideId == id);
            if (ride == null)
            {
                return NotFound();
            }

            return View(ride);
        }

        // GET: Rides/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["ParkId"] = new SelectList(_context.Parks, "ParkId", "ParkId");
            return View();
        }

        // POST: Rides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RideId,Price,ParkId,CustomerId")] Ride ride)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ride);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", ride.CustomerId);
            ViewData["ParkId"] = new SelectList(_context.Parks, "ParkId", "ParkId", ride.ParkId);
            return View(ride);
        }

        // GET: Rides/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ride = await _context.Rides.FindAsync(id);
            if (ride == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", ride.CustomerId);
            ViewData["ParkId"] = new SelectList(_context.Parks, "ParkId", "ParkId", ride.ParkId);
            return View(ride);
        }

        // POST: Rides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RideId,Price,ParkId,CustomerId")] Ride ride)
        {
            if (id != ride.RideId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ride);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RideExists(ride.RideId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", ride.CustomerId);
            ViewData["ParkId"] = new SelectList(_context.Parks, "ParkId", "ParkId", ride.ParkId);
            return View(ride);
        }

        // GET: Rides/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ride = await _context.Rides
                .Include(r => r.Customer)
                .Include(r => r.Park)
                .FirstOrDefaultAsync(m => m.RideId == id);
            if (ride == null)
            {
                return NotFound();
            }

            return View(ride);
        }

        // POST: Rides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ride = await _context.Rides.FindAsync(id);
            _context.Rides.Remove(ride);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RideExists(string id)
        {
            return _context.Rides.Any(e => e.RideId == id);
        }
    }
}
