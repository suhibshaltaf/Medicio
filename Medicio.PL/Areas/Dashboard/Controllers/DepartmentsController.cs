using AutoMapper;
using landing.PL.Helpers;
using Medicio.DAL.Models;
using Medicio.DLL.Data;
using Medicio.PL.Areas.Dashboard.ViewModels.DepartmentsVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.ServiceVIMO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicio.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]

    [Area("Dashboard")]
    
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DepartmentsController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var department=context.departments.ToList();
            var departmentvm = mapper.Map<IEnumerable<DepartmentsVM>>(department);
            return View(departmentvm);
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(DepartmentsFormVM vM)
        {
            if (!ModelState.IsValid)
            {
                return View(vM);

            }
            vM.ImageName = FileSettings.UploadFile(vM.Image, "Departments");
            var departments = mapper.Map<Departments>(vM);
            context.Add(departments);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var Departments = context.departments.Find(id);
            if (Departments is null)
            {
                return NotFound();
            }
            var Departmentsvm = mapper.Map<DepartmentsFormVM>(Departments);
            return View(Departmentsvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentsFormVM vm)
        {
            var departments = context.departments.Find(vm.Id);
            if (departments is null)
            {
                return NotFound();

            }
            if (vm.Image is null)
            {
                ModelState.Remove("Image");


            }
            else
            {
                FileSettings.DeleteFile(departments.ImageName, "Departments");
                vm.ImageName = FileSettings.UploadFile(vm.Image, "Departments");

            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mapper.Map(vm, departments);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var departments = context.departments.Find(id);
            if (departments is null)
            {
                return NotFound();
            }
            var departmentsmodel = mapper.Map<DepartmentsDetailsVM>(departments);
            return View(departmentsmodel);
        }[HttpPost]

        public IActionResult DeleteConfirmed(int id)
        {

            var departments = context.departments.Find(id);
            if (departments is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(departments.ImageName, "Departments");
            context.departments.Remove(departments);
            context.SaveChanges();

            return Ok(new { Message = "departments deleted" });
        }


    }
}
