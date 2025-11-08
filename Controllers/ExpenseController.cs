using Microsoft.AspNetCore.Mvc;
using ExpenseApp.Models;

namespace ExpenseApp.Controllers
{
    public class ExpenseController : Controller
    {
        private static List<Expense> expenses = new List<Expense>();
        private static int counter = 1;

        public IActionResult Index()
        {
            ViewBag.Total = expenses.Sum(e => e.Amount);
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, double amount, DateTime date)
        {
            expenses.Add(new Expense
            {
                Id = counter++,
                Title = title,
                Amount = amount,
                Date = date
            });
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var exp = expenses.FirstOrDefault(e => e.Id == id);
            if (exp != null)
            {
                expenses.Remove(exp);
            }
            return RedirectToAction("Index");
        }
    }
}
