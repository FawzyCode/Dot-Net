using Microsoft.AspNetCore.Mvc;
using MyShop.DataAccess;
using MyShop.Entities.Models;
using MyShop.Entities.Repositories;


namespace MyShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Categories.Add(category);
                _unitOfWork.Category.Add(category);
                //_context.SaveChanges();
                _unitOfWork.Complete();
                TempData["Create"] = "Data Has Created Succesfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null | id == 0)
            {
                NotFound();
            }
            //var categoryInDb = _context.Categories.Find(id);
            var categoryInDb = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            return View(categoryInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Categories.Update(category);
                _unitOfWork.Category.Update(category);
                //_context.SaveChanges();
                _unitOfWork.Complete();
                TempData["Update"] = "Data Has Updated Succesfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null | id == 0)
            {
                NotFound();
            }
            //var categoryInDb = _context.Categories.Find(id);
            var categoryInDb = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            return View(categoryInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            var categoryInDb = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            if (categoryInDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(categoryInDb);
            _unitOfWork.Complete();
            TempData["Delete"] = "Data Has Deleted Succesfully";
            return RedirectToAction("Index");

        }
    }
}
