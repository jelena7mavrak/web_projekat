using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Routing;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RouteRepository : Repository<Line, int>, IRouteRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }
        public RouteRepository(DbContext context) : base(context)
        {
        }

        public string GetRoute(Enums.RouteType type)
        {
            string s=" ";
            foreach(var i in AppDbContext.Routes)
            {
                if (i.RouteType == type)
                {
                    
                    s += "\n" + i.RouteNumber.ToString() + " -";

                    foreach(var station in i.Stations) {
                        s += " " + station.Name + "-";
                    }
                }
            }
            return s;
        }
    }
}