namespace OpusHandOn.Models.Dto
{
   public class Sales
   {
      public SalesMaster SalesMaster { get; set; }
      public List<SalesDetail> SalesDetails { get; set; }

      public double ProductPrice { get; set; }
   }
}
