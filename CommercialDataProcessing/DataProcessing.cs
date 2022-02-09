using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialDataProcessing
{
    public class DataProcessing
    {
        List<Stocks> userStocks = new List<Stocks>();
        List<Stocks> marketStocks = new List<Stocks>();
        int amount = 10000;
        public DataProcessing(string marketpath, string userpath)
        {

            userStocks = AddJsonFile(userpath);
            marketStocks = AddJsonFile(marketpath);
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter Value:");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Display(userStocks);
                        break;
                    case 2:
                        Display(marketStocks);
                        break;
                    case 3:
                        Buy();
                        Display(userStocks);
                        break;
                    case 4:
                        break;
                    case 5:
                        flag = false;
                        break;

                }
            }
            var json = JsonConvert.SerializeObject(marketStocks);
            File.WriteAllText(marketpath, json);
            var json2 = JsonConvert.SerializeObject(userStocks);
            File.WriteAllText(userpath, json2);


        }
        public List<Stocks> AddJsonFile(string filepath)
        {
            var json = File.ReadAllText(filepath);
            var item = JsonConvert.DeserializeObject<List<Stocks>>(json);
            return item;
        }
        public void Display(List<Stocks> stocks)
        {
            Console.WriteLine("Name\tPrice\tQuantity\tTotalPrice");
            foreach (var item in stocks)
            {
                Console.WriteLine($"{item.Name}\t{item.Price}\t{item.Quantity}\t{item.Price * item.Quantity}");
            }

        }
        public void Buy()
        {
            Stocks temp = new Stocks();
            Stocks temp1 = new Stocks();
            Stocks temp2 = new Stocks();
            if (Validate())
            {
                Console.WriteLine("Enter Name:");
                temp.Name = Console.ReadLine();
                Console.WriteLine("Enter Quantity you need to Buy:");
                temp.Quantity = Convert.ToInt32(Console.ReadLine());
                foreach (var data in marketStocks)
                {
                    if (data.Name == temp.Name)
                    {
                        temp.Price = data.Price;
                        temp1 = data;
                        break;
                    }     
                }
                if (amount < temp.Quantity * temp.Price)
                    Console.WriteLine("You are not having enough funds");
                if (temp.Quantity > temp1.Quantity)
                    Console.WriteLine("Market is not having enough stocks");
                marketStocks.Remove(temp1);
                temp1.Quantity -= temp.Quantity;
                marketStocks.Add(temp1);
                bool ispresent = false;
                foreach(var data in userStocks)
                {
                    if(data.Name == temp1.Name)
                    {
                        ispresent = true;
                        temp2 = data;
                        break;
                    }
                }
                if (ispresent)
                    userStocks.Remove(temp2);
                    temp2.Quantity += temp.Quantity;
                userStocks.Add(temp2);
                amount -= temp.Quantity*temp.Price;
            }
            else
                Console.WriteLine("Stocks is not present");
            
        }

        public bool Validate()
        {
            Console.WriteLine("Enter Name of Stock:");
            string name = Console.ReadLine();
            foreach(var data in marketStocks)
            {
                if (data.Name.Equals(name))
                {

                    return true;
                }
            }
            return false;
        }

    }
}
