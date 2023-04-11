﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexScratch.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBurials { get; set; }
        public int BurialsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //this figures out how many pages are needed
        public int TotalPages => (int)Math.Ceiling((double)TotalNumBurials / BurialsPerPage);
    }
}