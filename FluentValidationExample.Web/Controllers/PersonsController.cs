using System.Collections.Generic;
using FluentValidationExample.Business.Interfaces.Public;
using FluentValidationExample.Business.Models.Public;
using FluentValidationExample.Common.Validation;
using FluentValidationExample.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonsController(IPersonService service)
        {
            Guard.NotNull(service, nameof(service));

            _service = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return new [] { new Person { FirstName = "f-1" }, new Person{ FirstName = "f-1" } };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                var dto = new PersonDto {First = person.FirstName};
                _service.Add(dto);
            }
        }
    }
}