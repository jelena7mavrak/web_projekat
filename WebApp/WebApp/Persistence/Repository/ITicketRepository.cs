﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
   public interface ITicketRepository : IRepository<Ticket, int>
    {
        Ticket BuyTicket(double price, int pricelistItemId);

    }
}
