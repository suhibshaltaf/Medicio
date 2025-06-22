using AutoMapper;
using landing.PL.Helpers;
using Medicio.DAL.Models;
using Medicio.DLL.Data;
using Medicio.PL.Areas.Dashboard.ViewModels.ServiceVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.TestimonialsVIMO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicio.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]

    [Area("Dashboard")]

    public class TestimonialsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TestimonialsController(ApplicationDbContext context,IMapper mapper  )
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var Testimonials = context.testimonials.ToList();
            var Testimonialsvm = mapper.Map<IEnumerable<TestimonialsVM>>(Testimonials);

            return View(Testimonialsvm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TestimonialsFormVM VM)
        {
            if (!ModelState.IsValid)
            {
                return View(VM);

            }
            VM.ImageName = FileSettings.UploadFile(VM.Image, "Testimonials");
            var Testimonials = mapper.Map<Testimonials>(VM);
            context.Add(Testimonials);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var Testimonials = context.testimonials.Find(id);
            if (Testimonials is null)
            {
                return NotFound();
            }
            var Testimonialsvm = mapper.Map<TestimonialsFormVM>(Testimonials);
            return View(Testimonialsvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TestimonialsFormVM vm)
        {
            var Testimonials = context.testimonials.Find(vm.Id);
            if (Testimonials is null)
            {
                return NotFound();

            }
            if (vm.Image is null)
            {
                ModelState.Remove("Image");


            }
            else
            {
                FileSettings.DeleteFile(Testimonials.ImageName, "Testimonials");
                vm.ImageName = FileSettings.UploadFile(vm.Image, "Testimonials");

            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mapper.Map(vm, Testimonials);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var Testimonials = context.testimonials.Find(id);
            if (Testimonials is null)
            {
                return NotFound();
            }
            var Testimonialsmodel = mapper.Map<TestimonialsDetailsVM>(Testimonials);
            return View(Testimonialsmodel);
            }


        [HttpPost]

        public IActionResult DeleteConfirmed(int id)
        {

            var Testimonials = context.testimonials.Find(id);
            if (Testimonials is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(Testimonials.ImageName, "Testimonials");
            context.testimonials.Remove(Testimonials);
            context.SaveChanges();

            return Ok(new { Message = "Testimonials deleted" });
        }
    }
}
