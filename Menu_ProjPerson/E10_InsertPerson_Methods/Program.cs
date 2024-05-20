using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;

namespace E10_InsertPerson_Methods
{
    class Program
    {
        static void Main(string[] args)
        {

            // Todo MRS: implementar o try.
            Utility.SetUnicodeConsole();
            Utility.WriteTitle("Menu Insert play People","\n");
            PersonUtility personUtility = new PersonUtility();
            personUtility.Menu(); // Chama o método Menu

            Console.Clear();
            Utility.TerminateConsole();
        }
    }
}
