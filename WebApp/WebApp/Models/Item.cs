using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebApp.Models.Enums;

namespace WebApp.Models
{
    public class Item
    {
        private int id;
        private TicketType type;

        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        public TicketType Type
        {
            get { return type; }
            set { type = value; }
        }

    }
}