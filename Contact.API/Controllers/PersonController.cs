﻿using Contact.Application.Dtos.Person.Request;
using Contact.Application.Models.Dtos.Contact;
using Contact.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly IPersonService _personService;
        public readonly IContactService _contactService;
        public PersonController(IPersonService personService, IContactService contactService)
        {
            _personService = personService;
            _contactService = contactService;
        }
        /// <summary>
        /// Add a new Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create-person")]
        public async Task<IActionResult> Create([FromBody] PersonCreateRequestDto request)
        {
            var isPersonCreated = await _personService.CreatePerson(request);

            if (isPersonCreated)
                return Ok(isPersonCreated);
            else
                return BadRequest();
        }

        /// <summary>
        /// Delete Person by id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpDelete("{personId}")]
        public async Task<IActionResult> DeletePerson(Guid personId)
        {
            var isPersonCreated = await _personService.DeletePerson(personId);

            return Ok(isPersonCreated);
        }

        /// <summary>
        /// Get Person List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personList = await _personService.GetAllPerson();
            if (personList == null)
                return NotFound(new { IsSucceed = false });

            return Ok(personList);
        }

        /// <summary>
        /// Delete Person Contact by personid
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpDelete("{personId}/contract")]
        public async Task<IActionResult> DeletePersonContact(Guid personId)
        {
            var isProductCreated = await _personService.RemovePersonContactByPersonId(personId);

            if (isProductCreated)
                return Ok(isProductCreated);
            else
                return BadRequest();
        }

        /// <summary>
        /// Add a new Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create-contact")]
        public async Task<IActionResult> Create([FromBody] ContactCreateRequestDto request)
        {
            var isContactCreated = await _contactService.CreateContact(request);

            if (isContactCreated)
                return Ok(new { IsSucceed = true });
            else
                return BadRequest(new { IsSucceed = false });
        }

        /// <summary>
        /// Get Person Contacts By PersonId
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpGet("{personId}/contract")]
        public async Task<IActionResult> GetPersonContactsByPersonId(Guid personId)
        {
            var result = await _personService.GetPersonContactsByPersonId(personId);

            if (result.Any())
                return Ok(result);
            else
                return BadRequest();
        }
    }
}
