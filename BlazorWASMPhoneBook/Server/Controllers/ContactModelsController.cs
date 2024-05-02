using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorWASMPhoneBook.Shared.Data;
using BlazorWASMPhoneBook.Shared.Models;

namespace BlazorWASMPhoneBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactModelsController : ControllerBase
    {
        private readonly ContactsDbContext _context;

        public ContactModelsController(ContactsDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactModel>>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/ContactModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactModel>> GetContactModel(long id)
        {
            var contactModel = await _context.Contacts.FindAsync(id);

            if (contactModel == null)
            {
                return NotFound();
            }

            return contactModel;
        }

        // PUT: api/ContactModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactModel(long id, ContactModel contactModel)
        {
            if (id != contactModel.ContactID)
            {
                return BadRequest();
            }

            _context.Entry(contactModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactModel>> PostContactModel(ContactModel contactModel)
        {
            _context.Contacts.Add(contactModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactModel", new { id = contactModel.ContactID }, contactModel);
        }

        // DELETE: api/ContactModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactModel(long id)
        {
            var contactModel = await _context.Contacts.FindAsync(id);
            if (contactModel == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contactModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactModelExists(long id)
        {
            return _context.Contacts.Any(e => e.ContactID == id);
        }
    }
}
