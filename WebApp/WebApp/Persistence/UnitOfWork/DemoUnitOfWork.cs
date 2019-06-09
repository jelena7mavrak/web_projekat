using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public class DemoUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
      
        public DemoUnitOfWork(DbContext context)
        {
            _context = context;
        }

       
        [Dependency]
        public ICoefficientsRepository CoefficientsRepository { get; set; }
        [Dependency]
        public IItemRepository ItemRepository { get; set; }
        [Dependency]
        public ILocationRepository LocationRepository { get; set; }
        [Dependency]
        public IPersonRepository PersonRepository { get; set; }
        [Dependency]
        public IPricelistItemRepository PricelistItem { get; set; }
        [Dependency]
        public IPricelistRepository Pricelist { get; set; }
        [Dependency]
        public IRouteRepository RouteRepository { get; set; }
        [Dependency]
        public IScheduleRepository ScheduleRepository { get; set; }
        [Dependency]
        public IStationRepository StationRepository { get; set; }
        [Dependency]
        public ITicketRepository TicketRepository { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}