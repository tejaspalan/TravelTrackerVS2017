using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelTracker;
using TravelTracker.Domain;
using TravelTracker.Helpers;

namespace TravelTracker.Controllers
{
    public class AirTravelQueriesController : Controller
    {
        private readonly AirTravelQueryContext _context;

        public object Helper { get; private set; }

        public AirTravelQueriesController(AirTravelQueryContext context)
        {
            _context = context;    
        }

        // GET: AirTravelQueries
        public async Task<IActionResult> Index()
        {
            var airTravelQueryContext = _context.AirTravelQuery.Include(a => a.TravelAgent);
            return View(await airTravelQueryContext.ToListAsync());
        }

        // GET: AirTravelQueries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airTravelQuery = await _context.AirTravelQuery
                .Include(a => a.TravelAgent)
                .SingleOrDefaultAsync(m => m.RequestId == id);
            if (airTravelQuery == null)
            {
                return NotFound();
            }

            return View(airTravelQuery);
        }

        // GET: AirTravelQueries/Create
        public IActionResult Create()
        {
            ViewData["TravelAgentId"] = new SelectList(_context.TravelAgents, "TravelAgentId", "AgentName");
            ViewData["QueryDate"] = DateTime.Now;
            return View();
        }

        // POST: AirTravelQueries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravelClass,TravelType,RequestId,TravelAgentId,CustomerContactNumber,CustomerName,QueryDate,TentativeTripStartDate,TentativeTripEndDate,QueryStatus,NumberOfAdults,NumberOfChildren")] AirTravelQuery airTravelQuery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airTravelQuery);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TravelAgentId"] = new SelectList(_context.TravelAgents, "TravelAgentId", "AgentName", airTravelQuery.TravelAgentId);
            return View(airTravelQuery);
        }

        // GET: AirTravelQueries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airTravelQuery = await _context.AirTravelQuery.SingleOrDefaultAsync(m => m.RequestId == id);
            if (airTravelQuery == null)
            {
                return NotFound();
            }
            ViewData["TravelAgentId"] = new SelectList(_context.TravelAgents, "TravelAgentId", "AgentName", airTravelQuery.TravelAgentId);
            ViewData["TravelType"] = TravelTrackerEnumHelpers.GetTravelTypes();
            ViewData["AirTravelClass"] = TravelTrackerEnumHelpers.GetAirTravelTypes();
            ViewData["QueryStatus"] = TravelTrackerEnumHelpers.GetQueryStatusOptions();
            return View(airTravelQuery);
        }

        // POST: AirTravelQueries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravelClass,TravelType,RequestId,TravelAgentId,CustomerContactNumber,CustomerName,QueryDate,TentativeTripStartDate,TentativeTripEndDate,QueryStatus,NumberOfAdults,NumberOfChildren")] AirTravelQuery airTravelQuery)
        {
            if (id != airTravelQuery.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airTravelQuery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirTravelQueryExists(airTravelQuery.RequestId))
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
            ViewData["TravelAgentId"] = new SelectList(_context.TravelAgents, "TravelAgentId", "AgentName", airTravelQuery.TravelAgentId);
            return View(airTravelQuery);
        }

        // GET: AirTravelQueries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airTravelQuery = await _context.AirTravelQuery
                .Include(a => a.TravelAgent)
                .SingleOrDefaultAsync(m => m.RequestId == id);
            if (airTravelQuery == null)
            {
                return NotFound();
            }

            return View(airTravelQuery);
        }

        // POST: AirTravelQueries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airTravelQuery = await _context.AirTravelQuery.SingleOrDefaultAsync(m => m.RequestId == id);
            _context.AirTravelQuery.Remove(airTravelQuery);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AirTravelQueryExists(int id)
        {
            return _context.AirTravelQuery.Any(e => e.RequestId == id);
        }
    }
}
