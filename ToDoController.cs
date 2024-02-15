using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Infrastructure;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext context;
        private readonly ILogger _logger;

        public ToDoController(ToDoContext context, ILogger<ToDoContext> logger)
        {
            this.context = context;
            this._logger = logger;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            IQueryable<ToDoList> items = from i 
                                         in context.ToDoList
                                         orderby i.Id 
                                         select i;

            List<ToDoList> toDoList = await items.ToListAsync();

            _logger.LogInformation($"Retrieved the TODO items list { items.Count() }", toDoList);

            return View(toDoList.OrderByDescending(x => x.StartDate));
        }

        // GET/todo/create
        public IActionResult Create() => View();

        //POST /todo/create/3
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();
                TempData["Success"] = "The item has been added!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        //Get /todo/edit/4
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ToDoList item = await context.ToDoList.FindAsync(id);

            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }

            return View(item);
        }

        //POST /todo/edit/4
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        //Get /todo/delete/4
        public async Task<IActionResult> Delete(int id)
        {
            ToDoList item = await context.ToDoList.FindAsync(id);

            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }

            return View(item);
        }

        //Get /todo/delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ToDoList item)
        {
            //ToDoList item = await context.ToDoList.FindAsync(id);

            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                context.ToDoList.Remove(item);
                await context.SaveChangesAsync();
                TempData["Success"] = "The item has been deleted!";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Star(int id)
        {
            ToDoList item = await context.ToDoList.FindAsync(id);

            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }

            return View(item);
        }
    }
}
