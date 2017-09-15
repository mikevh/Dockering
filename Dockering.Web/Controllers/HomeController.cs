using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dockering.Web.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Dockering.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            await SendEmails();
            return View();
        }

        private async Task SendEmails() {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("The app", "foo@bar.com"));
            message.To.Add(new MailboxAddress("", "test@fake.com"));
            message.Subject = "here is your mail";

            using(var smtp = new SmtpClient()) {
                await smtp.ConnectAsync("mail", 1025, SecureSocketOptions.None);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
