using Lab4.Models;
using Lab4.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Lab3.Controllers
{

    public class DictController : Controller
    {

        public ActionResult Index()
        {
            using (UnitOfWork unit = new UnitOfWork())
            {        
                IEnumerable<Contact> contacts = unit.ContactRepository.Get();
                return View(contacts.ToList());
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost, ActionName("Add")]
        public ActionResult AddSave(Contact contact)
        {
            if (ModelState.IsValid)
            {
                using(UnitOfWork unit = new UnitOfWork())
                {
                    unit.ContactRepository.Create(contact);
                    unit.Save();
                }
                return RedirectToAction("Index");

            }

            return View(contact);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Contact contact;
            using (UnitOfWork unit = new UnitOfWork())
            {
                contact =  unit.ContactRepository.FindById(id);
                unit.Save();
            }
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Update")]
        public ActionResult UpdateSave(Contact contact)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork unit = new UnitOfWork())
                {
                    unit.ContactRepository.Update(contact);
                    unit.Save();

                }
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Contact contact;
            using (UnitOfWork unit = new UnitOfWork())
            {
                contact = unit.ContactRepository.FindById(id);
            }
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSave(int id)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                unit.ContactRepository.Remove(unit.ContactRepository.FindById(id));
                unit.Save();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}