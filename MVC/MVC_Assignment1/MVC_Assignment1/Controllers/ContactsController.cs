using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Assignment1.Models;
using MVC_Assignment1.Repositories;
using System.Threading.Tasks;

namespace MVC_Assignment1.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactsController()
        {
            _repository = new ContactRepository();
        }

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            var contacts = await _repository.GetAllAsync();
            return View(contacts);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            var contacts = await _repository.GetAllAsync();
            var contact = contacts.Find(c => c.Id == id);

            if (contact == null)
                return HttpNotFound();

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}