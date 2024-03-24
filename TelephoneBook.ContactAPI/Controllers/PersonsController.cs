﻿using Microsoft.AspNetCore.Mvc;
using TelephoneBook.ContactAPI.Dtos.Contact;
using TelephoneBook.ContactAPI.Dtos.Person.Request;
using TelephoneBook.ContactAPI.Services.Abstract;

namespace TelephoneBook.ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        public readonly IPersonService _personService;
        public readonly IContactService _contactService;
        public PersonsController(IPersonService personService, IContactService contactService)
        {
            _personService = personService;
            _contactService = contactService;
        }

        /// <summary>
        /// Get Person List
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-person")]
        public async Task<IActionResult> GetAll()
        {
            var personList = await _personService.GetAllPerson();
            if (personList == null)
                return NotFound(new { Error = "Kişi listesinde veri bulunamadı" });

            return Ok(personList);
        }

        /// <summary>
        /// Add a new Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PersonCreateRequestDto request)
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
            var isProductCreated = await _personService.DeletePerson(personId);

            if (isProductCreated)
                return Ok(isProductCreated);
            else
                return BadRequest();
        }

        /// <summary>
        /// Delete Person Contact by personid
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpDelete("delete-person-contract/{personId}")]
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactCreateRequestDto request)
        {
            var isContactCreated = await _contactService.CreateContact(request);

            if (isContactCreated)
                return Ok(new { Error = "iletisim Bilgisi Başarıyla oluşturuldu" });
            else
                return BadRequest(new { Error = "iletisim Bilgisi oluşturulurken hata ile karşılaşıldı" });
        }

        /// <summary>
        /// Get Person Contacts By PersonId
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpDelete("get-person-contracts/{personId}")]
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
