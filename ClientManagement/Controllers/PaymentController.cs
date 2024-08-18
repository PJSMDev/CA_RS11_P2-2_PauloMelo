using ClientManagement.BusinessLogic;
using ClientManagement.DAL;
using ClientManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientManagement.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ClientManagementDbContext _context;
        private readonly DiscountService _discountService;

        public PaymentController(ClientManagementDbContext context, DiscountService discountService)
        {
            _context = context;
            _discountService = discountService;
        }

        // GET: Payment/Create
        public IActionResult Create()
        {
            // Carregar informações necessárias para criar um pagamento, como clientes
            ViewData["Clients"] = _context.Clients.ToList();
            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,Amount")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                var client = await _context.Clients
                    .Include(c => c.MembershipType)
                    .SingleOrDefaultAsync(c => c.ClientId == payment.ClientId);

                if (client == null)
                {
                    return NotFound();
                }

                // Calculate discounted value.
                decimal discountedAmount = _discountService.CalculateDiscount(client, payment.Amount);

                // Reset the payment amount with the discount already applied.
                payment.Amount = discountedAmount;

                // Adding the payment to the context
                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["Clients"] = _context.Clients.ToList();
            return View(payment);
        }

        // GET: Payment/Index
        public async Task<IActionResult> Index()
        {
            var payments = await _context.Payments
                .Include(p => p.Client)
                .ToListAsync();

            return View(payments);
        }
    }
}
