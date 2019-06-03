using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApp.Models.Enums;

namespace WebApp.Models
{
    public class Item
    {
        private int id;
        private TicketType type;

        [Key]
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