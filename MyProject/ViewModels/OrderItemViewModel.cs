using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
       
        public string ProductCategory { get; set; }
        public string ProductSize { get; set; }
        public string ProductTitle { get; set; }
        public string ProductArtist { get; set; }
        public int ProductArtId { get; set; }

    }
}
