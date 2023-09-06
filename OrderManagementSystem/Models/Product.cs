using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{

    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }

    }

}
