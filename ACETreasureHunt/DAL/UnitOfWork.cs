using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACETreasureHunt.DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ACEContext _context;

        public UnitOfWork(ACEContext context)
        {
            System.Data.Entity.Database.SetInitializer<ACEContext>(null);
            _context = context;
            Events = new EventRepository(_context);
            Teams = new TeamRepository(_context);
            Staffs = new StaffRepository(_context);
            PitStops = new PitStopRepository(_context);
            //Authors = new PitStopRepository(_context);
        }

        public IEventRepository Events { get; private set; }
        public IPitStopRepository PitStops { get; private set; }

        public ITeamRepository Teams { get; private set; }
        public IStaffRepository Staffs { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}