using AutoMapper;
using Medicio.DAL.Migrations;
using Medicio.DAL.Models;
using Medicio.DLL.Data;
using Medicio.PL.Areas.Dashboard.ViewModels.AppointmentVIMO;
using Medicio.PL.Helpers;
using Medicio.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Medicio.PL.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,IMapper mapper)
        {
            _logger = logger;
            this.context = context; 
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var appointments = context.appointments.Where(a => !a.IsDeleted).ToList();
            var departments = context.departments.Where(d => !d.IsDeleted).ToList();
            var doctors = context.doctors.Where(d => !d.IsDeleted).ToList();
            var features = context.features.Where(f => !f.IsDeleted).ToList();
            var pricingPlans = context.pricings.Where(p => !p.IsDeleted).ToList();
            var faq = context.questions.Where(q => !q.IsDeleted).ToList();
            var services = context.Services.Where(s => !s.IsDeleted).ToList();
            var sliders = context.sliders.Where(s => !s.Isdeleted).ToList();
            var testimonials = context.testimonials.Where(t => !t.IsDeleted).ToList();
            var appointmentVMs = appointments.Select(a => mapper.Map<AppointmentFormVM>(a)).ToList();


            // تعبئة ViewModel بالبيانات
            var viewModel = new HomeViewModel
            {
                Appointments = appointments,
                Departments = departments,
                Doctors = doctors,
                Features = features,
                PricingPlans = pricingPlans,
                FAQ = faq,
                Services = services,
                Sliders = sliders,
                Testimonials = testimonials,
                AppointmentFormVM = appointmentVMs

            };
            bool isAdmin = User.IsInRole("Admin") || User.IsInRole("SuperAdmin");
            ViewBag.IsAdminOrSuperAdmin = isAdmin;

            return View(viewModel);
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
       
        [HttpPost]
        public IActionResult SendEmail(string name, string email, string subject, string message)
        {
            Email emailMessage = new Email
            {
                Recivers = "sohaibshaltafaltrefe1@gmail.com", // البريد المرسل إليه
                Subject = subject,
                Body = $"Name: {name}\nEmail: {email}\n\nMessage:\n{message}"
            };

            try
            {
                // إرسال البريد الإلكتروني
                EmailSettings.SendEmail(emailMessage);
                return Json(new { success = true, message = "Your message has been sent successfully!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "There was an error sending your message. Please try again later." });
            }
        }

    }
}
