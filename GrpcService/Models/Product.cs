using System;
using System.Collections.Generic;

#nullable disable

namespace GrpcService.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
    }
}
