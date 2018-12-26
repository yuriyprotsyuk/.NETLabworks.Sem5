using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ProtsyukIS63.V15
{
    /// <summary>
    /// Харчування
    /// </summary>
    interface INutrition
    {
        void Eat();

    }
    /// <summary>
    /// Всеїдні
    /// </summary>
    class Omnivorous : INutrition
    {
        public void Eat()
        {
            Console.WriteLine("Споживає рослинну i тваринну їжу\n");
        }

    }
    /// <summary>
    /// Травоїдні
    /// </summary>
    class Herbivores : INutrition
    {
        public void Eat()
        {
            Console.WriteLine("Споживає рослинну їжу\n");
        }

    }
    /// <summary>
    /// М`ясоїдні
    /// </summary>
    class Carnivorous : INutrition
    {
        public void Eat()
        {
            Console.WriteLine("Споживає тваринну їжу\n");
        }

    }
}
