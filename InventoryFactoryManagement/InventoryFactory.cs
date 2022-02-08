using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFactoryManagement
{
    public class InventoryFactory
    {
        public List<Inventory> RiceList { get; set; }
        public List<Inventory> PulseList { get; set; }
        public List<Inventory> WheatList { get; set; }
        
    }
    public class Inventory
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
    }
}
