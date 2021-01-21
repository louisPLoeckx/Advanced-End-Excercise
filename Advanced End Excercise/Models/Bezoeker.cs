using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_End_Excercise.Models
{
    public class Bezoeker
    {
        public bool IsLid = false;
        public bool IsEmployee = false;

        public string Voornaam { get; set; }
        public string Familieaam { get; set; }
        public LibraryCollection _LibraryCollection = new LibraryCollection();
        public List<Bezoeker> _Bezoeker = new List<Bezoeker>();
        public List<Lid> _Lid = new List<Lid>();


        public void RegisterAsLid(Lid lid)
        {
            _Lid.Add(lid);
        }

        public void ToonOverzicht(List<Bezoeker> list)
        {
            string inputWord = "";
            if (IsLid == true && IsEmployee == true)
            {
                inputWord = "Employee";
                Console.WriteLine($"[1]Show all [2] Show All Available [3] Show not Available [4] all {inputWord}(s) ");
            }
            else if (IsLid == true && IsEmployee != true)
            {
                inputWord = "Member";
                Console.WriteLine($"[1]Show all [2] Show All Available [3] Show not Available [4] all {inputWord}(s) ");
            }
            else
            {
                inputWord = "Visitor";
                Console.WriteLine($"[1]Show all [2] Show All Available [3] Show not Available ");
            }

            ConsoleKey inputKey = Console.ReadKey().Key;
            switch (inputKey)
            {
                
                case ConsoleKey.NumPad1:
                    _LibraryCollection.ShowAll();
                    break;
                case ConsoleKey.NumPad2:
                    _LibraryCollection.ShowAvailable();
                    break;
                case ConsoleKey.NumPad3:
                    _LibraryCollection.ShowNotAvailable();
                    break;
                case ConsoleKey.NumPad4:
                    int counter = 1;
                    foreach (var item in list)
                    {
                        Console.WriteLine($"{counter} \t {item.Voornaam} \t {item.Familieaam}");
                        counter++;
                    }
                    break;
                default:
                    break;
            }
        }

        public Item ZoekItemMetTitle(string title)
        {
            Item ZoekItem = null;
            foreach (var item in _LibraryCollection.LibraryStock)
            {
                if (item.Title == title)
                {
                    ZoekItem = item;
                    Console.WriteLine($"The search returns: \t{ZoekItem.ItemId} \t {ZoekItem.Title} \t {ZoekItem.SoortItem} \t {ZoekItem.Jaartal} \t {ZoekItem.Uitgeleend} \t {ZoekItem.Afgevoerd}");
                }
                else
                {
                    Console.WriteLine("No item with the corresponding title has been found");
                    ZoekItem = null;
                }
            }
            return ZoekItem;
        }

        public Item ZoekItemMetId(int id)
        {
            Item ZoekItem = null;
            foreach (var item in _LibraryCollection.LibraryStock)
            {
                if (item.ItemId == id)
                {
                    ZoekItem = item;
                    Console.WriteLine($"The search returns: \t{ZoekItem.ItemId} \t {ZoekItem.Title} \t {ZoekItem.SoortItem} \t {ZoekItem.Jaartal} \t {ZoekItem.Uitgeleend} \t {ZoekItem.Afgevoerd}");
                }
                else
                {
                    Console.WriteLine("No item with the corresponding itemId has been found");
                    ZoekItem = null;
                }
            }
            return ZoekItem;

        }

        public void GeefOverzichtVisitors(List<Bezoeker> visitor)
        {
            int counter = 1;
            foreach (var item in visitor)
            {
                Console.WriteLine($"{counter} \t {item.Voornaam} \t {item.Familieaam}");
                counter++;
            }
        }

        public Bezoeker(string voornaam, string familienaam)
        {
            Voornaam = voornaam;
            Familieaam = familienaam;
            IsLid = false;
        }
    }
}
