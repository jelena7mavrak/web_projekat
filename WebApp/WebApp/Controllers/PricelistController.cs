using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    [RoutePrefix("api/Pricelist")]
    public class PricelistController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public PricelistController(IUnitOfWork iUnitOfWork)
        {
            this.unitOfWork = iUnitOfWork;
           
        }

        [ResponseType(typeof(double))]
        [Route("GetPricelist")]
        public IHttpActionResult GetPricelist(TicketType ticketT)
        {
            int pricelistId = unitOfWork.PricelistRepository.GetPricelistIdActive();
            
            int ticketId = unitOfWork.ItemRepository.GetIdForType(ticketT);
            double ticketPrice=unitOfWork.PricelistItemRepository.GetTicketPriceForType(pricelistId, ticketId);


            return Ok(ticketPrice);
        }

        [HttpPost]
        [ResponseType(typeof(int))]
        [Route("AddPricelist")]
        public IHttpActionResult AddPricelist(PricelistBindingModel pricelist)
        {
            int pricelistId = unitOfWork.PricelistRepository.AddPricelist(pricelist);
            return Ok(pricelistId);

        }
        /*
        // GET: api/Pricelist
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<Pricelist> GetPricelist()
        {
            return _unitOfWork.PricelistRepository.GetAll();
        }

        // GET: api/Days/5
        [ResponseType(typeof(Pricelist))]
        public IHttpActionResult GetDay(int id)
        {
            Pricelist p = _unitOfWork.PricelistRepository.Get(id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // PUT: api/Days/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDay(int id, Pricelist p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p.Id)
            {
                return BadRequest();
            }


            

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Days
        [ResponseType(typeof(Pricelist))]
        public IHttpActionResult PostPricelist(Pricelist p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.PricelistRepository.Add(p);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = p.Id }, p);
        }

        // DELETE: api/Days/5
        [ResponseType(typeof(Pricelist))]
        public IHttpActionResult DeleteDay(int id)
        {
            Pricelist p = _unitOfWork.PricelistRepository.Get(id);
            if (p == null)
            {
                return NotFound();
            }

            _unitOfWork.PricelistRepository.Remove(p);
            _unitOfWork.Complete();

            return Ok(p);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }*/

       
    }
}

