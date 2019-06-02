using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApp.Models.Enums;

namespace WebApp.Models
{
    public class Route
    {
        private int id;
        private int routeNumber;
        private List<Station> stations;
        private RouteType routeType;

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int RouteNumber
        {
            get { return routeNumber; }
            set { routeNumber = value; }
        }


        public List<Station> Stations
        {
            get { return stations; }
            set { stations = value; }
        }

        public RouteType RouteType
        {
            get { return routeType; }
            set { routeType = value; }
        }

        public Route()
        {
            Stations = new List<Station>();
        }
    }
}