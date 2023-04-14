using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexScratch.Models
{
    public class EFBurialRepository: IBurialRepository
    {
            private new_intexContext context { get; set; }

            public EFBurialRepository(new_intexContext temp)
            {
                context = temp;
            }

            public IQueryable<Burialmain> Burials => context.Burialmain;

            public void Add(Burialmain burial)
            {
                context.Burialmain.Add(burial);
            }

            public void Save()
            {
                context.SaveChanges();
            }

    }
}
