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

        public bool UpdateLine(LineBindingModel line)
        {
            foreach (Line l in AppDbContext.Routes.ToList())
            {

                if (l.Id == line.Id)
                {
                    l.RouteNumber = line.RouteNumber;
                    l.RouteType = line.RouteType;

                    AppDbContext.SaveChanges();


                    return true;
                }

            }
            return false;
        }

        public bool RemoveLine(int lineId)
        {
            try
            {
                Line removeL = AppDbContext.Routes.Single(l => l.Id == lineId);

                AppDbContext.Routes.Remove(removeL);
                AppDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;


            }
        }

        public Line GetLineByLineNumber(int lineNumber)
        {
            return AppDbContext.Routes.FirstOrDefault(line => line.RouteNumber == lineNumber);
        }

        public List<int> GetAllLines()
        {
            List<int> ret = new List<int>();

            foreach (var item in AppDbContext.Routes.ToList())
            {
                ret.Add(item.RouteNumber);
            }

            return ret;
        }
    }
}