using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACETreasureHunt.Models;


namespace ACETreasureHunt.DAL
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAllEvents();
    }
}