using ContactApp.Data;
using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ContactController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var contacts = await _db.Contacts.ToListAsync();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Add(contact);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contact);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _db.Contacts.FindAsync(id);
            if (contact != null)
            {
                _db.Contacts.Remove(contact);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
