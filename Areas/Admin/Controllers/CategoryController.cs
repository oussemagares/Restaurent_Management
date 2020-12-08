using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApplicationCore3.Data;
using RestaurantApplicationCore3.Models;

namespace RestaurantApplicationCore3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //httpGet
        //Retreive from database and pass it to the view 
        public async Task<IActionResult> Index()
        {
            return View (await _db.categories.ToListAsync());
        }
       //Action for Create GET-CREATE
       //We do no need to retreive any thing from the view--> empty action rresult 
       public IActionResult Create()
        {
            return View(); 
        }
        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken] //pour plus securisé l'apllication des attaques externes 
        public async Task<IActionResult> Create(Category category)
        {
            if(ModelState.IsValid)
            {
                //If Model introduced is valid
                _db.categories.Add(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //Get-Edit
        public async Task<IActionResult> Edit (int? id) 
        {
            if(id == null) 
            {
                return NotFound();
            }
            var category = await _db.categories.FindAsync(id);
            return View(category);
        }

        //Post-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (Category category) 
        {
            if (ModelState.IsValid) 
            {
                _db.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //Get-Delete
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _db.categories.FindAsync(id);
            return View(category);
        }

        //Post-Delete
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (Category category) 
        {
            if (ModelState.IsValid)
            {
                _db.Remove(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }





    }
}