// See https://aka.ms/new-console-template for more information
using InventoryFactoryManagement;

InventoryFactoryManage inventoryFactoryManage = new InventoryFactoryManage();
string filepath = @"E:\Bridgelabz\Oops-Programing\InventoryFactoryManagement\InventoryInput.json";
bool flag = true;
while (flag)
{
    Console.WriteLine("Enter Value:\n1.Display Items\n2.Add Item\n3.Exit");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            inventoryFactoryManage.ReadFactory(filepath);
            break;
        case 2:
            inventoryFactoryManage.AddFactory(filepath);
            break;
        case 3:
            flag = false;
            break;
    }

}
