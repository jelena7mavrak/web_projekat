using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressRepository { get; set; }
        ICoefficientsRepository CoefficientsRepository { get; set; }
        IItemRepository ItemRepository { get; set; }
        ILocationRepository LocationRepository { get; set; }
        IPersonRepository PersonRepository { get; set; }
        IPricelistItemRepository PricelistItem { get; set; }
        IPricelistRepository Pricelist { get; set; }
        IRouteRepository RouteRepository { get; set; }
        IScheduleRepository ScheduleRepository { get; set; }
        IStationRepository StationRepository { get; set; }
        ITicketRepository TicketRepository { get; set; }
        

        int Complete();
    }
}
