using System;
using System.Collections.Generic;
using System.Text;

namespace MyWatcher
{
    public class OrderFromDB
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int Fees { get; set; }
        public string OrderStatus { get; set; }
    }
}
