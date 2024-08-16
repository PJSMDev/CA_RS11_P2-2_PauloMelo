using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientManagement.DAL;
using ClientManagement.Models;

namespace ClientManagement.Controllers
{
    public class ClientServiceController : Controller
    {
        private readonly ClientManagementDbContext _context;

        public ClientServiceController(ClientManagementDbContext context)
        {
            _context = context;
        }

        // GET: ClientService
        public async Task<IActionResult> Index()
        {
            var clientManagementDbContext = _context.ClientServices.Include(c => c.Client).Include(c => c.Service);
            return View(await clientManagementDbContext.ToListAsync());
        }

        // GET: ClientService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientServices == null)
            {
                return NotFound();
            }

            var clientService = await _context.ClientServices
                .Include(c => c.Client)
                .Include(c => c.Service)
                .FirstOrDefaultAsync(m => m.ClientServiceId == id);
            if (clientService == null)
            {
                return NotFound();
            }

            return View(clientService);
        }

        // GET: ClientService/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "Name");
            return View();
        }

        // POST: ClientService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientServiceId,ClientId,ServiceId,ServiceDate")] ClientService clientService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", clientService.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "Name", clientService.ServiceId);
            return View(clientService);
        }

        // GET: ClientService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientServices == null)
            {
                return NotFound();
            }

            var clientService = await _context.ClientServices.FindAsync(id);
            if (clientService == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", clientService.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "Name", clientService.ServiceId);
            return View(clientService);
        }

        // POST: ClientService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientServiceId,ClientId,ServiceId,ServiceDate")] ClientService clientService)
        {
            if (id != clientService.ClientServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientServiceExists(clientService.ClientServiceId))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", clientService.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "Name", clientService.ServiceId);
            return View(clientService);
        }

        // GET: ClientService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientServices == null)
            {
                return NotFound();
            }

            var clientService = await _context.ClientServices
                .Include(c => c.Client)
                .Include(c => c.Service)
                .FirstOrDefaultAsync(m => m.ClientServiceId == id);
            if (clientService == null)
            {
                return NotFound();
            }

            return View(clientService);
        }

        // POST: ClientService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientServices == null)
            {
                return Problem("Entity set 'ClientManagementDbContext.ClientServices'  is null.");
            }
            var clientService = await _context.ClientServices.FindAsync(id);
            if (clientService != null)
            {
                _context.ClientServices.Remove(clientService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientServiceExists(int id)
        {
          return (_context.ClientServices?.Any(e => e.ClientServiceId == id)).GetValueOrDefault();
        }
    }
}
