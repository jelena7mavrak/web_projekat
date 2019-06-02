using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Enums
    {
        public enum PassengerType
        {
            Student,
            Pensioner,
            Regular
        }

        public enum VerificationType
        {
            Process,
            Accepted,
            Rejected
        }

        public enum RouteType
        {
            Suburban,
            Town
        }

        public enum TicketType
        {
            Hourly,
            Daily,
            Monthly,
            Annual
        }

        public enum DayType
        {
            Workday,
            Saturday,
            Sunday
        }
    }
}