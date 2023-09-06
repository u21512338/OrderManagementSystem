using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{

    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }

        public int TotalAmount { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }


    }

}
