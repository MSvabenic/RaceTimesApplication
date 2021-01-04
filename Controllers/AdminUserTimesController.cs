using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaceTimesApplication.Data;
using RaceTimesApplication.Models;

namespace RaceTimesApplication.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminUserTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminUserTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataToReturn = _context.UserTimes
                .Where(ut => !ut.IsApproved)
                .OrderBy(ut => ut.CreationTime)
                .ToListAsync();

            return View(await dataToReturn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userTimeModel = await _context.UserTimes.FindAsync(id);
            _context.UserTimes.Remove(userTimeModel);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(Guid id)
        {
            var userTimeModel = await _context.UserTimes.FindAsync(id);
            userTimeModel.IsApproved = true;
            _context.UserTimes.Update(userTimeModel);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool UserTimeModelExists(Guid id)
        {
            return _context.UserTimes.Any(e => e.Id == id);
        }
    }
}
