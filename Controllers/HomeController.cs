﻿using IntexScratch.Models;
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

        public IActionResult Burials(int pageNum = 1, string textileColor = null, string textileStructure = null, string sex = null, string burialDepth = null, string estimatedStature = null, string ageAtDeath = null, string headDirection = null, string burialId = null, string textileFunction = null, string hairColor = null)
        {
            int pageSize = 5;
            var query = repo.Burials.AsQueryable();

            //if (textileColor != null)
            //{
            //    query = query.Where(b => b.TextileColor == textileColor);
            //}

            //if (textileStructure != null)
            //{
            //    query = query.Where(b => b.TextileStructure == textileStructure);
            //}

            if (sex != null)
            {
                query = query.Where(b => b.Sex == sex);
            }

            if (burialDepth != null)
            {
                query = query.Where(b => b.Depth == burialDepth);
            }

            //if (estimatedStature != null)
            //{
            //    query = query.Where(b => b.EstimatedStature == estimatedStature);
            //}

            if (ageAtDeath != null)
            {
                query = query.Where(b => b.Ageatdeath == ageAtDeath);
            }

            if (headDirection != null)
            {
                query = query.Where(b => b.Headdirection == headDirection);
            }

            if (burialId != null)
            {
                query = query.Where(b => b.Burialid == burialId);
            }

            //if (textileFunction != null)
            //{
            //    query = query.Where(b => b.TextileFunction == textileFunction);
            //}

            if (hairColor != null)
            {
                query = query.Where(b => b.Haircolor == hairColor);
            }

            var x = new BurialSummaryViewModel
            {
                Burials = query
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials = query.Count(),
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

        [AllowAnonymous]
        public IActionResult UnsupervisedAnalysis()
        {
            return View();
        }
    }
}
