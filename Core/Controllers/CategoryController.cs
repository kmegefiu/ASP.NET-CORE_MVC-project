using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> OBJcategoryList = _db.Categories;
            return View(OBJcategoryList);
        }


        //Get
        public IActionResult Create()
        {

            return View();
        }

        //post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");

            }
            else
                return View(obj);
        }


        //Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var IdUpdate = _db.Categories.Find(id);
            //var IdUpdate2 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var IdUpdate3 = _db.Categories.SingleOrDefault(u=>u.Id==id);

            if (IdUpdate == null)
            {
                return NotFound();
            }

            return View(IdUpdate);
        }

        //post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");

            }
            else
                return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var IdDelete = _db.Categories.Find(id);
            //var IdUpdate2 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var IdUpdate3 = _db.Categories.SingleOrDefault(u=>u.Id==id);

            if (IdDelete == null)
            {
                return NotFound();
            }

            return View(IdDelete);
        }

        

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Category obj)
        {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
            
        }



    }

}

