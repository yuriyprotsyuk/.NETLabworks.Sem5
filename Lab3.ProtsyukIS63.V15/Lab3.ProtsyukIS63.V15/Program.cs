using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///Програма є консольним застосування на мові програмування C#. 
///Для реалізації даної в умові задачі обрано патерн "Відвідувач" (Visitor).
///Цей патерн обрано, оскільки потрібно одноманітно обійти набір елементів з різнорідними інтерфейсами, 
///а також дозволяє додати новий метод в клас об'єкта, при цьому не змінюючи сам клас цього об'єкта.
namespace Lab3.ProtsyukIS63.V15
{
    class Program
    {
        /// <summary>
        /// Точка входу в програму
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторна робота №3. Процюк Юрiй IS-63. Variant-15");
            Console.WriteLine("Реализовать задачу “Принтеры”. В проекте должны быть реализованы разные модели принтеров, которые выполняют разные виды печати. Определить логику изменения состояний и разработать модель системы.");
 
            var system = new PrintSystem();
            system.Add(new ColorPrinter { Type = "Кольоровий принтер", Firm = "HP" });
            system.Add(new BlackPrinter { Type = "Чорно-бiлий принтер", Firm = "Xerox" });
            string sym;
            do
            {
                Console.WriteLine("Оберiть пункт меню");
                Console.WriteLine("1. Кольоровий друк");
                Console.WriteLine("2. Чорно-бiлий друк");
                Console.WriteLine("0. Завершити роботу");
                sym = Console.ReadLine();
                ///Вибір з меню
                switch (sym)
                {
                    case "1":
                        system.Accept(new ColorVisitor { Type = "Кольоровий друк" });
                        break;
                    case "2":
                        system.Accept(new BlackVisitor { Type = "Чорно-бiлий друк" });
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Оберiть коректний пункт меню");
                        break;
                }
            }
            while (sym != "0");
            Console.Read();
        }
    }
}
