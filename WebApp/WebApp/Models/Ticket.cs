using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApp.Models.Enums;

namespace WebApp.Models
{
    public class Ticket
    {

        private int id;
        private DateTime from;
        private DateTime to;
        private PassengerType passenger;

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime From
        {
            get { return from; }
            set { from = value; }
        }

        public DateTime To
        {
            get { return to; }
            set { to = value; }
        }

        public PassengerType Passenger
        {
            get { return passenger; }
            set { passenger = value; }
        }
    }
}