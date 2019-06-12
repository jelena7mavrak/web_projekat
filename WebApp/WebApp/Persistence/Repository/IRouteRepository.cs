using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using WebApp.Models;
using static WebApp.Models.Enums;

namespace WebApp.Persistence.Repository
{
   public interface IRouteRepository : IRepository<Line, int>
    {
        string GetRoute(RouteType type);
    }
}
