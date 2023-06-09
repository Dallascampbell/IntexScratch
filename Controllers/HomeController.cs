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
        private new_intexContext _context { get; set; }

        private IBurialRepository repo;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBurialRepository temp, new_intexContext x)
        {
            repo = temp;
            _logger = logger;
            _context = x;
        }

        [HttpGet]
        public IActionResult Supervised()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Admin, Moderator, Basic")]
        [HttpGet]
        public IActionResult AddBurial()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Admin, Moderator, Basic")]
        [HttpPost]
        public IActionResult AddBurial(Burialmain b)
        {

            if (ModelState.IsValid) //if Vlaid
            {
                var rowCount = _context.Burialmain.Count();
                b.Id = rowCount;

                _context.Add(b);
                _context.SaveChanges();

                return View("Index");
            }
            else //If invalid
            {
                return View(b);
            }
        }

        [Authorize(Roles = "SuperAdmin, Admin, Moderator, Basic")]
        public IActionResult Edit(long id)
        {
            var mummy = _context.Burialmain.First(x => x.Id == id);

            return View("AddBurial", mummy);
        }

        [Authorize(Roles = "SuperAdmin, Admin, Moderator, Basic")]
        [HttpPost]
        public IActionResult Edit(Burialmain b)
        {
            //b.Burialid = Convert.ToUInt64(b.Burialid);
            _context.Update(b);
            _context.SaveChanges();

            return View("Index");
        }

            public IActionResult Analysis()
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult Supervised(SupervisedResponse sr)
        //{
        //    return View("SupervisedConf", sr);
        //}


        public IActionResult Burials(int pageNum = 1, string textileColor = null, string textileStructure = null, string sex = null, string burialDepth = null, string estimatedStature = null, string ageAtDeath = null, string headDirection = null, string burialId = null, string textileFunction = null, string hairColor = null)
        {
            int pageSize = 5;

            var query = repo.Burials;

            // Apply filters if they are not null
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
                int parsedBurialId;
                bool success = Int32.TryParse(burialId, out parsedBurialId);

                if (success)
                {
                    query = query.Where(b => b.Burialnumber == parsedBurialId);
                }

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
                    CurrentPage = pageNum,
     
                    Sex = sex,
                    id = burialId,
                    HeadDirection = headDirection,
                    Age = ageAtDeath,
                    TextileColor = textileColor,
                    HairColor = hairColor
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

        public IActionResult UnsupervisedAnalysis()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Admin, Moderator, Basic")]
        [HttpGet]
        public IActionResult DeleteBurial(long id)
        {
            var burial = _context.Burialmain.First(x => x.Id == id);

            return View(burial);
        }

        [Authorize(Roles = "SuperAdmin, Admin, Moderator, Basic")]
        [HttpPost]
        public IActionResult DeleteBurial(Burialmain b)
        {
            _context.Burialmain.Remove(b);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult IndividualBurial(long id)
        {
            var burial = _context.Burialmain.First(x => x.Id == id);

            return View(burial);
        }
    }
}
