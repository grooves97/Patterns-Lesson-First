using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            Console.WriteLine("Insert name");

            manager.Name = Console.ReadLine();

            Console.WriteLine("Insert company");

            manager.Company = Console.ReadLine();

            Console.WriteLine($"Name: {manager.Name}, company: {manager.Company}");
            Console.ReadLine();
        }
    }
}
