using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///Програма є консольним застосування на мові програмування C#. Вона включає в себе інтерфейси і класи.
/// Серед зв`язків можна виокремети наслідування.
/// 
///Обрано патерн "Міст", оскільки існує багато тварин, що можуть бути ссавцями, птахами, рибами чи черв`яками (умовно)
///Для всіх них може бути різне середовище існування і тип харчування для цих тварин. І в залежності від обраного середовища і 
///харчування відрізняються їх описи.
namespace Lab2.ProtsyukIS63.V15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторна робота №2. Процюк Юрiй IS-63. Variant-15");
            Console.WriteLine("Реализовать задачу «Животное» и различные его виды. С помощью шаблонов задать способы обитания и питания.");
            Animal bird = new Bird(new AirEnviroment(), new Omnivorous(), "Рябчик");
            bird.NameSelf();
            bird.TalkLifestyle();
            bird.Name = "Папуга";
            bird.Nutrition = new Herbivores();
            bird.NameSelf();
            bird.TalkLifestyle();
            Animal mammal = new Mammal(new AirEnviroment(), new Carnivorous(), "Лев");
            mammal.NameSelf();
            mammal.TalkLifestyle();
            mammal.Nutrition = new Herbivores();
            mammal.Name = "Ягня";
            mammal.NameSelf();
            mammal.TalkLifestyle();
            Animal fish = new Mammal(new WaterEnvironment(), new Herbivores(), "Карась");
            mammal.NameSelf();
            mammal.TalkLifestyle();
            mammal.Nutrition = new Carnivorous();
            mammal.Name = "Осетер";
            mammal.NameSelf();
            mammal.TalkLifestyle();
            Animal worm = new Worm(new Underground(), new Herbivores(), "Червяк дощовий");
            worm.NameSelf();
            worm.TalkLifestyle();
            Console.Read();
        }
    }
}
