using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Machine
    {
        private List<Item> Items;
        private decimal accumulatedMoney;

        public Machine()
        {
            Items = new List<Item>
            {
                new Item("Coca Cola", 15.0m, 10),
                new Item("Pepsi", 15.0m, 10),
                new Item("Faxe Kondi", 15.0m, 10),
                new Item("Fanta", 15.0m, 10),
                new Item("Sprite", 15.0m, 10),
                new Item("Gazoz", 15.0m, 10),
                new Item("Capri Sun", 10.0m, 10),
                new Item("Kildevand", 15.0m, 10),
                new Item("Dansk Vand", 15.0m, 10),

                new Item("Haribo", 15.0m, 10),
                new Item("Skumbananer", 15.0m, 10),
                new Item("Chokolade", 15.0m, 10),
                new Item("Corny Bar", 15.0m, 10),
                new Item("Chips", 15.0m, 10),



            };

            accumulatedMoney = 0;
        }

        public void InsertMoney(decimal amount)
        {
            accumulatedMoney += amount;
            Console.WriteLine($"You have inserted : {accumulatedMoney} kr.");
        }

        public void ShowItems()
        {
            Console.WriteLine("Available items:");
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Items[i].Name} - Price: {Items[i].Price} kr. - In stock: {Items[i].StockAmount}");

            }
        }

        public void BuyItem(int choice)
        {
            if(choice < 1 || choice > Items.Count)
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            Item selectedItem = Items[choice - 1];

            if (selectedItem.StockAmount == 0)
            {
                Console.WriteLine("This item is sold out"); 
                return;
            }

            if(accumulatedMoney >= selectedItem.Price)
            {
                selectedItem.StockAmount --;
                accumulatedMoney -= selectedItem.Price;
                Console.WriteLine($"You have bought {selectedItem.Name}. Remaining money: {accumulatedMoney} kr.");

                if(accumulatedMoney > 0)
                {
                    Console.WriteLine($"You get {accumulatedMoney} kr. in return.");
                    accumulatedMoney = 0;
                }
            }

            else
            {
                Console.WriteLine($"You dont have enough money. {selectedItem.Name} costs {selectedItem.Price} kr., and you only have {accumulatedMoney} kr.");
            }

        }  

        public void CancelPurchase()
        {
            Console.WriteLine($"You get {accumulatedMoney} kr. in return.");
            accumulatedMoney = 0;
        }

        public void AdminMenu()
        {
            Console.WriteLine("Welcome to the administration menu:");
            Console.WriteLine("1. Restock items");
            Console.WriteLine("2. Remove money");
            Console.WriteLine("3. Adjust item prices");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RestockItems();
                    break;
                case "2":
                    RemoveMoney();
                    break;
                case "3":
                    AdjustPrice();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        private void RestockItems()
        {
            Console.WriteLine("Which item do you want to restock?");
            ShowItems();
            int choice = int.Parse(Console.ReadLine());

            if (choice < 1 || choice > Items.Count)
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            Console.WriteLine("How many do you want to add?");
            int amount = int.Parse(Console.ReadLine());
            Items[choice - 1].StockAmount = amount;
            Console.WriteLine($"{Items[choice - 1].Name} has now been restocked");
        }

        private void RemoveMoney()
        {
            Console.WriteLine($"{accumulatedMoney} kr. has been removed from the machine.");
            accumulatedMoney = 0;
        }

        private void AdjustPrice()
        {
            Console.WriteLine("Hvilken vares pris vil du justere?");
            ShowItems();
            int choice = int.Parse(Console.ReadLine());

            if(choice < 1 || choice > Items.Count)
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            Console.WriteLine("Enter the new price:");
            decimal newPrice = decimal.Parse(Console.ReadLine());
            Items[choice - 1 ].Price = newPrice;
            Console.WriteLine($"The price for {Items[choice - 1].Name} is now {newPrice} kr.");

        }
    }

}
