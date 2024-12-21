using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Entities.Models;
using MyShop.Entities.Repositories;
using MyShop.Utilities;
using System.Security.Claims;
using X.PagedList.Extensions;

namespace MyShop.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(int ? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 4;
            var products = _unitOfWork.Product.GetAll().ToPagedList(pageNumber, pageSize);
            return View(products);
        }
        public IActionResult Details(int ProductId)
        {

            ShoppingCart obj = new ShoppingCart()
            {
                ProductId = ProductId,
                Product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == ProductId, includeWord: "Category"),
                Count = 1
            };

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {

            //how to get user to sign in for shopping
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;

            ShoppingCart cartObj = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                x=> x.ApplicationUserId==claim.Value && x.ProductId == shoppingCart.ProductId);

            if (cartObj == null)// in status doesnt userid or not same productid
            {
                // add  shopping cart in this status
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Complete();
                HttpContext.Session.SetInt32(SD.SessionKey,
                    _unitOfWork.ShoppingCart.GetAll(u=> u.ApplicationUserId == claim.Value)
                    .ToList().Count());
                
            }
            else
            {
                _unitOfWork.ShoppingCart.IncreaseCount(cartObj , shoppingCart.Count);
                _unitOfWork.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}
