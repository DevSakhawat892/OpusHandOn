using Microsoft.AspNetCore.Mvc;
using OpusHandOn.Constract.IRepository;
using OpusHandOn.Models;
using OpusHandOn.Models.Dto;

namespace OpusHandOn.Controllers
{
   public class SalesController : Controller
   {
      private readonly IUnitOfWork _context;

      public SalesController(IUnitOfWork context)
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
         IEnumerable<SalesMaster> salesMasters = _context.SalesMaster.QueryAsync();
         return Json(new { data = salesMasters });
      }

      [HttpGet]
      public IActionResult Create()
      {
         return View();
      }

      [HttpPost]
      public JsonResult Create(Sales model)
      {
         Sales sales = new Sales()
         {
            //Date = model.Date,
            //TotalQuantity = model.TotalQuantity,
            //TotalPrice = model.TotalPrice
         };

         //_context.SalesMaster.Add(salesMaster);
         //_context.Save();
         return Json("SalesMater added");
      }

      [HttpPost]
      public JsonResult Delete(int id)
      {
         try
         {
            if (id != null)
            {
               SalesMaster salesMaster = _context.SalesMaster.FirstOrDefault(p => p.Id == id);
               if (salesMaster != null)
                  _context.SalesMaster.Remove(salesMaster);
               _context.Save();
            }
            return Json("Reacord Deleted");
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
            SalesMaster salesMaster = _context.SalesMaster.FirstOrDefault(p => p.Id == id);
            return new JsonResult(salesMaster);
         }
         return Json(new { });
      }

      [HttpPost]
      public JsonResult Update(SalesMaster model)
      {
         if (ModelState.IsValid)
         {
            SalesMaster salesMaster = new SalesMaster()
            {
               Id = model.Id,
               Date = model.Date,
               TotalQuantity = model.TotalQuantity,
               TotalPrice = model.TotalPrice
            };
            _context.SalesMaster.Update(salesMaster);
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