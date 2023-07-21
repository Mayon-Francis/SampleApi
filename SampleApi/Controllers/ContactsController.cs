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

        [HttpPut("{id:guid}", Name = "UpdateContact")]
        public async Task<ActionResult<Contact>> UpdateContact([FromRoute] Guid id, UpdateContactDto updateContactReq)
        {
            Contact? contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound("Contact not found");
            }

            contact.FullName = updateContactReq.FullName;
            contact.Email = updateContactReq.Email;
            contact.Phone = updateContactReq.Phone;
            contact.Address = updateContactReq.Address;

            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpGet("{id:guid}", Name = "GetSingleContact")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contact))]
        public async Task<ActionResult<Contact>> GetSingleContact([FromRoute] Guid id)
        {
            Contact? contact = await dbContext.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound("Contact not found");
            }
            else
            {
                return Ok(contact);
            }
        }

        [HttpDelete("{id:guid}", Name = "DeleteContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteContact([FromRoute] Guid id) {
            Contact? contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null) {
                return NotFound("Contact not found");
            }

            dbContext.Contacts.Remove(contact);
            await dbContext.SaveChangesAsync();
    
            return Ok(contact);
        }
    }
}