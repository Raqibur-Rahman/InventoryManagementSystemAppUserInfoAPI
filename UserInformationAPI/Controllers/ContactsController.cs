using InventoryManagementSystemAppUserInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserInformationAPI.Data;
using UserInformationAPI.Models;

namespace UserInformationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {

            return Ok(await dbContext.Contacts.ToListAsync());
   
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);

        }




        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {

            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                UserName = addContactRequest.UserName,
                Password = addContactRequest.Password,
                FirstName = addContactRequest.FirstName,
                LastName = addContactRequest.LastName,
                FullName = addContactRequest.FullName,
                Email = addContactRequest.Email,
                Phone = addContactRequest.Phone,
                Address = addContactRequest.Address,
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok(contact);


        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
           var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.UserName = updateContactRequest.UserName;
                contact.Password=updateContactRequest.Password;
                contact.FirstName=updateContactRequest.FirstName;
                contact.LastName=updateContactRequest.LastName;
                contact.FullName = updateContactRequest.FullName;
                contact.Email=updateContactRequest.Email;
                contact.Phone = updateContactRequest.Phone;
                contact.Address = updateContactRequest.Address;

                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }

            return NotFound();



        }


    }
}
