using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{ 
    public class PricelistRepository : Repository<Pricelist, int>, IPricelistRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public PricelistRepository(DbContext context) : base(context)
        {
        }

        public int AddPricelist(PricelistBindingModel pricelist)
        {
            var activePricelist = AppDbContext.Pricelists.Where(p => p.InUse).First();

            activePricelist.InUse = false;
            AppDbContext.SaveChanges();

            Pricelist newPricelist = new Pricelist()
            {
                StartDate = pricelist.StartDate,
                EndDate = pricelist.EndDate,
                InUse = true
            };

            AppDbContext.Pricelists.Add(newPricelist);
            AppDbContext.SaveChanges();
            return GetPricelistIdActive();
        }

        public int GetPricelistIdActive()
        {
            return AppDbContext.Pricelists.Single(p => p.InUse).Id;
        }
    }
}