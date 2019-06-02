using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApp.Models.Enums;

namespace WebApp.Models
{
    public class Schedule
    {
        private int id;
        private DayType day;
        private List<Route> route;

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DayType Day
        {
            get { return day; }
            set { day = value; }
        }

        public List<Route> Route
        {
            get { return route; }
            set { route = value; }
        }

        public Schedule()
        {
            Route = new List<Route>();
        }
    }
}