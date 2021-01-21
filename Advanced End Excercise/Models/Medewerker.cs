using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_End_Excercise.Interfaces;

namespace Advanced_End_Excercise.Models
{
    public class Medewerker:Lid,IMember
    {
        //List<Medewerker> _Employee = new List<Medewerker>();
        
        
        public Medewerker PromoteToMember(string firstname, string lastname, List<Lid> Members)
        {
            if (Members.Contains(new Lid(firstname, lastname)))
            {
                
                return new Medewerker(firstname, lastname);
            }
            else
            {
                Console.WriteLine("The member does not exist.");
                return null;
            }
        }

        public void NeemItemVanCollectie(Item item)
        {
            if (_LibraryCollection.LibraryStock.Contains(item))
            {
                _LibraryCollection.LibraryStock.Remove(item);
            }
        }

        public void VoegItemToeAanCollectie(Item item)
        {
            if (_LibraryCollection.LibraryStock.Contains(item))
            {
                _LibraryCollection.LibraryStock.Add(item);
            }
        }

        public void GeefOverzichtEmployees(List<Medewerker> Employee)
        {
            int counter = 1;
            foreach (var item in Employee)
            {
                Console.WriteLine($"{counter} \t {item.Voornaam} \t {item.Familieaam}");
                counter++;
            }
        }

        public void NeemItemVanCollectieMetId(int id)
        {
            Item item = ZoekItemMetId(id);
            if (_LibraryCollection.LibraryStock.Contains(item))
            {
                _LibraryCollection.LibraryStock.Remove(item);
            }
        }

        public void VoegItemToeAanCollectieMetId(int id)
        {
            Item item = ZoekItemMetId(id);
            if (_LibraryCollection.LibraryStock.Contains(item))
            {
                _LibraryCollection.LibraryStock.Add(item);
            }
        }

        public void ToonOverzicht(List<Medewerker> list)
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

        public Medewerker(string voornaam, string familienaam) : base(voornaam, familienaam)
        {
            IsLid = true;
            IsEmployee = true;
        }

    }
}
