using FicticiaSeguros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FicticiaSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonContext _personContext;
        public PersonsController(PersonContext personContext)
        {
            _personContext = personContext;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult>AddPerson(Person person)
        {
            await _personContext.Persons.AddAsync(person);
            await _personContext.SaveChangesAsync();
            return Ok();
        }
    };
}
