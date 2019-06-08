using Antlr.Runtime;
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
    [RoutePrefix("api/Registration")]
    public class RegistrationController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public RegistrationController(IUnitOfWork iUnitOfWork)
        {
            this.unitOfWork = iUnitOfWork;
        }

        [Route("PostRegistration")]
        public IHttpActionResult PostRegistration(RegisterBindingModel registerBinding)
        {
            DateTime.TryParse(registerBinding.BirthdayDate, out DateTime date);

            ApplicationUser user = new ApplicationUser()
            {

                Id = registerBinding.UserName,
                Name = registerBinding.Name,
                LastName = registerBinding.Lastname,
                UserName = registerBinding.UserName,
                Email = registerBinding.Email,
                Address = registerBinding.Address,
                BirthdayDate = date,
                PasswordHash = ApplicationUser.HashPassword(registerBinding.Password),
                PassengerType = registerBinding.PassengerType,
                //State = VerificationType.Rejected
            };

            if (!unitOfWork.PersonRepository.Register(user))
            {
                return this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.Forbidden) { ReasonPhrase = "Username or Email already exists." });
            }

            return Ok();
        }
    }
}
