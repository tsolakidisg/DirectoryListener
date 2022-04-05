using CsvHelper.Configuration;
using MyWatcher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWatcher.Mappers
{
    public sealed class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Map(x => x.OrderNumber).Name("OrderNumber");
            Map(x => x.CustomerName).Name("CustomerName");
        }
    }
}
