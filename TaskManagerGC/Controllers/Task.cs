using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerGC.Data;
using TaskManagerGC.Models;

namespace TaskManagerGC.Controllers
{
    public class Task : Controller
    {
        private readonly ApplicationDbContext _context;

        public Task(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: TaskController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.ToListAsync());
        }

        // GET: TaskController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if(id == Guid.Empty)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            
            if(task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Title, Description, Completed, DueDate")] Models.Task task)
        {
            try
            {
                if (ModelState.IsValid && task != null)
                {
                    _context.Tasks.Add(task);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return View(task);
                }
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }

        // GET: TaskController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if(id == Guid.Empty)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);

            if(task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, Title, Description, Completed, DueDate")] Models.Task task, IFormCollection collection)
        {
            if(id != task.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Tasks.Update(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!_context.Tasks.Any(x => x.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw e;
                }
            }
        }

        // POST: Task/Delete/5
        [HttpPost("Task/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);

            if(task == null)
            {
                return NotFound();
            }

            try
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!_context.Tasks.Any(x => x.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw e;
                }
            }
        }
    }
}
