using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyWatcher;
using System.Linq;
using MyWatcher.Models;
using MyWatcher.Mappers;

namespace MyWatcher
{
    class FileHelper
    {
        public List<Order> ReadCSVFile(string location)
        {
            try
            {
                using (var reader = new StreamReader(location, Encoding.Default))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<OrderMap>();
                    var records = csv.GetRecords<Order>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void WriteCSVFile(string path, List<NewOrder> order)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter csvWriter = new CsvWriter(streamWriter))
            {
                csvWriter.WriteHeader<NewOrder>();
                csvWriter.NextRecord();
                foreach (NewOrder ord in order)
                {
                    csvWriter.WriteRecord<NewOrder>(ord);
                    csvWriter.NextRecord();
                }
            }
        }
    }
}
