using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Viventum.Models;
using Viventum.Options;
using Viventum.Services.Interfaces;

namespace Viventum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly EmailSenderSettings _emailSenderSettings;
        private readonly IHostingEnvironment _environment;
        public HomeController(
            ILogger<HomeController> logger,
            IEmailSender emailSender,
            EmailSenderSettings emailSenderSettings,
            IHostingEnvironment environment)
        {
            _logger = logger;
            _emailSender = emailSender;
            _emailSenderSettings = emailSenderSettings;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> ContactForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tmpl = System.IO.File.ReadAllText(
                       Path.Combine(_environment.WebRootPath,
                       "html/email.tpl"));
                    var html =
                        tmpl.Replace("{{Name}}", model.Name)
                            .Replace("{{Company}}", model.Company)
                            .Replace("Email", model.Email)
                            .Replace("Subject", model.Subject)
                            .Replace("Message", model.Message);

                    if (!string.IsNullOrWhiteSpace(_emailSenderSettings.FolderPath))
                    {
                        System.IO.File.WriteAllText(
                            Path.Combine(_environment.ContentRootPath,
                            "contact-forms",
                            $"{DateTime.Now.ToString().Replace(".", "-").Replace(" ", "-").Replace(":", "-")}.html"),
                            html);
                    }

                    await _emailSender.SendEmailToAdminAsync("New contact request", html);
                }
                catch (Exception e)
                {
                    return PartialView("_Error");
                }

                return PartialView("_Success");
            }

            return PartialView("_ContactForm", new ContactModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
