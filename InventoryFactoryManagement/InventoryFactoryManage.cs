using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFactoryManagement
{
    public class InventoryFactoryManage
    {
        List<Inventory> riceList = new List<Inventory>();
        List<Inventory> pulseList = new List<Inventory>();
        List<Inventory> wheatList = new List<Inventory>();

        public void ReadFactory(string filepath)
        {
            var json = File.ReadAllText(filepath);
            var item = JsonConvert.DeserializeObject<InventoryFactory>(json);
            this.riceList = item.RiceList;
            this.pulseList = item.PulseList;
            this.wheatList = item.WheatList;
            Display(riceList);
            Display(pulseList);
            Display(wheatList);
            
        }
        public void Display(List<Inventory> inv)
        {
            if (inv.Count == 0)
            {
                Console.WriteLine("Null");
            }
            else
            {
                Console.WriteLine("Name\tPrice\tWeight\tTotal Price");
                foreach(var data in inv)
                {
                    Console.WriteLine($"{data.Name}\t{data.Price}\t{data.Weight}\t{data.Price * data.Weight}");
                }
            }
        }
        public Inventory TakeInput()
        {
            Inventory inventory = new Inventory();
            Console.Write("Enter Name:");
            inventory.Name = Console.ReadLine();
            Console.Write("Enter Price:");
            inventory.Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Weight:");
            inventory.Weight = Convert.ToInt32(Console.ReadLine());
            return inventory;

        }
        public bool Validate(List<Inventory> inv)
        {
            Console.WriteLine("Enter Name of Item You have to add:");
            string name = Console.ReadLine();
            foreach(var data in inv)
            {
                if (data.Name == name)
                {
                    Console.WriteLine("Already Exist!!");
                    return false;
                }
            }
            return true;
        }
        public void WriteFactory(Inventory inventory, int check,string filepath)
        {
            InventoryFactory inventoryFactory = new InventoryFactory();
            if(check == 1)
            {
                riceList.Add(inventory);
                inventoryFactory.RiceList = riceList;
                WriteToFile(filepath);
            }
            if(check == 2)
            {
                pulseList.Add(inventory);
                inventoryFactory.PulseList = pulseList;
                WriteToFile(filepath);
            }
            if(check == 3)
            {
                wheatList.Add(inventory);
                inventoryFactory.WheatList = wheatList;
                WriteToFile(filepath);
            }
        }
        public void WriteToFile(string filepath)
        {
            InventoryFactory inventory = new InventoryFactory();
            inventory.RiceList = riceList;
            inventory.PulseList = pulseList;
            inventory.WheatList = wheatList;
            var json = JsonConvert.SerializeObject(inventory);
            File.WriteAllText(filepath, json);
        }
        public void AddFactory(string filepath)
        {
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("Enter Value:\n1.Add Rice Item\n2.Add Pulses Item\n3.Add Wheat Item\n4.Exit");
                int check = Convert.ToInt32(Console.ReadLine());
                Inventory inventory = new Inventory();
                switch(check)
                {
                    case 1:
                        if(Validate(riceList))
                        {
                            inventory = TakeInput();
                            WriteFactory(inventory, check, filepath);
                            Display(riceList);
                        }
                        break;
                    case 2:
                        if(Validate(pulseList))
                        {
                            inventory = TakeInput();
                            WriteFactory(inventory, check, filepath);
                            Display(pulseList);
                        }
                        break;
                    case 3:
                        if (Validate(wheatList))
                        {
                            inventory = TakeInput();
                            WriteFactory(inventory, check, filepath);
                            Display(wheatList);
                        }
                        break;
                    case 4:
                        flag = false;
                        break;
                }
            }
        }
    }
}
