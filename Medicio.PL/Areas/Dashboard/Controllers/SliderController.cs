using AutoMapper;
using landing.PL.Helpers;
using Medicio.DAL.Models;
using Medicio.DLL.Data;
using Medicio.PL.Areas.Dashboard.ViewModels.SliderVIMO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace Medicio.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]

    [Area("Dashboard")]
    public class SliderController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SliderController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
          public IActionResult Index()
        {
            var Slider = context.sliders.ToList();
            var Slidervm = mapper.Map<IEnumerable<SliderVM>>(Slider);

            return View(Slidervm);
        }
        [HttpGet]
        public IActionResult Create () {
            return View();
          }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SliderFormVM VM)
        {
            if (!ModelState.IsValid) {             return View(VM);

            }
            VM.ImageName = FileSettings.UploadFile(VM.Image, "Slider");
            var Slider = mapper.Map<Slider>(VM);
            context.Add(Slider);
            context.SaveChanges();
            return RedirectToAction(nameof(Index)); 

        }
        public IActionResult Edit(int id)
        {
            var Slider = context.sliders.Find(id);
            if (Slider is null)
            {
                return NotFound();
            }
            var Slidervm = mapper.Map<SliderFormVM>(Slider);
            return View(Slidervm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SliderFormVM vm)
        {            var Slider = context.sliders.Find(vm.Id);
            if (Slider is null)
            {
                return NotFound();

            }
            if(vm.Image is null)
            {
                ModelState.Remove("Image");


            }
            else
            {
                FileSettings.DeleteFile(Slider.ImageName, "Slider");
            vm.ImageName = FileSettings.UploadFile(vm.Image, "Slider");

            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
           
            mapper.Map(vm, Slider);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
            [HttpGet]
        public IActionResult Details(int id)
        {
            var Slider = context.sliders.Find(id);
            if (Slider is null)
            {
                return NotFound();
            }
            var Slidermodel = mapper.Map<SliderDetailsVM>(Slider);
            return View(Slidermodel);
        }

       
        [HttpPost]
     
        public IActionResult DeleteConfirmed(int id) {

            var Slider = context.sliders.Find(id);
            if (Slider is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(Slider.ImageName, "Slider");
            context.sliders.Remove(Slider);
            context.SaveChanges();

            return Ok(new { Message = "Slider deleted" });
        }
         
    }
}
