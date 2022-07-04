using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vroom.Data;
using Vroom.Models;

namespace Vroom.Controllers
{
    public class MakeController : Controller
    {
        private readonly AppDbContext _db;
            public MakeController(AppDbContext db)
        {
                _db = db;
        }
        public async Task<IActionResult> Bikes()
        {
            var data = await _db.Makes.ToListAsync();
            return View(data);
        }


        //http get by default
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Make make)
        {
            if(ModelState.IsValid)
            {
                _db.Add(make);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Bikes));
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var data = _db.Makes.Find(Id);
            if (data==null)
            {
                return NotFound();
            }
            _db.Makes.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Bikes));
            
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var data =await _db.Makes.FindAsync(Id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Update(make);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Bikes));
            }
            return View();
        }
    }
}
