using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Actions
    {
        public static char VerifyChar()
        {
            char Output;
            while(!char.TryParse(Console.ReadLine(),out Output))
            {
                Console.WriteLine("Wrong input, try again.");
            }
            return Output;
        }
        public static int VerifyInt()
        {
            int Output;
            while (!int.TryParse(Console.ReadLine(), out Output))
            {
                Console.WriteLine("Wrong input, try again.");
            }
            return Output;
        }
    }
}
