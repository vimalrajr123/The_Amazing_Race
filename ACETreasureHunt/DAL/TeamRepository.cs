using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACETreasureHunt.Models;

namespace ACETreasureHunt.DAL
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(ACEContext context) 
            : base(context)
        {
        }
        public ACEContext ACEContext
        {
            get { return Context as ACEContext; }
        }
    }
}