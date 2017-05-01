using ACETreasureHunt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACETreasureHunt.DAL
{
    public class PitStopRepository : Repository<PitStop>, IPitStopRepository
    {
        public PitStopRepository(ACEContext context)
            : base(context)
        {
        }

        public ACEContext ACEContext
        {
            get { return Context as ACEContext; }
        }
    }
}