using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;
using static WebApp.Models.Enums;

namespace WebApp.Persistence.Repository
{
    public class ItemRepository : Repository<Item, int>, IItemRepository
    {

        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public ItemRepository(DbContext context) : base(context)
        {
        }

        public int GetIdForType(TicketType type)
        {
            return AppDbContext.Items.Single(i => i.Type == type).Id;
        }
    }
}