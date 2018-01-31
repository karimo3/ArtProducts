namespace MyProject.Data.Entities
{
  public class OrderItems
  {
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public Orders Order { get; set; }
  }
}