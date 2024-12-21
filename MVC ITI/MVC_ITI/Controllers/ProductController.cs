using Microsoft.AspNetCore.Mvc;
using MVC_ITI.Models;

namespace MVC_ITI.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult GetAll()
		{
			ProductBL productBL = new ProductBL();
			List<Product> ProductListModel = productBL.GetAll();
			return View("productshowall", ProductListModel);
		}
		public IActionResult Detail(int id)
		{
			ProductBL productBL = new ProductBL();
			Product ProductModel = productBL.GetById(id);
			return View("productshowdetails" , ProductModel);
		}

	}
}
