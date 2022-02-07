using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class InventoryManage
    {
        public void InventoryRead(string filepath)
        {
            var json = File.ReadAllText(filepath);
            var items = JsonConvert.DeserializeObject<List<Inventory>>(json);
            Console.WriteLine("Name\tPrice\tWeight\tTotalPrice");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name + "\t" + item.Price + "\t" + item.Weight + "\t" + item.Price * item.Weight);
            }
        }
    }
}

