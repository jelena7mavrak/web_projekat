using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;
using static WebApp.Models.Enums;

namespace WebApp.Persistence.Repository
{
    public class TicketRepository : Repository<Ticket, int>, ITicketRepository
    {

        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public TicketRepository(DbContext context) : base(context)
        {
        }

        public Ticket BuyTicket(double price, int pricelistItemId)
        {
            Ticket t = new Ticket
            {
                Passenger = PassengerType.Regular,
                From = DateTime.Now,
                To=DateTime.Now.AddHours(1),

            };

            AppDbContext.Tickets.Add(t);
            context.SaveChanges();

            return t;
        }
    }
}