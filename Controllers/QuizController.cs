using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizMachine.Models;
using QuizMachine.Services;
using QuizMachine.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMachine.Controllers
{
    public class QuizController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VeridocsStatesCapitalsContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public QuizController(ILogger<HomeController> logger, VeridocsStatesCapitalsContext context,
                                SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this._context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CreateQuiz model = new CreateQuiz(10, _context);
            return View(model.GenerateQuiz());
        }

        [HttpPost]
        public async Task<IActionResult> Index(QuizViewModel model)
        {
            if (ModelState.IsValid && _signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);

                var grade = new TestResult();
                grade.NumberCorrect = 2;
                grade.UserId = int.Parse(user.Id);
            } else
            {
                ModelState.AddModelError("", "An error occurred.");
                return View(model);
            }

            return RedirectToAction("index", "home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
