using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyWatcher.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyWatcher
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DbHelper dbHelper;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            dbHelper = new DbHelper();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(15000, stoppingToken);

                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = @"C:\Users\gtsolakidis\Documents\Folder\Input";

                watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.Size;

                watcher.Filter = "*.*";

                // Register Event Handler
                watcher.Changed += new FileSystemEventHandler(onChanged);
                watcher.Created += new FileSystemEventHandler(onChanged);

                // Start monitoring
                watcher.EnableRaisingEvents = true;
            }
        }

        public void onChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + " is " + e.ChangeType);

            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                var fileHelper = new FileHelper();

                var data = fileHelper.ReadCSVFile(e.FullPath.ToString());

                List<OrderFromDB> ordersFromDB = dbHelper.GetAllOrders();

                var editData = new List<NewOrder>();

                for (int i = 0; i < data.Count; i++)
                {
                    foreach (OrderFromDB order in ordersFromDB)
                    {
                        if (data[i].OrderNumber == order.Id)
                        {
                            editData.Add(new NewOrder(order.Id, data[i].CustomerName, order.Fees, order.OrderStatus));
                        }
                    }
                }

                string editPath = Path.Combine(@"C:\Users\gtsolakidis\Documents\Folder\Output", Path.GetFileName(e.FullPath.ToString()));
                fileHelper.WriteCSVFile(editPath, editData);
                Console.WriteLine(e.Name + " has been edited.");

                string targetPath = Path.Combine(@"C:\Users\gtsolakidis\Documents\Folder\Archive\", Path.GetFileName(e.FullPath.ToString()));
                File.Move(e.FullPath.ToString(), targetPath);
                Console.WriteLine(e.Name + " has been archived.");
            }
        }
    }
}
