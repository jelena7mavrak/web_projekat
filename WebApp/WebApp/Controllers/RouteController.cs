using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Persistence.UnitOfWork;
using static WebApp.Models.Enums;

namespace WebApp.Controllers
{
    [RoutePrefix("api/Route")]
    public class RouteController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public RouteController(IUnitOfWork iUnitOfWork)
        {
            this.unitOfWork = iUnitOfWork;

        }

        [ResponseType(typeof(string))]
        [Route("GetRoute/{type}")]
        public IHttpActionResult GetRoute(RouteType type)
        {

            string station = unitOfWork.RouteRepository.GetRoute(type);

            return Ok(station);
            
        }
    }
}
