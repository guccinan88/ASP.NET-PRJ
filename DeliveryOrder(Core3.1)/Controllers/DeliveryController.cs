using DeliveryOrder.Data;
using DeliveryOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DeliveryOrder.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly CmsContext _context;
        public DeliveryController(CmsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.deliveries.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var delivery = await _context.deliveries.FirstOrDefaultAsync(m => m.Id == id);
            var customer=await _context.customers.FirstOrDefaultAsync(m => m.Name == delivery.Customer_Name);
            ViewBag.Address=customer.Address;
            ViewBag.Phone=customer.Phone;
            ViewBag.Email=customer.Email;
            return View(delivery);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,ProductCount,Customer_Name,Date")] Delivery_Order delivery)
        {
            if(ModelState.IsValid)
            {
                _context.deliveries.Add(delivery);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(delivery);
            }
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var delivery = await _context.deliveries.FindAsync(id);
            return View(delivery);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,ProductName,ProductCount,Customer_Name,Date")] Delivery_Order delivery)
        {
            if(ModelState.IsValid)
            {
                _context.deliveries.Update(delivery);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(delivery);
            }
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var delivery = await _context.deliveries.FindAsync(id);
            return View(delivery);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var delivery = await _context.deliveries.FindAsync(id);
            _context.Remove(delivery);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

    }
}
