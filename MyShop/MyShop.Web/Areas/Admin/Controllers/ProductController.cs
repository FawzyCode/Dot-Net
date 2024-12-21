using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.DataAccess;
using MyShop.Entities.Models;
using MyShop.Entities.Repositories;
using MyShop.Entities.ViewModels;


namespace MyShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork , IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetData()
        {
            var products = _unitOfWork.Product.GetAll(includeWord:"Category");
            return Json(new {data = products});
        }
        [HttpGet]
        public IActionResult Create()
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM productVM , IFormFile file)//IFormFile file==>  to User upload Images
        {
            if (ModelState.IsValid)
            {
                string RootPath = _webHostEnvironment.WebRootPath;//WWWRoot
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();//Create uniqe name
                    var Upload = Path.Combine(RootPath, @"Images\Products");//Save Images in /Images/Products
                    var ext = Path.GetExtension(file.FileName);//.jpg or .Png
                   
                    //Creaet new folder in select path of FileStream
                    using (var filestream = new FileStream(Path.Combine(Upload, filename + ext), FileMode.Create))
                    {
                        file.CopyTo(filestream);//Copy Upload Image From User To new folder
                    }
                    productVM.Product.Img = @"Images\Products\" + filename + ext;
                }

                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Complete();
                TempData["Create"] = "Item has Created Successfully";
                return RedirectToAction("Index");
            }
            return View(productVM.Product);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null | id == 0)
            {
                NotFound();
            }
            ProductVM productVM = new ProductVM()
            {
                Product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id),
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string RootPath = _webHostEnvironment.WebRootPath; //wwwroot
                if (file != null)//  if image exist upload
                {
                    string filename = Guid.NewGuid().ToString();
                    var Upload = Path.Combine(RootPath, @"Images\Products");
                    var ext = Path.GetExtension(file.FileName);

                    if (productVM.Product.Img != null) // image is exist in product in db
                    {
                        //path of old img 
                        var oldimg = Path.Combine(RootPath,productVM.Product.Img.TrimStart('\\'));
                        if (System.IO.File.Exists(oldimg))//the old img is exist
                        {
                            System.IO.File.Delete(oldimg);//delete the old img
                        }
                    }
                    //uplopad new img using FileStream
                    using (var filestream = new FileStream(Path.Combine(Upload, filename + ext), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    productVM.Product.Img = @"Images\Products\" + filename + ext;
                }
                _unitOfWork.Product.Update(productVM.Product);
                _unitOfWork.Complete();
                TempData["Update"] = "Data has Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(productVM.Product);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productIndb = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
            if (productIndb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _unitOfWork.Product.Remove(productIndb);
            var oldimg = Path.Combine(_webHostEnvironment.WebRootPath, productIndb.Img.TrimStart('\\'));
            if (System.IO.File.Exists(oldimg))
            {
                System.IO.File.Delete(oldimg);
            }
            _unitOfWork.Complete();
            return Json(new { success = true, message = "file has been Deleted" });
        }
    }
}
