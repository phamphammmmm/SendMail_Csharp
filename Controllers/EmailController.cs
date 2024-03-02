using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using SendMail.Service;
using SendMail.Models;

namespace SendMail.Controllers
{
    [Route("/api/mail")]
    [ApiController]
    public class EmailController : ControllerBase
    {
         private readonly IEmailService _emailService;
         public EmailController(IEmailService emailService)
         {
              _emailService = emailService;
         }

          [HttpPost]
          public IActionResult SendEmail(Email request)
          {
              _emailService.SendEmail(request);
              return Ok("Email sent successfully");
          }

    }
}
