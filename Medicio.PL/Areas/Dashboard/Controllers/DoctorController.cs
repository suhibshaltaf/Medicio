using AutoMapper;
using landing.PL.Helpers;
using Medicio.DAL.Models;
using Medicio.DLL.Data;
using Medicio.PL.Areas.Dashboard.ViewModels.DoctorsVIMO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Medicio.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DoctorController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var doctors = context.doctors.Include(i =>i.department).ToList();

            return View(mapper.Map<IEnumerable<DoctorsVM>>(doctors));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var departments = context.departments.ToList();
                var vm = new DoctorFormVM
                {
                    Departments = new SelectList(departments, "Id", "Title")

            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DoctorFormVM VM)
        {
            if (!ModelState.IsValid)
            {
                return View(VM);

            }
            VM.ImageName = FileSettings.UploadFile(VM.Image, "Doctors");

            var doctors = mapper.Map<Doctors>(VM);
            context.Add(doctors);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var doctor = context.doctors.Include(d => d.department).FirstOrDefault(d => d.Id == id);
            if (doctor is null)
            {
                return NotFound();
            }

            var departments = context.departments.ToList();
            var doctorvm = mapper.Map<DoctorFormVM>(doctor);
            doctorvm.Departments = new SelectList(departments, "Id", "Title", doctor.DepartmentId); // Populate department dropdown

            return View(doctorvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DoctorFormVM vm)
        {
            var doctors = context.doctors.Find(vm.Id);
            if (doctors is null)
            {
                return NotFound();
            }

            if (vm.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FileSettings.DeleteFile(doctors.ImageName, "Doctors");
                vm.ImageName = FileSettings.UploadFile(vm.Image, "Doctors");
            }

            if (!ModelState.IsValid)
            {
                var departments = context.departments.ToList();
                vm.Departments = new SelectList(departments, "Id", "Title", vm.DepartmentId); // Re-populate departments on validation failure
                return View(vm);
            }

            mapper.Map(vm, doctors);
            doctors.DepartmentId = (int)vm.DepartmentId; // Ensure the DepartmentId is correctly assigned

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
           var item = context.doctors
                      .Include(i => i.department) // Ensure the Portfolio is included
                      .FirstOrDefault(i => i.Id == id);
            if (item is null)
            {
                return NotFound();
            }
            var Itemsmodel = mapper.Map<DoctorDetailsVM>(item);
            return View(Itemsmodel);
        }


        [HttpPost]

        public IActionResult DeleteConfirmed(int id)
        {

            var doctors = context.doctors.Find(id);
            if (doctors is null)
            {
                return RedirectToAction(nameof(Index));
            }
            context.doctors.Remove(doctors);
            context.SaveChanges();

            return Ok(new { Message = "doctor deleted" });
        }
    }
}
