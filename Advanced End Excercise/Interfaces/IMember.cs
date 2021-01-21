using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_End_Excercise.Models;

namespace Advanced_End_Excercise.Interfaces
{
    interface IMember
    {
        Medewerker PromoteToMember(string firstname, string lastname, List<Lid> Members);
        void NeemItemVanCollectie(Item item);
        void VoegItemToeAanCollectie(Item item);
        void NeemItemVanCollectieMetId(int id);
        void VoegItemToeAanCollectieMetId(int id);
        void GeefOverzichtMembers(List<Lid> lid);
        void GeefOverzichtEmployees(List<Medewerker> Employee);
        void Terugbrengen(int id);
        void Reserveren(int id);
    }
}
