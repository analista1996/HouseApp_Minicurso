using HouseApp.Models;
using HouseDataAcess.housecontext;
using HouseModel.Models.Resume_;
using HouseModel.Models.Spends_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HouseApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly housecontext_ _db;
        public HomeController(housecontext_ db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            var user = _db.Users.FirstOrDefault().User_Id;

            var resume = new Resume {
                User_Id = user,
                Total_Spends = _db.Spends.Where(c => c.User_Id == user).Sum(c => c.Spend_Value),
                Total_Save = 0,
                I_Budget = _db.Budgets.Where(c=>c.User_Id == user).Sum(c=>c.Montly_value),
                F_Budget = (_db.Budgets.Where(c => c.User_Id == user).Sum(c => c.Montly_value) -
                _db.Spends.Where(c=>c.User_Id == user).Sum(c=>c.Spend_Value)),
                P_used = _db.Spends.Where(c=>c.User_Id == user).Select(c=>c.Payment_Ms.Name).Distinct().ToList()
            };
            ViewData["pay"] = resume;
            ViewData["i_pay"] = resume.I_Budget;
            ViewData["lista"] = resume.P_used;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddSpends()
        {
            ViewData["pay"] = _db.Payment_Ms.ToList();
            return View(ViewData["pay"]);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSpends(IFormCollection collen)
        {
            var spend = new Spends
            {

                Description = collen["descricption"],
                Spend_Value = double.Parse(collen["valor"].ToString()),
                P_Id = int.Parse(collen["Payment"].ToString()),
                Spend_date = DateTime.Parse(collen["date"].ToString()),
                User_Id = 1

            };

            _db.Spends.Add(spend);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
