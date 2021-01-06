using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceTimesApplication.Data;
using RaceTimesApplication.Models;

namespace RaceTimesApplication.Controllers
{
    public class UserTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewToReturn = _context.UserTimes
                .Where(ut => ut.IsApproved)
                .OrderBy(ut => ut.Time)
                .ToListAsync();

            return View(await viewToReturn);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Time,IsApproved")] UserTimeModel userTimeModel)
        {
            if (ModelState.IsValid)
            {
                userTimeModel.Id = Guid.NewGuid();
                _context.Add(userTimeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTimeModel);
        }
    }
}
