using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexScratch.Models
{
    public interface IBurialRepository
    {
        IQueryable<Burialmain> Burials { get; }
    }
}
