namespace OpusHandOn.Models.Dto
{
   public class Sales
   {
      public SalesMaster? SalesMaster { get; set; }
      public SalesDetail? SalesDetail { get; set; }
      public List<SalesDetail>? SalesDetails { get; set; }

      public int ItemCount { get; set; }
   }
}
