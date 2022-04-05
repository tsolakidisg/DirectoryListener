using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWatcher
{
    public sealed class OrderFromDBMap : ClassMap<OrderFromDB>
    {
        public OrderFromDBMap()
        {
            Map(x => x.Id).Name("OrderNumber");
            Map(x => x.CustomerName).Name("CustomerName");
            Map(x => x.Fees).Name("Fees");
            Map(x => x.OrderStatus).Name("OrderStatus");
        }
    }
}
