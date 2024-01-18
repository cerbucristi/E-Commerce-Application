using System;
using System.Collections.Generic;

namespace ECommerce.Client.ViewModels
{
    public class OrderViewModel
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public string Payment { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
