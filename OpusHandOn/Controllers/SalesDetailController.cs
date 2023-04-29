using Microsoft.AspNetCore.Mvc;
using OpusHandOn.Constract.IRepository;
using OpusHandOn.Models;

namespace OpusHandOn.Controllers
{
   public class SalesDetailController : Controller
   {
      private readonly IUnitOfWork _context;

      public SalesDetailController(IUnitOfWork context)
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
         IEnumerable<SalesDetail> salesDetails = _context.SalesDetail.QueryAsync(includeProperties: "Product,SalesMaster");
         return Json(salesDetails);
      }

      [HttpGet]
      public IActionResult GetAllSalesMaster()
      {
         IEnumerable<SalesMaster> salesMasters = _context.SalesMaster.QueryAsync();
         return Json(salesMasters);
      }

      [HttpPost]
      public JsonResult Create(SalesDetail model)
      {
         if(model.Id == 0) { 
            SalesDetail salesDetail = new SalesDetail()
            {
               SalesMasterId = model.SalesMasterId,
               ProductId = model.ProductId,
               Qunatity = model.Qunatity,
               TotalPrice = model.TotalPrice
            }; 
            
            _context.SalesDetail.Add(salesDetail);
            _context.Save();
            return Json("Record saved.");
         }
         return Json("Model state invalide.");
      }

      [HttpPost]
      public JsonResult Delete(int id)
      {
         try
         {
            if (id != null)
            {
               SalesDetail salesDetail = _context.SalesDetail.FirstOrDefault(s => s.Id == id);
               if (salesDetail != null)
                  _context.SalesDetail.Remove(salesDetail);
               _context.Save();
            }
            return Json("Record deleted");
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
            SalesDetail salesDetail = _context.SalesDetail.FirstOrDefault(s => s.Id == id, includeProperties:"Product,SalesMaster");
            return new JsonResult(salesDetail);
         }
         return Json(new { });
      }

      [HttpPost]
      public JsonResult Update(SalesDetail model)
      {
         if (model.Id != 0)
         {
            SalesDetail salesDetail = new SalesDetail()
            {
               Id = model.Id,
               SalesMasterId = model.SalesMasterId,
               ProductId = model.ProductId,
               Qunatity = model.Qunatity,
               TotalPrice = model.TotalPrice
            };
            _context.SalesDetail.Update(salesDetail);
            _context.Save();

            return Json("Record updated");
         }
         else
         {
            return Json("Modelstate invalid");
         }
      }
   }
}