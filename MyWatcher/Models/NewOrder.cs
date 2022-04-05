using System;
using System.Collections.Generic;
using System.Text;

namespace MyWatcher.Models
{
    class NewOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public int Fees { get; set; }
        public string OrderStatus { get; set; }
    }
}
