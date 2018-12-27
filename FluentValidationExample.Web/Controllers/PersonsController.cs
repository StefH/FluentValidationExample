using FluentValidationExample.Business.Interfaces.Public;
using FluentValidationExample.Business.Models.Public;
using FluentValidationExample.Common.Validation;
using FluentValidationExample.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace FluentValidationExample.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonsController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public PersonsController([NotNull] IPersonService service)
        {
            Guard.NotNull(service, nameof(service));

            _service = service;
        }

        // GET api/persons
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return new[] { new Person { FirstName = "f-1" }, new Person { FirstName = "f-1" } };
        }

        // POST api/persons
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = new PersonDto { First = person.FirstName };
            _service.Add(dto);

            return Ok();
        }
    }
}