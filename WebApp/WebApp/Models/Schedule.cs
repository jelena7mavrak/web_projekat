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
        private RouteType type;
        private DayType day;
        private Line line;
        private int lineId;
        private string departureTime; //vreme polaska

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public RouteType Type
        {
            get { return type; }
            set { type = value; }
        }

        public DayType Day
        {
            get { return day; }
            set { day = value; }
        }

        public Line Line
        {
            get { return line; }
            set { line = value; }
        }

        public string DepartureTime
        {
            get { return departureTime;}
            set { departureTime = value; }
        }

        public int LineId { get => lineId; set => lineId = value; }
    }
}