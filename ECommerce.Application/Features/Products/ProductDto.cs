using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Products
{
        public class ProductDto
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int StockQuantity { get; set; }
            public Guid CategoryId { get; set; }
            public Guid ManufacturerId { get; set; }
            public Category Category { get; set; }
            public Manufacturer Manufacturer { get; set; }

        }
    }
