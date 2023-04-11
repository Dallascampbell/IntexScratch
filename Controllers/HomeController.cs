using IntexScratch.Models;
using IntexScratch.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IntexScratch.Controllers
{
    public class HomeController : Controller
    {
        private IBurialRepository repo;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBurialRepository temp)
        {
            repo = temp;
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Burials(string filterType, int pageNum = 1)
        {
            int pageSize = 5;
            var x = new BurialSummaryViewModel
            {
                Burials = repo.Burials
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials = (repo.Burials.Count()),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            
            return View(x);
        }

        [AllowAnonymous]
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
