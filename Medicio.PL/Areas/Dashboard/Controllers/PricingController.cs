using AutoMapper;
using Medicio.DAL.Models;
using Medicio.DLL.Data;
using Medicio.PL.Areas.Dashboard.ViewModels.PricingVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.QuestionsVIMO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicio.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]

    [Area("Dashboard")]
    public class PricingController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PricingController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var pricingList = context.pricings.ToList();
            var pricingVMList = mapper.Map<List<PricingVM>>(pricingList);
            return View(pricingVMList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PricingFormVM vm)
        {
            if (ModelState.IsValid)
            {
                var pricing = mapper.Map<Pricing>(vm);
                context.pricings.Add(pricing);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pricing = context.pricings.Find(id);
            if (pricing == null)
            {
                return NotFound();
            }
            var vm = mapper.Map<PricingFormVM>(pricing);
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PricingFormVM vm)
        {
            if (ModelState.IsValid)
            {
                var pricing = mapper.Map<Pricing>(vm);
                context.pricings.Update(pricing);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var pricing = context.pricings.Find(id);
            if (pricing == null)
            {
                return NotFound();
            }
            var vm = mapper.Map<PricingDetailsVM>(pricing);
            return View(vm);
        }

        
        public IActionResult DeleteConfirmed(int id)
        {
            var pricing = context.pricings.Find(id);
            if (pricing == null)
            {
                return NotFound();
            }
            context.Remove(pricing);
            context.SaveChanges();
            return Ok(new { Message = "pricing deleted" });
        }
    }
}
