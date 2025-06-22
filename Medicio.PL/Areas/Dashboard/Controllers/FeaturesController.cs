using AutoMapper;
using Medicio.DAL.Models;
using Medicio.DLL.Data;
using Medicio.PL.Areas.Dashboard.ViewModels.FeaturesVIMO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicio.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]

    [Area("Dashboard")]
    public class FeaturesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public FeaturesController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var Features = context.features.ToList();
            var Featuresvm = mapper.Map<IEnumerable<FeaturesVM>>(Features);

            return View(Featuresvm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FeaturesFormVM VM)
        {
            if (!ModelState.IsValid)
            {
                return View(VM);

            }

            var Features = mapper.Map<Features>(VM);
            context.Add(Features);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var Features = context.features.Find(id);
            if (Features is null)
            {
                return NotFound();
            }
            var Featuresvm = mapper.Map<FeaturesFormVM>(Features);
            return View(Featuresvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FeaturesFormVM vm)
        {
            var Features = context.features.Find(vm.Id);
            if (Features is null)
            {
                return NotFound();

            }


            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mapper.Map(vm, Features);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var Features = context.features.Find(id);
            if (Features is null)
            {
                return NotFound();
            }
            var Featuresmodel = mapper.Map<FeaturesDetailsVM>(Features);
            return View(Featuresmodel);
        }


        [HttpPost]

        public IActionResult DeleteConfirmed(int id)
        {

            var Features = context.features.Find(id);
            if (Features is null)
            {
                return RedirectToAction(nameof(Index));
            }
            context.features.Remove(Features);
            context.SaveChanges();

            return Ok(new { Message = "Features deleted" });
        }
    }
}
