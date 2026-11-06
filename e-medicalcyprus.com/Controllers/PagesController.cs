using Microsoft.AspNetCore.Mvc;
using e_medicalcyprus.com.Models;
using System.Net.Mail;

namespace e_medicalcyprus.com.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Webminars()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Webminars(NewsletterModel model )
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress("info@emedicalinstruments.com"),
                Subject = "Webminar Register",
                Body = $"<B>Name</b>: {model.Name}.<BR><b>Email</b>: {model.Email}",
                IsBodyHtml = true
            };
            message.To.Add(new MailAddress("info@emedicalinstruments.com"));
            Tools.SendEmail(message);
            ViewData["Confirm"] = "Registration successful!";
            return View();
        }
        public IActionResult WhyUs()
        {
            return View();
        }
        public IActionResult Certified()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
