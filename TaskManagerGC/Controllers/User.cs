using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TaskManagerGC.Data;

namespace TaskManagerGC.Controllers
{
    public class User : Controller
    {
        private readonly ApplicationDbContext _context;

        public User(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: UserController
        public async Task<IActionResult> Index()
        { 
            return View(await _context.Users.ToListAsync());
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {
            return Redirect("/Task/Index");
        } 
    }
}
