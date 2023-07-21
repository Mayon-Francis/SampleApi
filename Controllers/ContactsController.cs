using Microsoft.AspNetCore.Mvc;
using SampleApi.Data;
using SampleApi.Models;
using SampleApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace SampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly SampleAPIDbContext dbContext;
        public ContactsController(SampleAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "GetContacts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Contact>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Contact>> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpPost(Name = "AddContact")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Contact))]
        public async Task<ActionResult> AddContact(AddContactDto addContactReq)
        {
            Contact contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FullName = addContactReq.FullName,
                Email = addContactReq.Email,
                Phone = addContactReq.Phone,
                Address = addContactReq.Address
            };
            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return CreatedAtRoute("GetContacts", new { id = contact.Id }, contact);
        }
    }
}