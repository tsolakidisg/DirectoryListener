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

        public NewOrder(int _orderNumber, string _customerName, int _fees, string _orderStatus)
        {
            this.OrderNumber = _orderNumber;
            this.Fees = _fees;
            this.CustomerName = _customerName;
            this.OrderStatus = _orderStatus;
        }
    }
}
