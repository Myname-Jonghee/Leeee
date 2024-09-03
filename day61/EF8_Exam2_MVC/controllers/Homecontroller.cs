using EF8_Exam2_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EF8_Exam2_MVC.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;
        private readonly PeopleDbContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(PeopleDbContext context)
        {
            _context = context;
        }

        //public IActionResult Index() //view
        //{
        //    var peoples = _context.Peoples.ToList();
        //    return View(peoples);
        //}

        
        //[HttpPost]
        //public IActionResult Create(Peoples people)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Student.Add(people);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View(people);
        //}
        public IActionResult Index()
        {
            var people = _context.Peoples.ToList<People>();
            return View(people);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(People people)
        {
            if (ModelState.IsValid)
            {
                await _context.Peoples.AddAsync(people);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(people);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Peoples == null)
            {
                return NotFound();
            }

            var peopleData = await _context.Peoples.FirstOrDefaultAsync(x => x.Id == id);

            if (peopleData == null)
            {
                return NotFound();
            }

            return View(peopleData);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peoples == null)
            {
                return NotFound();
            }

            var peopleData = await _context.Peoples.FindAsync(id);

            if (peopleData == null)
            {
                return NotFound();
            }
            return View(peopleData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, People people)
        {
            if (id != people.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //_context.Student.Update(std);
                _context.Update(people);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(people);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peoples == null)
            {
                return NotFound();
            }
            var peopleData = await _context.Peoples.FirstOrDefaultAsync((x => x.Id == id));

            if (peopleData == null)
            {
                return NotFound();
            }
            return View(peopleData);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var peopleData = await _context.Peoples.FindAsync(id);
            if (peopleData != null)
            {
                _context.Peoples.Remove(peopleData);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
