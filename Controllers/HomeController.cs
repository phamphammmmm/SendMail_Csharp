using Microsoft.AspNetCore.Mvc;
using SendMail.Models;
using System.Diagnostics;

namespace SendMail.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var receiver = "vavix36221@molyg.com";
            var subject = "Test";
            var message = "Hello world";

            //await _emailSender.SendEmailAsync(receiver, subject, message);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
