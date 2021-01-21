using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_End_Excercise.Interfaces;
using Advanced_End_Excercise.Models;

namespace Advanced_End_Excercise.Models
{
    public class LibraryCollection:ILibraryCollection
    {
        public List<Item> LibraryStock = new List<Item>();
        public List<Item> LibraryStockAfgevoerd = new List<Item>();

        public void Add(Item item)//double check doesnt feel right
        {  
            LibraryStock.Add(item);
        }

        public void UpdateIsLoaned(int id, bool isLoaned)//double check doesnt feel right
        {
            foreach (var item in LibraryStock)
            {
                if (item.ItemId == id)
                {
                    item.Uitgeleend = isLoaned;
                }
            }
        }

        public void RemoveById(int id)//expand with more removes
        {
            foreach (var item in LibraryStock)
            {
                if (item.ItemId == id)
                {
                    LibraryStockAfgevoerd.Add(item);
                    LibraryStock.Remove(item);
                }
            }
        }

        public void ShowAvailable()
        {
            foreach (var item in LibraryStock)
            { 
                if (item.Uitgeleend == false || item.Afgevoerd == false)
                {
                    int id = 1;
                    Console.WriteLine($"{id} \t{item.ItemId} \t {item.Title} \t {item.SoortItem} \t {item.Jaartal} \t {item.Uitgeleend} \t {item.Afgevoerd}");
                    id++;
                }
            }
        }

        public void ShowAll()
        {
            foreach (var item in LibraryStock)
            {
                int id = 1;
                Console.WriteLine($"{id} \t{item.ItemId} \t {item.Title} \t {item.SoortItem} \t {item.Jaartal} \t {item.Uitgeleend} \t {item.Afgevoerd}");
                id++;
            }
        }

        public void ShowItemsSentToStock()
        {
            foreach (var item in LibraryStock)
            {
                if (item.Afgevoerd == true)
                {
                    int id = 1;
                    Console.WriteLine($"{id} \t{item.ItemId} \t {item.Title} \t {item.SoortItem} \t {item.Jaartal} \t {item.Uitgeleend} \t {item.Afgevoerd}");
                    id++;
                }
            }
        }

        public void ShowNotAvailable()
        {
            foreach (var item in LibraryStock)
            {
                if (item.Uitgeleend == true|| item.Afgevoerd == true)
                {
                    int id = 1;
                    Console.WriteLine($"{id} \t{item.ItemId} \t {item.Title} \t {item.SoortItem} \t {item.Jaartal} \t {item.Uitgeleend} \t {item.Afgevoerd}");
                    id++;
                }
            }
        }
    }
}
