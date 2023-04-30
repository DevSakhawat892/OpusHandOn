using Microsoft.AspNetCore.Mvc;
using OpusHandOn.Constract.IRepository;
using OpusHandOn.Models;

namespace OpusHandOn.Controllers
{
   public class ProductsController : Controller
   {
      private readonly IUnitOfWork _context;

      public ProductsController(IUnitOfWork context)
      {
         _context = context;
      }

      [HttpGet]
      public IActionResult Index()
      {
         return View();
      }

      [HttpGet]
      public IActionResult GetAll()
      {
         IEnumerable<Product> productList = _context.Product.QueryAsync();
         return Json(new { data = productList });
      }

      [HttpGet]
      public IActionResult Get(int id)
      {
         Product product = _context.Product.FirstOrDefault(p => p.Id == id);
         return Json(product);
      }

      [HttpPost]
      public JsonResult Create(Product model)
      {
         Product product = new Product()
         {
            ProductCode = model.ProductCode,
            ProductName = model.ProductName,
            UnitPrice = model.UnitPrice
         };

         _context.Product.Add(product);
         _context.Save();
         return Json(new { });
      }

      [HttpPost]
      public JsonResult Delete(int id)
      {
         try
         {
            if (id != null)
            {
               Product product = _context.Product.FirstOrDefault(p => p.Id == id);
               if (product != null)
                  _context.Product.Remove(product);
               _context.Save();
            }
            return Json(new { });
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
      }

      [HttpGet]
      public JsonResult Edit(int id)
      {
         if (id != null || id != 0)
         {
            Product product = _context.Product.FirstOrDefault(p => p.Id == id);
            return new JsonResult(product);
         }
         return Json(new { });
      }

      [HttpPost]
      public JsonResult Update(Product model)
      {
         if (ModelState.IsValid)
         {
            Product product = new Product
            {
               Id = model.Id,
               ProductCode = model.ProductCode,
               ProductName = model.ProductName,
               UnitPrice = model.UnitPrice
            };
            _context.Product.Update(product);
            _context.Save();

            return Json("Product updated");
         }
         else
         {
            return Json("Modelstate invalid");
         }
      }
   }
}