using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bank.App.Models;
using Bank.Data.DatabasePopulated;
using Bank.Domain;
using Microsoft.AspNetCore.Identity;
using Bank.Data;
using Microsoft.Extensions.Configuration;

namespace Bank.App.Controllers
{

    public class HomeController : Controller
    {
        private readonly IPopulateDatabaseWithData _populateDatabaseWithData;

        public HomeController(IPopulateDatabaseWithData populateDatabaseWithData)
        {
            _populateDatabaseWithData = populateDatabaseWithData;
        }

        //public async Task<IActionResult> Index()
        //{
        //    if (!_populateDatabaseWithData.IsSeeded())
        //    {
        //        await _populateDatabaseWithData.EnsureSeedDataContext();
        //    }

        //    return View();
        //}

        public IActionResult Index()
        {
            //if (!_populateDatabaseWithData.IsSeeded())
            //{
            //    await _populateDatabaseWithData.EnsureSeedDataContext();
            //}

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
