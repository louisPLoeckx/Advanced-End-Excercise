using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_End_Excercise.Models;
using Advanced_End_Excercise.Interfaces;

namespace Advanced_End_Excercise.Models
{
    public class Lid: Bezoeker,ILid
    {
        
        public List<Item> UItleenHistoriek = new List<Item>();
        public List<Item> ItemsUitgeleend = new List<Item>();
        public List<Item> Reservaties = new List<Item>();
        //LibraryCollection libraryCollection = new LibraryCollection();

        public DateTime GeboorteDatum { get; set; }
        public int MyProperty { get; set; }

        public void Reserveren(int id)
        {
            if (_LibraryCollection.LibraryStock.Contains(ZoekItemMetId(id)))
            {
                Item item = ZoekItemMetId(id);
                Reservaties.Add(item);
            }
        }

        public void Terugbrengen(int id)
        {
            if (ItemsUitgeleend.Contains(ZoekItemMetId(id)))
            {
                Item item = ZoekItemMetId(id);
                UItleenHistoriek.Remove(item);
                item.Uitgeleend = false;

                _LibraryCollection.UpdateIsLoaned(id, false);
                ItemsUitgeleend.Remove(item);
                UItleenHistoriek.Add(item);

            }
        }

        public void Uitlenen(int id)
        {
            if (ItemsUitgeleend.Contains(ZoekItemMetId(id)))
            {
                Item item = ZoekItemMetId(id);

                _LibraryCollection.UpdateIsLoaned(id, true);

                ItemsUitgeleend.Add(item);
                UItleenHistoriek.Add(item);

            }
        }

        public void GeefOverzichtMembers(List<Lid> Member)
        {
            int counter = 1;
            foreach (var item in Member)
            {
                Console.WriteLine($"{counter} \t {item.Voornaam} \t {item.Familieaam}");
                counter++;
            }
        }

        public void ToonOverzicht(List<Lid> list)
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

        public Lid(string voornaam, string familienaam):base(voornaam, familienaam)
        {
            IsLid = true;
            IsEmployee = false;
        }

    }
}
