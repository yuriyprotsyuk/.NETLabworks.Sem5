using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///Програма є консольним застосування на мові програмування C#. 
///Вона включає в себе 15 класів, серед яких є абстрактний. 
///Класи є між собою у зв`язках. Серед зв`язків: наслідування, агрегація і асоціація.
///У даній програмі використано 2 породжуючі патерни, а саме: Builder (Будівельник) і Singleton (Одинак).
///Патерн Будівельник обрано, оскільки процес створення нового об`єкта (смартфона) не повинен залежати від того, 
///з яких частин він складається і як ці частини взаємодіють між собою. 
///Важливим також є отримання різних варіацій смартфона в процесі його створення (бюджетна, середня та преміум-версії). 
///Конкретні будівельники різних смартфонів наслідують Абстрактний будівельник смартфонів. 
///Важливим є те, що виробник смартфонів один, і щоб забезпечити цю особливість використано патерн Одинак до класу Producer.
///Це гарантує унікальність об`єкту цього класу. 
namespace Lab1.ProtsyukIS63.V1
{
    class Program
    {
        /// <summary>
        /// Точка входу в програму
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторна робота №1. Виконав: Процюк Юрiй. Студент групи: IС-63. Варiант 1");
            ///Створення виробника смартфонів
            Producer producer = Producer.getInstance();
            ///Створення "будівельника" смартфона
            PhoneBuilder phonebuilder = new CheapPhoneBuilder();
            string sym;
            ///Обрання пункту меню
            do
            {
                Console.WriteLine("Оберiть пункт меню");
                Console.WriteLine("1. Створення смартфона економ-класу");
                Console.WriteLine("2. Створення сматрфона середнього класу");
                Console.WriteLine("3. Створення сматрфона премiум-класу");
                Console.WriteLine("0. Завершити роботу");
                sym = Console.ReadLine();
                ///Вибір з меню
                switch (sym)
                {
                    case "1":
                        phonebuilder = new CheapPhoneBuilder();
                        Smartphone cheapphone = producer.Create(phonebuilder);
                        Console.WriteLine(cheapphone.ToString());
                        break;
                    case "2":
                        phonebuilder = new MidlePhoneBuilder();
                        Smartphone midlephone = producer.Create(phonebuilder);
                        Console.WriteLine(midlephone.ToString());
                        break;
                    case "3":
                        phonebuilder = new ExtraPhoneBuilder();
                        Smartphone extraphone = producer.Create(phonebuilder);
                        Console.WriteLine(extraphone.ToString());
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Оберiть коректний пункт меню");
                        break;
                }
            } while (sym != "0");
            ///поки не обрано "Завершити роботу"
            Console.Read();
        }
    }
}
