using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACETreasureHunt.Models;
using System.Data.Entity;

namespace ACETreasureHunt.DAL
{
    public class EventRepository: Repository<Event>, IEventRepository
    {
        public EventRepository(ACEContext context) 
            : base(context)
        {
        }       
        public ACEContext ACEContext
        {
            get { return Context as ACEContext; }
        }
        public IEnumerable<Event> GetAllEvents()
        {
            return ACEContext.Events.ToList();
        }
    }
}