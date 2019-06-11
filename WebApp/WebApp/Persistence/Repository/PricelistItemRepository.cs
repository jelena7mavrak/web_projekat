using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class PricelistItemRepository : Repository<PricelistItem, int>, IPricelistItemRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }
        public PricelistItemRepository(DbContext context) : base(context)
        {
           
        }
        public double GetTicketPriceForType(int pricelistId, int itemId)
        {
            return AppDbContext.PricelistItems.Single(p => p.PricelistId == pricelistId && p.ItemId == itemId).Price;
        }
    }
}