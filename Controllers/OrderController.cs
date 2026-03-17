using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Threading.Tasks;
using TextWave.Data;
using TextWave.Models;

namespace TextWave.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PlaceOrder(string planName, decimal amount,
            string billingType, string cardholderName, string cardLastFour, string paymentMethod)
        {
            var user = await _userManager.GetUserAsync(User);
            var orderNumber = "TW-" + DateTime.Now.ToString("yyyyMMdd") + "-" +
                              new Random().Next(10000, 99999).ToString();

            var order = new Order
            {
                PlanName = planName,
                Amount = amount,
                BillingType = billingType,
                CardholderName = cardholderName,
                CardLastFour = cardLastFour,
                PaymentMethod = paymentMethod,
                UserId = user?.Id,
                UserEmail = user?.Email,
                OrderNumber = orderNumber,
                Status = "Paid",
                CreatedAt = DateTime.Now
            };

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return Json(new { success = true, orderNumber = orderNumber, email = user?.Email });
        }

        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _db.Orders
                .Where(o => o.UserId == user.Id)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
            return View(orders);
        }

        // Admin - view all orders
        [Authorize]
        public async Task<IActionResult> AdminOrders()
        {
            var orders = await _db.Orders
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
            return View(orders);
        }

        // Admin - delete order
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _db.Orders.FindAsync(id);
            if (order != null)
            {
                _db.Orders.Remove(order);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("AdminOrders");
        }
    }
}
