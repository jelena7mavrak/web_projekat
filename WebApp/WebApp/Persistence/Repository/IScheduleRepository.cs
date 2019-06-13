using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;
using static WebApp.Models.Enums;

namespace WebApp.Persistence.Repository
{
   public interface IScheduleRepository : IRepository<Schedule, int>
    {
        string GetSchedule(RouteType routeT, DayType dayT, string line);
    }
}
