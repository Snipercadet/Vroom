using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Vroom.Data;
using Vroom.Models;
using Vroom.Models.ViewModels;

namespace Vroom.Controllers
{
    public class ModelController : Controller
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public ModelViewModel ModelVM { get; set; }
        public ModelController(AppDbContext db)
        {
            _db = db;
            ModelVM = new ModelViewModel()
            { 
                Makes = _db.Makes.ToList(),
                Model = new Model()
            };

        }


        public async Task<IActionResult> Index()
        {
            var model = _db.Models.Include(m => m.Make);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View(ModelVM); 
        }

       
      
        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreatePost()
        {
            
        
            if (ModelState.IsValid)
            {
               
                

                await _db.Models.AddAsync(ModelVM.Model);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(ModelVM);
        }
         

    }
}
