using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelTracker;
using TravelTracker.Domain;
using static TravelTracker.Domain.TravelTrackerEnums;
using TravelTracker.Helpers;

namespace TravelTracker.Controllers
{
    public class TravelAgentsController : Controller
    {
        private readonly AirTravelQueryContext _context;

        public TravelAgentsController(AirTravelQueryContext context)
        {
            _context = context;    
        }

        // GET: TravelAgents
        public async Task<IActionResult> Index()
        {
            return View(await _context.TravelAgents.ToListAsync());
        }

        // GET: TravelAgents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgent = await _context.TravelAgents
                .SingleOrDefaultAsync(m => m.TravelAgentId == id);
            if (travelAgent == null)
            {
                return NotFound();
            }

            return View(travelAgent);
        }

        // GET: TravelAgents/Create
        public IActionResult Create()
        {
            List<SelectListItem> roleTypeList = TravelTrackerEnumHelpers.GetTravelAgentRoleTypes();
            ViewBag.RoleTypes = roleTypeList;
            return View();
        }

        // POST: TravelAgents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravelAgentId,AgentName,Role")] TravelAgent travelAgent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelAgent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(travelAgent);
        }

        // GET: TravelAgents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgent = await _context.TravelAgents.SingleOrDefaultAsync(m => m.TravelAgentId == id);
            if (travelAgent == null)
            {
                return NotFound();
            }
            List<SelectListItem> roleTypeList = TravelTrackerEnumHelpers.GetTravelAgentRoleTypes();
            ViewBag.RoleTypes = roleTypeList;
            return View(travelAgent);
        }

        // POST: TravelAgents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravelAgentId,AgentName,Role")] TravelAgent travelAgent)
        {
            if (id != travelAgent.TravelAgentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelAgent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelAgentExists(travelAgent.TravelAgentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(travelAgent);
        }

        // GET: TravelAgents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgent = await _context.TravelAgents
                .SingleOrDefaultAsync(m => m.TravelAgentId == id);
            if (travelAgent == null)
            {
                return NotFound();
            }

            return View(travelAgent);
        }

        // POST: TravelAgents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelAgent = await _context.TravelAgents.SingleOrDefaultAsync(m => m.TravelAgentId == id);
            _context.TravelAgents.Remove(travelAgent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TravelAgentExists(int id)
        {
            return _context.TravelAgents.Any(e => e.TravelAgentId == id);
        }
    }
}
