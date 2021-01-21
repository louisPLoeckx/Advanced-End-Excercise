using Advanced_End_Excercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_End_Excercise.Interfaces
{
    interface ILid
    {
        void Uitlenen(int id);
        void Terugbrengen(int id);
        void Reserveren(int id);
        void GeefOverzichtMembers(List<Lid> Member);
    }
}
