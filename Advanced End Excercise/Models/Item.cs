using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_End_Excercise.Models
{
    enum ESoortItem
    {
        Boek=1,
        Stripverhaal=2,
        DVD=3,
        CD=4
    }

    public class Item
    {
        ESoortItem input;
        public string SoortItem 
            {
            get 
            {
                switch (input)
                {
                    case ESoortItem.Boek:
                        return "Boek";
                        break;
                    case ESoortItem.Stripverhaal:
                        return "Stripverhaal";
                        break;
                    case ESoortItem.DVD:
                        return "DVD";
                        break;
                    case ESoortItem.CD:
                        return "CD";
                        break;
                    default:
                        return null;
                        break;
                }
            }
            set
            {
                switch (value.ToLower())
                {
                    case "boek":
                        input = ESoortItem.Boek;
                        break;
                    case "stripverhaal":
                        input = ESoortItem.Stripverhaal;
                        break;
                    case "dvd":
                        input = ESoortItem.DVD;
                        break;
                    case "cd":
                        input = ESoortItem.CD;
                        break;
                    default:
                        break;
                }

            } 
        }
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Auteur { get; set; }
        public int Jaartal { get; set; }
        public bool Uitgeleend { get; set; }
        public bool Afgevoerd { get; set; }

        public Item(string soortItem, int itemID, string title, string auteur, int jaartal, bool uitgeleend, bool afgevoerd)
        {
            SoortItem = soortItem;
            ItemId = itemID;
            Title = title;
            Auteur = auteur;
            Jaartal = jaartal;
            Uitgeleend = uitgeleend;
            Afgevoerd = afgevoerd;
        }
        
    }
}
