using Lab8a.Model;
using Lab8a.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab8a.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class PhoneController : Controller
        {
            private readonly ILogger<PhoneController> _logger;
            private readonly GenericRepository<Phone> _phoneRepository;

            public PhoneController(ILogger<PhoneController> logger, GenericRepository<Phone> genericRepository)
            {
                _logger = logger;
                _phoneRepository = genericRepository;
            }

          
          
            [HttpGet]
            [Route("")]
            public ActionResult Index()
            {
                return View(_phoneRepository.GetAll());
            }

            [HttpGet]
            [Route("add")]
            public ActionResult Add()
            {
                return View();
            }

            [HttpGet]
            [Route("update/{id:int}")]
            public ActionResult Update(int id)
            {
                var contact = _phoneRepository.GetById(id);

                return View(contact);
            }

            [HttpGet]
            [Route("delete/{id:int}")]
            public ActionResult Delete(int id)
            {
                var contact = _phoneRepository.GetById(id);

                return View(contact);
            }


  
            [HttpPost]
            [ProducesResponseType(typeof(Phone), 200)]
            [Route("add")]
            public RedirectResult AddPhone([FromForm]  Phone phone)
            {
                _phoneRepository.Add(phone);
                _phoneRepository.SaveChanges();
                return Redirect("/api/Phone");
            }


            [HttpPost]
            [ProducesResponseType(typeof(Phone), 200)]
            [Route("update/{id:int}")]
            public RedirectResult EditPhone([FromForm] Phone phone)
            {
                _phoneRepository.Update(phone);

                return Redirect("/api/Phone");
            }


            [HttpPost]
            [ProducesResponseType(typeof(Phone), 200)]
            [Route("delete/{id:int}")]
            public RedirectResult DeletePhone(int id)
            {
                Phone phone = _phoneRepository.GetById(id);
                _phoneRepository.Remove(phone);
                _phoneRepository.SaveChanges();

                return Redirect("/api/Phone");
            }
        }
}
