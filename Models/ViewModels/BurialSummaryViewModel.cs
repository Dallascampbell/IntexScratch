﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexScratch.Models.ViewModels
{
    public class BurialSummaryViewModel
    {
        public IQueryable<Burialmain> Burials { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}
