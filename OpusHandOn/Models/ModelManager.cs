using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpusHandOn.Models
{
   public class Product
   {
      [Key]
      public int Id { get; set; }

      [Display(Name = "Product Code")]
      public string ProductCode { get; set; }

      [Display(Name = "Product Name")]
      public string ProductName { get; set; }

      [Display(Name = "Unit Price")]
      public int UnitPrice { get; set; }
   }
   public class SalesMaster
   {
      [Key]
      public int Id { get; set; }
      public DateTime Date { get; set; }
      public int TotalQuantity { get; set; }
      public double TotalPrice { get; set; }
   }
   public class SalesDetail
   {
      [Key]
      public int Id { get; set; }

      [ForeignKey("SalesMasterId")]
      public int SalesMasterId { get; set; }
      public SalesMaster SalesMaster { get; set; }


      [ForeignKey("ProductId")]
      public int ProductId { get; set; }
      public Product Product { get; set; }

      public int Qunatity { get; set; }
      public double TotalPrice { get; set; }
   }
}
