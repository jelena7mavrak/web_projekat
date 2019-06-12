using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;
using WebApp.Persistence.UnitOfWork;
using static WebApp.Models.Enums;

namespace WebApp.Controllers
{
    [RoutePrefix("api/Ticket")]
    public class TicketController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public TicketController(IUnitOfWork iUnitOfWork)
        {
            this.unitOfWork = iUnitOfWork;

        }

        [HttpPost]
        [Route("BuyTicket/{type}")]
        public IHttpActionResult BuyTicket(TicketType type)
        {
            
            int itemId = unitOfWork.ItemRepository.GetIdForType(type);
            int pricelistId = unitOfWork.PricelistRepository.GetPricelistIdActive();
            int pricelistItemId = unitOfWork.PricelistItemRepository.GetPricelistItemId(pricelistId, itemId);
            double priceTicket = unitOfWork.PricelistItemRepository.GetTicketPriceForType(pricelistId, itemId);



            if (type == 0)
            {

                Ticket t = unitOfWork.TicketRepository.BuyTicket(priceTicket, pricelistId);
                return Ok("Ticket successfully bought");
            }
            else
            {
                return ResponseMessage(new HttpResponseMessage() { StatusCode = HttpStatusCode.Forbidden, ReasonPhrase = "You can buy only hourly ticket!" });
            }

        }
    }
}
