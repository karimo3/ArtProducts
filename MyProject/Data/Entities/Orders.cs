using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Entities
{
  public class Orders
  {
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; }
    public ICollection<OrderItems> Items { get; set; } //there's a relationship between the Order and OrderItems (1:N relationship) ... this will create the relationship in SQL Server
    public StoreUser User { get; set; }
  }
}
