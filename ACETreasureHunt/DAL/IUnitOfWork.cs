using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACETreasureHunt.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        IEventRepository Events { get; }
        IPitStopRepository PitStops { get; }

        ITeamRepository Teams { get; }

        IStaffRepository Staffs { get; }
        int Complete();
    }
}