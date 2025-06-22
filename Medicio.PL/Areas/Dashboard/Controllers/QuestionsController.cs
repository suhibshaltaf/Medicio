using AutoMapper;
using landing.PL.Helpers;
using Medicio.DAL.Models;
using Medicio.DLL.Data;
using Medicio.PL.Areas.Dashboard.ViewModels.QuestionsVIMO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicio.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]

    [Area("Dashboard")]
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public QuestionsController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var questions = context.questions.ToList();
            var questionsvm = mapper.Map<IEnumerable<QuestionsVM>>(questions);

            return View(questionsvm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QuestionsVM VM)
        {
            if (!ModelState.IsValid)
            {
                return View(VM);

            }

            var questions = mapper.Map<Questions>(VM);
            context.Add(questions);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var questions = context.questions.Find(id);
            if (questions is null)
            {
                return NotFound();
            }
            var questionsvm = mapper.Map<QuestionsVM>(questions);
            return View(questionsvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QuestionsVM vm)
        {
            var questions = context.questions.Find(vm.Id);
            if (questions is null)
            {
                return NotFound();

            }


            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mapper.Map(vm, questions);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var questions = context.questions.Find(id);
            if (questions is null)
            {
                return NotFound();
            }
            var questionsmodel = mapper.Map<QuestionsVM>(questions);
            return View(questionsmodel);
        }


        [HttpPost]

        public IActionResult DeleteConfirmed(int id)
        {

            var questions = context.questions.Find(id);
            if (questions is null)
            {
                return RedirectToAction(nameof(Index));
            }
            context.questions.Remove(questions);
            context.SaveChanges();

            return Ok(new { Message = "questions deleted" });
        }
    }
}
