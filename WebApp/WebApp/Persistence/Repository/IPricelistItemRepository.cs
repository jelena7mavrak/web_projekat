using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
   public interface IPricelistItemRepository : IRepository<PricelistItem, int>
    {
        double GetTicketPriceForType(int pricelistId, int itemId);
        bool AddPricelistItem(PricelistItemBindingModel pricelistItem, int pricelistId);
        ActivePricelistBindingModel GetActivePricelist(int pricelistId);
        bool UpdatePricelist(ActivePricelistBindingModel pricelist);
    }
}
