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
    }
}
