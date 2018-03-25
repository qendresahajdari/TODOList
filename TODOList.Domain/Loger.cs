using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public class Logger

    {

        public void Log(int var){

            if (var == 0)
            {
                Console.WriteLine("The boss is Logged in");
            }
            else {
                Console.WriteLine("Just a simple employer Logged in");
            }

        }

        public void Log(string message, int id){

            
                Console.WriteLine("I am user with id: " + id + " and my message for today is: "+ message);
        }
    }
}