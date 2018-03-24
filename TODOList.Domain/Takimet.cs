using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public class Takimet
    {
        static void Main()
        {

            DailyMeeteings dm1 = new DailyMeeteings(5, "zyra nr5");

            Console.WriteLine("dm1: {0}:{1}", dm1.koha, dm1.vendi);

            Console.ReadKey();
        }

    }

}








