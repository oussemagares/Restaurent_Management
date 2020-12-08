using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApplicationCore3.Data;

namespace RestaurantApplicationCore3.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryController(ApplicationDbContext _db) 
        {
            this._db = _db;

        }
        public async Task<IActionResult> Index()
        {
            var subcategory = await _db.subCategories.Include(c => c.Category).ToListAsync();
            return View(subcategory);
        }
    }
}