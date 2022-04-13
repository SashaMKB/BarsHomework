using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask
{
    class Class1
    {
        public event EventHandler<char> OnKeyPressed;
        public void Run()
        { 
        while(true)
            {
                var EnteredButton= Console.ReadKey();
                if (EnteredButton.Key == ConsoleKey.C)
                {
                    Console.WriteLine("\nExit.");
                    break;
                }
                else OnKeyPressed?.Invoke(this, EnteredButton.KeyChar);
            }
        }
    }
}
