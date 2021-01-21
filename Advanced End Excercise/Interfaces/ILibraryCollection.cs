using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_End_Excercise.Models;

namespace Advanced_End_Excercise.Interfaces
{
    interface ILibraryCollection
    {

        void Add(Item item);
        void RemoveById(int id);
        void ShowAll();
        void ShowItemsSentToStock();
        void ShowAvailable();
        void ShowNotAvailable();

    }
}
