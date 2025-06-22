using AutoMapper;
using landing.PL.Helpers;
using Medicio.DAL.Models;
using Medicio.DLL.Data;
using Medicio.PL.Areas.Dashboard.ViewModels.AppointmentVIMO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Medicio.PL.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("Dashboard")]
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AppointmentController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var appointments = context.appointments.ToList();
            var appointmentVM = mapper.Map<List<AppointmentVM>>(appointments); // Change here to List<AppointmentVM>

            return View(appointmentVM);
        }
        [HttpGet]
        public IActionResult Create(int? departmentId)
        {
            // تحويل قائمة الأقسام إلى SelectList
            ViewBag.Departments = new SelectList(context.departments.ToList(), "Id", "Title");

            // إذا تم تحديد قسم، اجلب الأطباء المرتبطين بهذا القسم
            if (departmentId.HasValue)
            {
                ViewBag.Doctors = new SelectList(context.doctors
                    .Where(d => d.DepartmentId == departmentId.Value)
                    .ToList(), "Id", "Name");
            }
            else
            {
                // إذا لم يتم تحديد قسم، اجلب جميع الأطباء
                ViewBag.Doctors = new SelectList(context.doctors.ToList(), "Id", "Name");
            }

            var appointmentFormVM = new AppointmentFormVM
            {
                AppointmentDate = DateTime.Today // تعيين التاريخ الافتراضي
            };

            return View(appointmentFormVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentFormVM appointmentFormVM)
        {
            if (ModelState.IsValid)
            {
                // التحقق من أن AppointmentDate ليس في الماضي
                if (appointmentFormVM.AppointmentDate.Date < DateTime.Today)
                {
                    ModelState.AddModelError("AppointmentDate", "The appointment date must be today or in the future.");
                }
                else
                {
                    var appointment = mapper.Map<Appointment>(appointmentFormVM);
                    context.appointments.Add(appointment);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            // If model state is invalid, you are returning the AppointmentFormVM here.
            ViewBag.Departments = new SelectList(context.departments.ToList(), "Id", "Title");
            ViewBag.Doctors = new SelectList(context.doctors.ToList(), "Id", "Name");
            return View(appointmentFormVM); // This is correct for the Create view.
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment = context.appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            var appointmentFormVM = mapper.Map<AppointmentFormVM>(appointment);
            ViewBag.Departments = new SelectList(context.departments.ToList(), "Id", "Title");
            ViewBag.Doctors = new SelectList(context.doctors
                .Where(d => d.DepartmentId == appointmentFormVM.DepartmentId)
                .ToList(), "Id", "Name");

            return View(appointmentFormVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AppointmentFormVM appointmentFormVM)
        {
            if (ModelState.IsValid)
            {
                var appointment = context.appointments.FirstOrDefault(a => a.Id == appointmentFormVM.Id);
                if (appointment == null)
                {
                    return NotFound();
                }

                mapper.Map(appointmentFormVM, appointment);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            // If model state is invalid, repopulate the ViewBag
            ViewBag.Departments = new SelectList(context.departments.ToList(), "Id", "Title");
            ViewBag.Doctors = new SelectList(context.doctors
                .Where(d => d.DepartmentId == appointmentFormVM.DepartmentId)
                .ToList(), "Id", "Name");
            return View(appointmentFormVM);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var appointment = context.appointments
          .Include(a => a.Doctor)      // جلب بيانات الطبيب
          .Include(a => a.Department)   // جلب بيانات القسم
          .FirstOrDefault(a => a.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            var appointmentDetailsVM = mapper.Map<AppointmentDetailsVM>(appointment);
            return View(appointmentDetailsVM);
        }

        [HttpGet]
        public IActionResult GetDoctorsByDepartment(int departmentId)
        {
            var doctors = context.doctors
                .Where(d => d.DepartmentId == departmentId)
                .Select(d => new
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToList();

            return Json(doctors);
        }


        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = context.appointments.Find(id);
            if (appointment is null)
            {
                return RedirectToAction(nameof(Index));
            }
            context.appointments.Remove(appointment);
            context.SaveChanges();

            return Ok(new { Message = "Appointment deleted" });
        }
    }
}
