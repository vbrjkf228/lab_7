using System;
using ClassLibrary;

namespace lab7
{
    class Program
    {
        static void Main()
        {
            Company company = new Company("Tech Corp", "Київ", "Розробник", 50000m, true);

            Worker worker1 = new Worker("Іван Іванов", "Київ", new DateTime(2015, 3, 12), company);
            Worker worker2 = new Worker("Петро Петренко", "Львів", new DateTime(2020, 8, 1), company);

            Console.WriteLine("Введення премій для співробітників:");
            worker1.SetBonus();
            worker2.SetBonus();

            Console.WriteLine("\nІнформація про співробітників:");
            Console.WriteLine(worker1);
            worker1.PrintBonusInAllCurrencies();

            Console.WriteLine(worker2);
            worker2.PrintBonusInAllCurrencies();
        }
    }
}
