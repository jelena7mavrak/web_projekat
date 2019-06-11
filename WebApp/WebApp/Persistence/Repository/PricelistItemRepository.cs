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

        public bool AddPricelistItem(PricelistItemBindingModel pricelistItem, int pricelistId)
        {
            try
            {
                var pi1 = new PricelistItem { ItemId = 1, PricelistId = pricelistId, Price = pricelistItem.HourlyPrice };
                var pi2 = new PricelistItem { ItemId = 2, PricelistId = pricelistId, Price = pricelistItem.DailyPrice };
                var pi3 = new PricelistItem { ItemId = 3, PricelistId = pricelistId, Price = pricelistItem.MonthlyPrice };
                var pi4 = new PricelistItem { ItemId = 4, PricelistId = pricelistId, Price = pricelistItem.AnnualPrice };

                AppDbContext.PricelistItems.Add(pi1);
                AppDbContext.PricelistItems.Add(pi2);
                AppDbContext.PricelistItems.Add(pi3);
                AppDbContext.PricelistItems.Add(pi4);

                AppDbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ActivePricelistBindingModel GetActivePricelist(int pricelistId)
        {
            double hourly = AppDbContext.PricelistItems.FirstOrDefault(pi => pi.PricelistId == pricelistId && pi.ItemId == 1).Price;
            double daily = AppDbContext.PricelistItems.FirstOrDefault(pi => pi.PricelistId == pricelistId && pi.ItemId == 2).Price;
            double monthly = AppDbContext.PricelistItems.FirstOrDefault(pi => pi.PricelistId == pricelistId && pi.ItemId == 3).Price;
            double annual = AppDbContext.PricelistItems.FirstOrDefault(pi => pi.PricelistId == pricelistId && pi.ItemId == 4).Price;
            Pricelist active = AppDbContext.Pricelists.FirstOrDefault(p => p.InUse);


            ActivePricelistBindingModel pricelist = new ActivePricelistBindingModel()
            {
                HourlyPrice = hourly,
                DailyPrice = daily,
                MonthlyPrice = monthly,
                AnnualPrice = annual,
                StartDate = active.StartDate,
                EndDate = active.EndDate

            };

            return pricelist;
        }

        public bool UpdatePricelist(ActivePricelistBindingModel pricelist)
        {
            try
            {
                Pricelist pr = AppDbContext.Pricelists.FirstOrDefault(p => p.InUse);

                PricelistItem pri1 = AppDbContext.PricelistItems.FirstOrDefault(pi => pi.PricelistId == pr.Id && pi.ItemId == 1);
                PricelistItem pri2 = AppDbContext.PricelistItems.FirstOrDefault(pi => pi.PricelistId == pr.Id && pi.ItemId == 2);
                PricelistItem pri3 = AppDbContext.PricelistItems.FirstOrDefault(pi => pi.PricelistId == pr.Id && pi.ItemId == 3);
                PricelistItem pri4 = AppDbContext.PricelistItems.FirstOrDefault(pi => pi.PricelistId == pr.Id && pi.ItemId == 4);

                pr.StartDate = pricelist.StartDate;
                pr.EndDate = pricelist.EndDate;

                pri1.Price = pricelist.HourlyPrice;
                pri2.Price = pricelist.DailyPrice;
                pri3.Price = pricelist.MonthlyPrice;
                pri4.Price = pricelist.AnnualPrice;

                AppDbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetPricelistItemId(int pricelistId, int itemId)
        {
            return AppDbContext.PricelistItems.FirstOrDefault(p => p.PricelistId == pricelistId && p.ItemId == itemId).Id;
        }
    }
}
