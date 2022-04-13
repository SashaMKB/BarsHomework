using System;

namespace NewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var Class1 = new Class1();
            Class1.OnKeyPressed += (sender, letter) => Console.WriteLine($"\nYou entered {letter}");
            Class1.Run();
        }
    }
}
