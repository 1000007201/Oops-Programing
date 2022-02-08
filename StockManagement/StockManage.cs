using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class StockManage
    {
        List<Stocks> stocks = new List<Stocks>();
        public void StockDetails(string filepath)
        {
            var json = File.ReadAllText(filepath);
            var item = JsonConvert.DeserializeObject<List<Stocks>>(json);
            Console.WriteLine("Name\t\tPrice\tQuantity\tMarketCap");
            foreach (var data in item)
            {
                Console.WriteLine($"{data.Name}\t\t{data.Price}\t{data.Quantity}\t{data.Price*data.Quantity}");
            }
        }
    }
}
