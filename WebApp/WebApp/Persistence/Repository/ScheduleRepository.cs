using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;
using static WebApp.Models.Enums;

namespace WebApp.Persistence.Repository
{
    public class ScheduleRepository : Repository<Schedule, int>, IScheduleRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public ScheduleRepository(DbContext context) : base(context)
        {
        }
    
        public string GetSchedule(RouteType routeT, DayType dayT, string line)
        {

            string schedule = "";
            int lineI = -1;

            //int lineName = int.Parse(line.Substring(0, 1));
            char[] str = new char[] { '-' };
            string[] lineName = line.Split(str);

            foreach (var l in AppDbContext.Routes)
            {
                if(l.RouteNumber==int.Parse(lineName[0]))
                {
                    lineI = l.Id;
                }
            }
            foreach(var s in AppDbContext.Schedules)
            {
                if(s.LineId==lineI && s.Day == dayT)
                {
                    schedule += " "+s.DepartureTime;
                }
            }
            return schedule;
        }
    }
}