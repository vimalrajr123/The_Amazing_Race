using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACETreasureHunt.Models;

namespace ACETreasureHunt.DAL
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(ACEContext context) 
            : base(context)
        {
        }
        public ACEContext ACEContext
        {
            get { return Context as ACEContext; }
        }
    }
}