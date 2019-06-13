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

        public string GetStationNames(int lineId)
        {
            string s = "";
            foreach(var l in AppDbContext.Stations)
            {
                if (l.LineId == lineId)
                {
                    s += "-"+l.Name;
                }
            }
            return s;
        }

        public string GetRoute(Enums.RouteType type)
        {
            string s=" ";
            foreach(var i in AppDbContext.Routes)
            {
                if (i.RouteType == type)
                {
                    
                    s += "\n" + i.RouteNumber.ToString();
                    s+= GetStationNames(i.Id); 
                }
            }
            return s;
        }

        public List<string> GetRouteS(Enums.RouteType type)
        {
            List<string> retVal = new List<string>();
            string s = " ";

            foreach (var i in AppDbContext.Routes)
            {
                if (i.RouteType == type)
                {

                    s += i.RouteNumber.ToString();
                    s += GetStationNames(i.Id);
                    retVal.Add(s);
                    s = "";
                }
            }
            return retVal;
        }
    }
}