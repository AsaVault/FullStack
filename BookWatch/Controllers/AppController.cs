using BookWatch.Data;
using BookWatch.Data.Entities;
using BookWatch.Services;
using BookWatch.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWatch.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailSender _mailSender;
        private readonly IBookWatchRepository _repository;

        public AppController(IMailSender mailSender,
            IBookWatchRepository repository)
        {
            _mailSender = mailSender;
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            //throw new InvalidOperationException("Something bad happens");
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Send Mail
                _mailSender.SendMessage("shawn@wildermuth.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult Shop()
        {
            var result = _repository.GetAllProducts();
            return View(result);
        }
    }
}
