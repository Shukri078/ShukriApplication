using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShukriApplication.Data;
using ShukriApplication.Models;

namespace ShukriApplication.Controllers
{
    public class ScheduleDateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleDateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScheduleDate
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScheduleDate.Include(s => s.ClassRoom);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScheduleDate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleDate = await _context.ScheduleDate
                .Include(s => s.ClassRoom)
                .FirstOrDefaultAsync(m => m.ScheduleDateId == id);
            if (scheduleDate == null)
            {
                return NotFound();
            }

            return View(scheduleDate);
        }

        // GET: ScheduleDate/Create
        public IActionResult Create()
        {
            ViewData["ClassRoomId"] = new SelectList(_context.Set<ClassRoom>(), "Id", "Id");
            return View();
        }

        // POST: ScheduleDate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassRoomId,StartDate,StartTime,EndTime")] ScheduleDate scheduleDate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleDate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassRoomId"] = new SelectList(_context.Set<ClassRoom>(), "Id", "Id", scheduleDate.ClassRoomId);
            return View(scheduleDate);
        }

        // GET: ScheduleDate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleDate = await _context.ScheduleDate.FindAsync(id);
            if (scheduleDate == null)
            {
                return NotFound();
            }
            ViewData["ClassRoomId"] = new SelectList(_context.Set<ClassRoom>(), "Id", "Id", scheduleDate.ClassRoomId);
            return View(scheduleDate);
        }

        // POST: ScheduleDate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassRoomId,StartDate,StartTime,EndTime")] ScheduleDate scheduleDate)
        {
            if (id != scheduleDate.ScheduleDateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleDate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleDateExists(scheduleDate.ScheduleDateId))
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
            ViewData["ClassRoomId"] = new SelectList(_context.Set<ClassRoom>(), "Id", "Id", scheduleDate.ClassRoomId);
            return View(scheduleDate);
        }

        // GET: ScheduleDate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleDate = await _context.ScheduleDate
                .Include(s => s.ClassRoom)
                .FirstOrDefaultAsync(m => m.ScheduleDateId == id);
            if (scheduleDate == null)
            {
                return NotFound();
            }

            return View(scheduleDate);
        }

        // POST: ScheduleDate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduleDate = await _context.ScheduleDate.FindAsync(id);
            _context.ScheduleDate.Remove(scheduleDate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleDateExists(int id)
        {
            return _context.ScheduleDate.Any(e => e.ScheduleDateId == id);
        }
    }
}
