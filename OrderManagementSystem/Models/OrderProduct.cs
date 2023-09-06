using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Models
{
    

    public class OrderProduct
    {
        public int OrderProductID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }


        // Navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }

}
