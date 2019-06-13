using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Persistence.UnitOfWork;
using static WebApp.Models.Enums;

namespace WebApp.Controllers
{
    [RoutePrefix("api/Schedule")]
    public class ScheduleController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public ScheduleController(IUnitOfWork iUnitOfWork)
        {
            this.unitOfWork = iUnitOfWork;

        }

        [ResponseType(typeof(List<string>))]
        [Route("GetLines1/{routeT}")]
        public IHttpActionResult GetLines1(RouteType routeT)
        {
            List<string> station = unitOfWork.RouteRepository.GetRouteS(routeT);

            return Ok(station);
        }
       
        [ResponseType(typeof(string))]
        [Route("GetSchedule/{routeT}/{dayT}/{line}")]
        public IHttpActionResult GetSchedule(RouteType routeT, DayType dayT, string line) {

            //string lineName = unitOfWork.RouteRepository.GetRoute(routeT);
            string sch = unitOfWork.ScheduleRepository.GetSchedule(routeT, dayT, line);


            return Ok(sch);
        }


        [ResponseType(typeof(LineBindingModel))]
        [HttpGet]
        [Route("GetLineData/{lineNumber}")]
        public IHttpActionResult GetLineData(int lineNumber)
        {
            Line line = unitOfWork.RouteRepository.GetLineByLineNumber(lineNumber);
            LineBindingModel lineBindingModel = new LineBindingModel() { Id = line.Id, RouteNumber = line.RouteNumber, RouteType = line.RouteType };
            
            

            return Ok(lineBindingModel);
        }


        [ResponseType(typeof(IEnumerable<int>))]
        [HttpGet]
        [Route("GetAllLines")]
        public IHttpActionResult GetAllLines()
        {
            List<int> ret = unitOfWork.RouteRepository.GetAllLines();
            return Ok(ret);
        }
    }
}
