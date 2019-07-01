using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLab
{
    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();

        IAbstractProductB CreateProductB();
    }
    public interface IAbstractProductA
    {
        string UsefulFunctionA();
    }

    public interface IAbstractProductB
    {
        // Продукт B способен работать самостоятельно...
        string UsefulFunctionB();

        // ...а также взаимодействовать с Продуктами Б той же вариации.
        //
        // Абстрактная Фабрика гарантирует, что все продукты, которые она
        // создает, имеют одинаковую вариацию и, следовательно, совместимы.
        string AnotherUsefulFunctionB(IAbstractProductA collaborator);
    }

    public class Client
    {
        public void Main()
        {
            // Клиентский код может работать с любым конкретным классом
            // фабрики.
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new ConcreteFactory1());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new ConcreteFactory2());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            IAbstractProductA productA = factory.CreateProductA();
            IAbstractProductB productB = factory.CreateProductB();

            Console.WriteLine(productB.UsefulFunctionB());
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }
    }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    public class ConcreteProductA1 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A1.";
        }
    }

    public class ConcreteProductA2 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A2.";
        }
    }

    public class ConcreteProductB1 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return "The result of the product B1.";
        }

        // Продукт B1 может корректно работать только с Продуктом A1. Тем не
        // менее, он принимает любой экземпляр Абстрактного Продукта А в
        // качестве аргумента.
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"The result of the B1 collaborating with the ({result})";
        }
    }

    public class ConcreteProductB2 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return "The result of the product B2.";
        }

        // Продукт B2 может корректно работать только с Продуктом A2. Тем не
        // менее, он принимает любой экземпляр Абстрактного Продукта А в качестве
        // аргумента.
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"The result of the B2 collaborating with the ({result})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
